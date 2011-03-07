using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace MVCWebApplication.Utils
{
    public class Common
    {   
        #region xml Serialize tools
        public static T Deserialize<T>(string strXML)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.DTD;

            Stream stream = new MemoryStream(Encoding.GetEncoding("GB2312").GetBytes(strXML));
            XmlReader reader = XmlReader.Create(stream, settings);
            T request = (T)xml.Deserialize(reader);
            return request;
        }
        public static void Serialize<T>(T t, Stream srm)
        {
            XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
            xmlNS.Add("", "");
            StreamWriter writer = new StreamWriter(srm, System.Text.Encoding.GetEncoding("GB2312"));
            XmlSerializer xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer, t, xmlNS);
        }
        public static string Serialize<T>(T t)
        {
            XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
            xmlNS.Add("", "");
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, System.Text.Encoding.GetEncoding("GB2312"));
            XmlSerializer xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer, t, xmlNS);
            StreamReader read = new StreamReader(ms, System.Text.Encoding.GetEncoding("GB2312"));
            ms.Position = 0;
            String strXML = read.ReadToEnd();
            return strXML;
        }
        #endregion
    }
}
