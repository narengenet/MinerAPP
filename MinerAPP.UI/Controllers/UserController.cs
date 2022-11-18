using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MinerAPP.Application.DTO;
using MinerAPP.Application.Interfaces;
using MinerAPP.Core.Domain;
using MailKit.Net.Smtp;
using MinerAPP.Infrastructure;
using AutoMapper;

namespace MinerAPP.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersServices _usersServices;

        private readonly IMapper _mapper;

        public UserController(IUsersServices usersServices, IMapper mapper)
        {
            _usersServices = usersServices;
            _mapper = mapper;
        }
        // GET: UserController
        public ActionResult Index()
        {
            List<string> names = _usersServices.GetUsernames();
            List<User> users = new List<User>();
            foreach (var item in names)
            {
                users.Add(new User { username = item });
            }
            return Ok(users);
        }

        public ActionResult GetAll()
        {
            List<User> users = _usersServices.GetAllUser();

            return Ok(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: UserController/checkemail/emailaddress
        public ActionResult checkemail(string id)
        {
            User usr = _usersServices.GetAllUser().Where(u => u.email == id).FirstOrDefault();
            if (usr == null)
            {
                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }        // GET: UserController/checkemail/emailaddress
        public ActionResult checkmobile(string id)
        {
            User usr = _usersServices.GetAllUser().Where(u => u.phone == id).FirstOrDefault();
            if (usr == null)
            {
                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }
        public ActionResult checkusername(string id)
        {
            User usr = _usersServices.GetAllUser().Where(u => u.username == id).FirstOrDefault();
            if (usr == null)
            {
                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }

        [HttpPost]
        public ActionResult registerClient([FromBody] User newUser)
        {
            Guid? result = _usersServices.AddUser(newUser);
            if (result == null)
            {
                return Ok("-1");
            }

            return Ok(result.ToString());
        }
        [HttpPost]
        public ActionResult confirmRegisterClient([FromBody] UserLogin userLogin)
        {
            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            if (result == null)
            {
                return Ok("-1");
            }
            if (result.ConfirmationCode == userLogin.confirmation)
            {
                _usersServices.DeleteAllUserLogins(Guid.Parse(userLogin.userid));
                theResult = _usersServices.AddLogin(new UsersLogins
                {
                    Created = DateTime.Now,
                    DeviceModel = userLogin.devicemodel,
                    IMEI = userLogin.imei,
                    User = Guid.Parse(userLogin.userid)

                });
                Users usr = _usersServices.GetUser(Guid.Parse(userLogin.userid));
                usr.IsActivated = true;
                _usersServices.UpdateUser(usr);
            }

            if (theResult != null)
            {
                return Ok(theResult.ToString());
            }
            else
            {
                return Ok("-1");
            }

        }

        [HttpPost]
        public ActionResult goLogin([FromBody] User userLogin)
        {

            if (userLogin.email.Contains("@"))
            {
                Users user = _usersServices.GetAllUsers().Where(u => u.Email == userLogin.email).FirstOrDefault();
                if (user != null)
                {
                    Random r = new Random();
                    int _confirmationCode = r.Next(10000, 99999);
                    user.ConfirmationCode = _confirmationCode.ToString();
                    _usersServices.UpdateUser(user);
                    DependencyContainer.SendEmail(user.Email, "Monero Miner Email Verification", "Assets\\EmailTemplates\\RegConfirm.txt", new string[] { user.ConfirmationCode });
                    return Ok(user.Id.ToString());
                }

            }
            else
            {
                Users user = _usersServices.GetAllUsers().Where(u => u.Username == userLogin.username).FirstOrDefault();
                if (user != null)
                {
                    Random r = new Random();
                    int _confirmationCode = r.Next(10000, 99999);
                    user.ConfirmationCode = _confirmationCode.ToString();
                    _usersServices.UpdateUser(user);
                    DependencyContainer.SendEmail(user.Email, "Monero Miner Email Verification", "Assets\\EmailTemplates\\RegConfirm.txt", new string[] { user.ConfirmationCode });
                    return Ok(user.Id.ToString());
                }
            }

            return Ok("-1");

        }

        [HttpPost]
        public IActionResult verifyLogin([FromBody] UserLogin userLogin)
        {
            string uid = userLogin.userid;
            Guid _uid = new Guid();
            try
            {
                _uid = Guid.Parse(uid);
                Users theUser = _usersServices.GetUser(_uid);
                if (theUser != null)
                {
                    if (userLogin.confirmation == theUser.ConfirmationCode)
                    {
                        _usersServices.DeleteAllUserLogins(theUser.Id);
                        Guid? loginId = _usersServices.AddLogin(new UsersLogins
                        {
                            Created = DateTime.Now,
                            DeviceModel = userLogin.devicemodel,
                            IMEI = userLogin.imei,
                            User = theUser.Id
                        });

                        if (!theUser.IsActivated)
                        {
                            theUser.IsActivated = true;
                            _usersServices.UpdateUser(theUser);
                        }
                        return Ok(loginId.ToString());
                    }
                }
            }
            catch (Exception)
            {

                return Ok("-1");
            }
            return Ok("-1");
        }

        [HttpPost]
        public ActionResult loginCheck([FromBody] UserLogin userLogin)
        {
            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok("-1");
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == result.Id).FirstOrDefault();
                if (usrsLogin.IMEI != userLogin.imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != userLogin.devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }

        [HttpPost]
        public ActionResult checkDeposite([FromBody] UserLogin userLogin)
        {
            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok(null);
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == result.Id).FirstOrDefault();
                if (usrsLogin.IMEI != userLogin.imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != userLogin.devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                string theQR = _usersServices.GetAllStaticDics().Where(d => d.TheName == "theqr").First().TheValue;
                string theWallet = _usersServices.GetAllStaticDics().Where(d => d.TheName == "thewallet").First().TheValue;

                DoubleStrings rslt = new DoubleStrings { data1 = theQR, data2 = theWallet };
                return Ok(rslt);
            }
            else
            {
                return Ok(null);
            }

        }
        
        [HttpPost]
        public ActionResult checkWithdraw([FromBody] UserLogin userLogin)
        {
            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok(null);
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == result.Id).FirstOrDefault();
                if (usrsLogin.IMEI != userLogin.imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != userLogin.devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                string theWallet = result.WalletAddress;

                DoubleStrings rslt = new DoubleStrings { data1 = "", data2 = theWallet };
                return Ok(rslt);
            }
            else
            {
                return Ok(null);
            }

        }

        [HttpPost]
        public ActionResult addDeposit([FromBody] UserLogin userLogin)
        {
            int amountData = Convert.ToInt32(Request.Headers["amount"]);
            string hashData = Request.Headers["hash"];

            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok("-1");
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == result.Id).FirstOrDefault();
                if (usrsLogin.IMEI != userLogin.imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != userLogin.devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                _usersServices.AddTransaction(new Transactions{
                    Amount = amountData,
                    UserID = result.Id,
                    TheHash = hashData,
                    Confirmed = false,
                    IsDeposit=true,
                    TheWallet="",
                    Created = DateTime.Now
                });

                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }
        
        [HttpPost]
        public ActionResult addWithdraw([FromBody] UserLogin userLogin)
        {
            int amountData = Convert.ToInt32(Request.Headers["amount"]);
            string walletData = Request.Headers["wallet"];

            Users result = _usersServices.GetUser(Guid.Parse(userLogin.userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok("-1");
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == result.Id).FirstOrDefault();
                if (usrsLogin.IMEI != userLogin.imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != userLogin.devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                _usersServices.AddTransaction(new Transactions{
                    Amount = amountData,
                    UserID = result.Id,
                    TheHash = "",
                    Confirmed = false,
                    IsDeposit=false,
                    TheWallet=walletData,
                    Created = DateTime.Now
                });

                return Ok("ok");
            }
            else
            {
                return Ok("-1");
            }

        }
        
        
        [HttpGet]
        public ActionResult getTransactions([FromBody] UserLogin userLogin)
        {
            string imei = Request.Headers["imei"];
            string devicemodel = Request.Headers["device"];
            string userid = Request.Headers["uid"];
            string userlid = Request.Headers["ulid"];
            int page = Convert.ToInt32(Request.Headers["page"]);




            Users result = _usersServices.GetUser(Guid.Parse(userid));
            Guid? theResult = null;
            bool status = true;

            if (result == null)
            {
                status = false;
                return Ok(null);
            }
            if (result.IsDeleted == false && result.IsActivated)
            {
                UsersLogins usrsLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.User == Guid.Parse(userid)).FirstOrDefault();
                if (usrsLogin.IMEI != imei)
                {
                    status = false;
                }
                if (usrsLogin.DeviceModel != devicemodel)
                {
                    status = false;
                }
            }
            else
            {
                status = false;
            }

            if (status)
            {
                List<Transaction> allTransactions= _mapper.Map<List<Transaction>>(_usersServices.GetAllTransactions().Where(t => t.UserID == Guid.Parse(userid)).Skip(8*page).Take(8).ToList<Transactions>());


                if (allTransactions.Count>0)
                {
                    return Ok(allTransactions);

                }
                else
                {
                    return Ok(null);
                }
            }
            else
            {
                return Ok(null);
            }

        }


        [HttpPost]
        public ActionResult getUserData([FromBody] UserLogin userReq)
        {
            Users theUser = _usersServices.GetUser(Guid.Parse(userReq.userid));
            if (theUser != null)
            {
                UsersLogins usrLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.Id == Guid.Parse(userReq.loginid) && ul.IMEI == userReq.imei && ul.DeviceModel == userReq.devicemodel).FirstOrDefault();
                if (usrLogin != null)
                {
                    User result = new User
                    {
                        imei = theUser.WalletAddress,
                        name = theUser.Name,
                        surename = theUser.Family,
                        username = theUser.Username,
                        email = theUser.Email,
                        phone = theUser.Cellphone,
                        balance=theUser.Balance.ToString()
                    };
                    return Ok(result);
                }
            }
            return Ok(null);
        }

        [HttpPost]
        public ActionResult updateUser([FromBody] User userUpdate)
        {
            string lid = Request.Headers["data1"].ToString();
            string id = Request.Headers["data2"].ToString();
            string wallet = Request.Headers["data3"].ToString();

            Users theUser = _usersServices.GetUser(Guid.Parse(id));
            if (theUser != null)
            {
                UsersLogins usrLogin = _usersServices.GetAllUsersLogins().Where(ul => ul.Id == Guid.Parse(lid) && ul.IMEI == userUpdate.imei && ul.DeviceModel == userUpdate.devicemodel).FirstOrDefault();
                if (usrLogin != null)
                {

                    theUser.Name = userUpdate.name;
                    theUser.Family = userUpdate.surename;
                    theUser.Email = userUpdate.email;
                    theUser.Cellphone = userUpdate.phone;
                    theUser.WalletAddress = wallet;
                    theUser.LastModified = DateTime.Now;

                    _usersServices.UpdateUser(theUser);
                    return Ok("ok");
                }
            }

            return Ok("-1");

        }




        public ActionResult sendemail()
        {
            // create email message
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("veronica.schaden@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("sarparast_r@yahoo.com"));
            //email.Subject = "Test Email from Sina";
            //email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Hi</h1><p>salam</p>" };

            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("veronica.schaden@ethereal.email", "cUrGNwvSZXE9NJcEYz");
            //smtp.Send(email);
            //smtp.Disconnect(true);

            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("sina.developer@omanmultimedia.com"));
            //email.To.Add(MailboxAddress.Parse("sarparast.s@gmail.com"));
            //email.Subject = "Test Email from Sina";
            //email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Hi</h1><p>salam</p>" };

            //using var smtp = new SmtpClient();
            //smtp.Connect("mail.omanmultimedia.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("sina.developer@omanmultimedia.com", "Blueframe95!!");
            //smtp.Send(email);
            //smtp.Disconnect(true);

            string[] arrs = { "12345" };
            DependencyContainer.SendEmail("sarparast.s@gmail.com", "My Subject", "Assets\\EmailTemplates\\RegConfirm.txt", arrs);



            //SmtpClient smtp = new SmtpClient("smtp-relay.gmail.com", 465);
            //smtp.EnableSsl = false;
            //smtp.Credentials = new NetworkCredential("sarparast.s@gmail.com", "Blueframe95!!");
            //smtp.UseDefaultCredentials = true;
            //smtp.Send(new MailMessage("sarparast.s@gmail.com", "sarparast_r@yahoo.com", "Hello world", "testbody"));

            return Ok("ok");
        }




        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
