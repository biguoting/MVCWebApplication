using System;
using System.Collections.Specialized;
using Castle.MonoRail.Framework;
using Castle.MonoRail.Framework.Internal;
using System.Web;
using MVCWebApplication.Models;

namespace MVCWebApplication.Web.Secue
{
    public class AuthenticationFilter : IFilter
    {
        public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller)
        {
            User user = (User)context.Session["logonUser"];
            if (user == null)
            {



                return false;
            }
            return true;
        }
    }
}
