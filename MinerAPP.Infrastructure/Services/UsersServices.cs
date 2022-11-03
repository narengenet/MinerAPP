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

        private readonly IMapper _mapper;

        public UsersServices(
            IUsersRepository userRepo,
            IMapper mapper
            )
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        //public List<Users> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        public Users GetUser(Guid id)
        {
            Users usr = _userRepo.GetById(id);
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
        public List<User> GetAllUsers()
        {
            return _mapper.Map<List<User>>(_userRepo.GetAll().Where(u=>u.IsDeleted==false));
        }

        public Guid? AddUser(User user)
        {
            bool cond = false;
            List<User> usrs = GetAllUsers();
            
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


            
            Users usr = _mapper.Map<Users>(user);
            Random r = new Random();
            int _confirmationCode = r.Next(10000, 99999);
            usr.ConfirmationCode = _confirmationCode.ToString();
            Users newUser= _userRepo.Add(usr);
            return newUser.Id;
        }
    }
}
