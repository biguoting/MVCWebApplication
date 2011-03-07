using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Net;
using System.Web;
namespace MVCWebApplication.Utils
{
    public class HttpUtil
    {
        /// <summary>
        /// 向指定的url发送序列化后的对象数据，返回响应字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="webUrl"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetWebResponse<T>(string webUrl, T param, string encoding)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(webUrl);
            myRequest.Timeout = 3600000;
            myRequest.Method = "POST";
            myRequest.ContentType = "text/xml";
            var zipStreamReq = new GZipStream(myRequest.GetRequestStream(), CompressionMode.Compress);
            string requestMsg = Common.Serialize<T>(param);
            var writer = new StreamWriter(zipStreamReq, System.Text.Encoding.GetEncoding(encoding));
            writer.WriteLine(requestMsg);
            writer.Flush();
            writer.Close();

            // 得到响应
            //return myRequest.GetResponse();
            var myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream receiveStream = myResponse.GetResponseStream();
            GZipStream zipReceiveStream = new GZipStream(receiveStream, CompressionMode.Decompress);
            StreamReader readStream = new StreamReader(zipReceiveStream, Encoding.GetEncoding(encoding));
            string returnCont = readStream.ReadToEnd();
            readStream.Close();
            return returnCont;
        }
        /// <summary>
        /// 向指定的url发送字符串数据，返回响应字符串
        /// </summary>
        /// <param name="webUrl"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetWebResponse(string webUrl, string param, string encoding)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(webUrl);
            myRequest.Timeout = 3600000;
            myRequest.Method = "POST";
            myRequest.ContentType = "text/xml";
            var zipStreamReq = new GZipStream(myRequest.GetRequestStream(), CompressionMode.Compress);
            var writer = new StreamWriter(zipStreamReq, System.Text.Encoding.GetEncoding(encoding));
            writer.WriteLine(param);
            writer.Flush();
            writer.Close();

            // 得到响应
            //return myRequest.GetResponse();
            var myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream receiveStream = myResponse.GetResponseStream();
            GZipStream zipReceiveStream = new GZipStream(receiveStream, CompressionMode.Decompress);
            StreamReader readStream = new StreamReader(zipReceiveStream, Encoding.GetEncoding(encoding));
            string returnCont = readStream.ReadToEnd();
            readStream.Close();
            return returnCont;
        }

        public static void WritePressResponse<T>(HttpResponse Response, string data, string encoding)
        {
            T obj = Common.Deserialize<T>(data);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "text/xml";
            Response.ContentEncoding = Encoding.GetEncoding(encoding);
            Common.Serialize<T>(obj, Response.OutputStream);
            Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
        }
    }
}
