using MinerAPP.Application.DTO;
using MinerAPP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Application.Interfaces
{
    public interface IUsersServices
    {
        List<String> GetUsernames();
        Users GetUser(Guid id);
        Users GetUserByUsername(string username);
        Users GetUserByCellphone(string cellphone);
        List<User> GetUsers(int pageNumber);
        List<User> GetAllUser();
        List<Users> GetAllUsers();
        public Guid? AddUser(User user);
        public bool UpdateUser(Users user);




        public List<UsersLogins> GetAllUsersLogins();
        public Guid? AddLogin(UsersLogins userLogin);
        public bool DeleteAllUserLogins(Guid userId);
    }
}
