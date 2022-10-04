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

        public UsersServices(IUsersRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<Users> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Users GetUser(int id)
        {
            throw new NotImplementedException();
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

        public List<Users> GetUsers(int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
