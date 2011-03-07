using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Castle.MonoRail.Framework;
using MVCWebApplication.Web.Secue;
namespace MVCWebApplication.Web.Controllers
{
    [Filter(ExecuteEnum.BeforeAction,typeof(AuthenticationFilter))]
    public class UserController : BaseController
    {
        public void index()
        { 
        
        }
        public void login()
        { 
        
        }
        [SkipFilter()]
        public void skiplogin()
        {

        }
    }
}
