using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Castle.MonoRail.Framework;
using MVCWebApplication.Web.Interfaces;
using MVCWebApplication.Models;
using MVCWebApplication.Utils;
namespace MVCWebApplication.Web.Controllers
{
    public class PeopleController : BaseController
    {
        string encoding = "GB2312";
        public void Index()
        {
            PropertyBag.Add("authority", Request.Uri.Authority);
        }
        public void SendRequest(string uri,string param)
        { 
           string msg= HttpUtil.GetWebResponse(uri, param, encoding);
           RenderText(msg);
           CancelView();
        }
        public void QueryPeople()
        {
            Encoding encode = Encoding.GetEncoding(encoding);
            GZipStream zipStream = new GZipStream(this.HttpContext.Request.InputStream, CompressionMode.Decompress);
            // Read XML posted via HTTP
            StreamReader reader = new StreamReader(zipStream, encode);
            String requestData = reader.ReadToEnd();
            HttpUtil.WritePressResponse<People>(this.HttpContext.Response, requestData, encoding);           
            CancelView();
        }
    }
}
