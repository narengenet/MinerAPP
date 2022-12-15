using AutoMapper;
using MinerAPP.Application.DTO;
using MinerAPP.Application.Interfaces;
using MinerAPP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure.Services
{
    public class UsersServices : IUsersServices

    {
        private readonly IUsersRepository _userRepo;
        private readonly IUsersLoginsRepository _userLoginRepo;
        private readonly IStaticDictionariesRepository _staticDicsRepo;
        private readonly ITransactionsRepository _transacRepo;

        private readonly IMapper _mapper;

        public UsersServices(
            IUsersRepository userRepo,
            IUsersLoginsRepository userLoginRepo,
            IStaticDictionariesRepository staticDicRepo,
            ITransactionsRepository transacRepo,
            IMapper mapper
            )
        {
            _userRepo = userRepo;
            _userLoginRepo = userLoginRepo;
            _staticDicsRepo = staticDicRepo;
            _transacRepo = transacRepo;

            _mapper = mapper;
        }

        //public List<Users> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        public Users GetUser(Guid id)
        {
            Users usr = _userRepo.GetById(id);
            if (usr == null)
            {
                return null;
            }
            if (usr.IsDeleted)
            {
                return null;
            }
            return usr;
        }

        public Users GetUserByCellphone(string cellphone)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsernames()
        {
            Users[] users = _userRepo.GetAll().ToArray();
            List<String> usernames = new List<string>();
            foreach (Users item in users)
            {
                usernames.Add(item.Username);
            }
            return usernames;
        }

        public List<User> GetUsers(int pageNumber)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAllUser()
        {
            return _mapper.Map<List<User>>(_userRepo.GetAll().Where(u => u.IsDeleted == false));
        }
        public List<Users> GetAllUsers()
        {
            return _userRepo.GetAll().Where(u => u.IsDeleted == false).ToList<Users>();
        }

        public Guid? AddUser(User user)
        {
            bool cond = false;
            List<User> usrs = GetAllUser();

            if (usrs.Find(u => u.surename == user.username) != null)
            {
                return null;
            }

            if (usrs.Find(u => u.phone == user.phone) != null)
            {
                return null;
            }

            if (usrs.Find(u => u.email == user.email) != null)
            {
                return null;
            }



            user.balance = "0";

            Users usr = _mapper.Map<Users>(user);
            if (user.inviterid != null)
            {
                Users theInviter = _userRepo.GetAll().Where(u=>u.Username==user.inviterid).First();
                if (theInviter != null)
                {
                    usr.Inviter = theInviter.Id;
                    double theReward = Convert.ToDouble(_staticDicsRepo.GetAll().Where(c => c.TheName == "inviterreward").First().TheValue);
                    theInviter.Balance += theReward;
                    _userRepo.Update(theInviter);
                    _transacRepo.Add(new Transactions { Amount = theReward, Confirmed = true, Created = DateTime.Now, UserID = theInviter.Id, IsDeposit = true, TheWallet="-1" , TheHash = usr.Username + " invitation" });
                }
            }
            Random r = new Random();
            int _confirmationCode = r.Next(10000, 99999);
            usr.ConfirmationCode = _confirmationCode.ToString();
            usr.Created = DateTime.Now;
            Users newUser = _userRepo.Add(usr);
            DependencyContainer.SendEmail(usr.Email, "Monero Miner Email Verification", "Assets\\EmailTemplates\\RegConfirm.txt", new string[] { usr.ConfirmationCode });
            return newUser.Id;
        }

        public bool UpdateUser(Users user)
        {
            _userRepo.Update(user);
            return true;
        }




        public List<UsersLogins> GetAllUsersLogins()
        {
            return _userLoginRepo.GetAll().Where(ul => ul.IsDeleted == false).ToList<UsersLogins>();
        }
        public Guid? AddLogin(UsersLogins userLogin)
        {
            UsersLogins usrLogins = _userLoginRepo.Add(userLogin);
            return usrLogins.Id;
        }
        public bool DeleteAllUserLogins(Guid userId)
        {
            List<UsersLogins> usrLogins = GetAllUsersLogins().Where(ul => ul.User == userId).ToList<UsersLogins>();
            foreach (UsersLogins item in usrLogins)
            {
                item.IsDeleted = true;
                _userLoginRepo.Update(item);
            }
            return true;

        }

        List<StaticDictionaries> IUsersServices.GetAllStaticDics()
        {
            return _staticDicsRepo.GetAll().Where(d => d.IsDeleted == false).ToList<StaticDictionaries>();
        }

        public List<Transactions> GetAllTransactions()
        {
            return _transacRepo.GetAll().Where(d => d.IsDeleted == false).ToList<Transactions>();
        }
        public Transactions AddTransaction(Transactions transaction)
        {
            return _transacRepo.Add(transaction);
        }

        public void UpdateLastUserActivity(Guid userLoginId)
        {
            UsersLogins usrLogin= _userLoginRepo.GetById(userLoginId);
            usrLogin.LastModified = DateTime.Now;
            _userLoginRepo.Update(usrLogin);
        }
    }
}
