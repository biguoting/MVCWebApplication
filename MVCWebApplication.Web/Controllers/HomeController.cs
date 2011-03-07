using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using MVCWebApplication.Utils;
namespace MVCWebApplication.Web.Controllers
{
    public class HomeController : BaseController
    {
        public void Index(string param)
        {
            //LoggerClass.Info("home/index.htm page started");
            PropertyBag.Add("param", param);
        }
        /// <summary>
        /// ajax method for chek routing
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="replaceStr"></param>
        public void CheckRouting(string pattern, string replaceStr)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(pattern);
            string flag = reg.IsMatch(replaceStr) ? "匹配" : "不匹配";
            RenderText(flag);
            CancelView();
        }
        public void Parse()
        {
            PropertyBag.Add("tag1", "123");
        }
        /// <summary>
        /// ajax method for demo of parsing NVelocity Temp with VelocityEngine
        /// </summary>
        /// <param name="template"></param>
        /// <param name="dirctionary"></param>
        public void getParseResult(string template,string  dirctionary)
        {
            if ((template == null) || (dirctionary == null))
            {
                CancelView();
                return;
            }
            var map=Newtonsoft.Json.JavaScriptConvert.DeserializeObject<Hashtable>(dirctionary);

            var writer = new System.IO.StringWriter();
            var nve = new NVelocity.App.VelocityEngine();
            nve.Init();
            var context = new NVelocity.VelocityContext(map);
            nve.Evaluate(context, writer, "", template);
            RenderText(writer.GetStringBuilder().ToString());
            writer.Close();
            CancelView();
        }
        public void EasyUI()
        { 
        
        }

    }
}
