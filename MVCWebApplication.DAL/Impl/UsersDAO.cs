using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MVCWebApplication.DAL.Interfaces;
using MVCWebApplication.Models;
namespace MVCWebApplication.DAL.Impl
{
    public class UsersDAO:BaseDAO,IUsers
    {
        public IList GetUserList()
        {
            return base.ExecuteQueryForList("getUsers", null);
             
        }
        public void UpdateUser(User user)
        {
            base.ExecuteUpdate("updateUser", user);
        }
    }

    
}
