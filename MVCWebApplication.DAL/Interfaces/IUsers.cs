using System;
using System.Collections;
using System.Linq;
using System.Text;
using MVCWebApplication.Models;
namespace MVCWebApplication.DAL.Interfaces
{
    interface IUsers
    {
        IList GetUserList();
        void UpdateUser(User user);
    }
}
