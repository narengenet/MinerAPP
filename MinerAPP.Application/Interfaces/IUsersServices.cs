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
        Users GetUser(int id);
        Users GetUserByUsername(string username);
        Users GetUserByCellphone(string cellphone);
        List<Users> GetUsers(int pageNumber);
        List<Users> GetAllUsers();
    }
}
