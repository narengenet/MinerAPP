using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MinerAPP.Application.DTO;
using MinerAPP.Application.Interfaces;
using MinerAPP.Core.Domain;
using MailKit.Net.Smtp;

namespace MinerAPP.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersServices _usersServices;

        public UserController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
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
            List<User> users = _usersServices.GetAllUsers();

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
            User usr = _usersServices.GetAllUsers().Where(u => u.email == id).FirstOrDefault();
            if (usr==null)
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
            User usr = _usersServices.GetAllUsers().Where(u => u.phone == id).FirstOrDefault();
            if (usr==null)
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
            User usr = _usersServices.GetAllUsers().Where(u => u.username == id).FirstOrDefault();
            if (usr==null)
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
            Guid? result= _usersServices.AddUser(newUser);
            if (result==null)
            {
                return Ok("-1");
            }
            return Ok(result.ToString());
        }



        public ActionResult sendemail()
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("veronica.schaden@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("sarparast_r@yahoo.com"));
            email.Subject = "Test Email from Sina";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Hi</h1><p>salam</p>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            smtp.Authenticate("veronica.schaden@ethereal.email", "cUrGNwvSZXE9NJcEYz");
            smtp.Send(email);
            smtp.Disconnect(true);



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
