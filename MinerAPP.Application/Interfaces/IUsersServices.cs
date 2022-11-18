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
        Guid? AddUser(User user);
        bool UpdateUser(Users user);




        List<UsersLogins> GetAllUsersLogins();
        Guid? AddLogin(UsersLogins userLogin);
        bool DeleteAllUserLogins(Guid userId);

        List<StaticDictionaries> GetAllStaticDics();
        
        
        
        List<Transactions> GetAllTransactions();
        Transactions AddTransaction(Transactions transaction);


    }
}
