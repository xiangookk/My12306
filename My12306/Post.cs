using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace My12306
{
    /// <summary>
    /// 实现网站登录类
    /// </summary>
    public class Post
    {
        /// <summary>
        /// 网站Cookies
        /// </summary>
        private string _cookieHeader = string.Empty;
        public string CookieHeader
        {
            get
            {
                return _cookieHeader;
            }
            set
            {
                _cookieHeader = value;
            }
        }
        /// <summary>
        /// 网站编码
        /// </summary>
        private string _code = string.Empty;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _pageContent = string.Empty;
        public string PageContent
        {
            get { return _pageContent; }
            set { _pageContent = value; }
        }
        private Dictionary<string, string> _para = new Dictionary<string, string>();
        public Dictionary<string, string> Para
        {
            get { return _para; }
            set { _para = value; }
        }
        //public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{   // 总是接受  
        //    return true;
        //}
       public CookieContainer cc = new CookieContainer();
        
        /**/
        /// <summary>
        /// 功能描述：模拟登录页面，提交登录数据进行登录，并记录Header中的cookie
        /// </summary>
        /// <param name="strURL">登录数据提交的页面地址</param>
        /// <param name="strArgs">用户登录数据</param>
        /// <param name="strReferer">引用地址</param>
        /// <param name="code">网站编码</param>
        /// <returns>可以返回页面内容或不返回</returns>
        public string PostData(string strURL, string strArgs, string strReferer, string code, string method)
        {
            return PostData("",strURL, strArgs, strReferer, code, method, string.Empty);
        }
        public string PostData(string dlip, string strURL, string strArgs, string strReferer, string code, string method)
        {
            return PostData(dlip, strURL, strArgs, strReferer, code, method, string.Empty);
        }
        private string PostData(string dlip,string strURL, string strArgs, string strReferer, string code, string method, string contentType)
        {
            try
            {
                string strResult = "";
                Stream PostStream = null;
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
               // ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.KeepAlive = true;
                myHttpWebRequest.Timeout = 50000;
               // myHttpWebRequest.Connection = "	keep-alive";
                myHttpWebRequest.Accept = "text/plain,image/jpeg,text/html,application/xhtml+xml,application/json,text/javascript,application/xml;q=0.9,*/*;q=0.8";
                myHttpWebRequest.Referer = strReferer;
                //firefox
               myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
                // myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.1; CIBA)";
                if (string.IsNullOrEmpty(contentType))
                {
                    myHttpWebRequest.ContentType = "application/x-www-form-urlencoded;";
                }
                else
                {
                    myHttpWebRequest.ContentType = contentType;
                }
                if (!string.IsNullOrEmpty(dlip))
                {
                    WebProxy prox;
                    if (dlip.IndexOf(":") == -1)
                    {
                        prox = new WebProxy(dlip);
                    }
                    else
                    {
                        prox = new WebProxy(dlip.Split(':')[0], int.Parse(dlip.Split(':')[1]));
                    }
                    myHttpWebRequest.Proxy = prox;
                }
                myHttpWebRequest.Method = method;
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                myHttpWebRequest.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
                myHttpWebRequest.CookieContainer = cc;
                if (!string.IsNullOrEmpty(strArgs)&&method.ToUpper()=="POST")
                {
                    byte[] postData = Encoding.GetEncoding(code).GetBytes(strArgs);
                    myHttpWebRequest.ContentLength = postData.Length;
                   
                    PostStream = myHttpWebRequest.GetRequestStream();
                    PostStream.Write(postData, 0, postData.Length);
                    PostStream.Close();
                }
                HttpWebResponse response = null;
                System.IO.StreamReader sr = null;
                response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                
                if (myHttpWebRequest.CookieContainer != null)
                {
                    cc = myHttpWebRequest.CookieContainer;
                }
               
                string ce = response.ContentEncoding;
                Stream streamReceive = response.GetResponseStream();
                if (response.StatusCode == HttpStatusCode.Redirect)
                {
                    strResult = "302";
                }
                else if (ce.ToLower() == "gzip")
                {
                    GZipStream gzip = new GZipStream(streamReceive, CompressionMode.Decompress);
                    using (StreamReader reader = new StreamReader(gzip, Encoding.UTF8))
                    {
                        strResult = reader.ReadToEnd();
                        gzip.Close();
                        reader.Close();
                    }
                }
                else if (response.ContentType.Contains("image"))
                {
                    MemoryStream ImgStream = new MemoryStream();
                    System.Drawing.Image i = System.Drawing.Image.FromStream(streamReceive);
                    i.Save(ImgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    strResult = Convert.ToBase64String(ImgStream.ToArray());
                }
                else
                {
                    sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                    strResult = sr.ReadToEnd();
                    sr.Close();
                }
                response.Close();
                streamReceive.Close();
               
                string jsessionid = cc.GetCookies(new Uri(strURL))["JSESSIONID"].Value;

                //if (strArgs.Contains("downloadType=mobile"))
                //{
                //    cc = null;
                //    cc = new CookieContainer();
                //}
                return jsessionid+"|" + strResult;
            }
            catch (Exception ex)
            {
                //return string.Empty;
                throw new Exception(ex.Message);
                //File.AppendAllText(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\MMerror.log", DateTime.Now.ToString() + "  " +strURL+","+ ex.Message + "\r\n");
                //System.Windows.Forms.MessageBox.Show("出现异常："+ex.Message);
            }
            
        }


        string configpath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\MMconfig.xml";
        /// <summary>
        /// 获取xml配置文件
        /// </summary>
        /// <param name="TagName">节点名称</param>
        /// <returns>节点中的文本</returns>
        public string GetConfigValue(string TagName)
        {
            //string configpath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\MMconfig.xml";
            XmlDocument xmlconfig = new XmlDocument();
            xmlconfig.Load(configpath);
            return xmlconfig.DocumentElement.SelectSingleNode(TagName).InnerText;
        }
        /// <summary>
        /// 获取 app.config配置文件 
        /// </summary>
        /// <param name="TagName"></param>
        /// <returns></returns>
        public string GetConfigValue2(string TagName)
        {
            return "";// ConfigurationManager.AppSettings[TagName].ToString();
        }
        /// 修改XML配置文件
        /// </summary>
        /// <param name="AppKey">key</param>
        /// <param name="AppValue">value</param>
        public void SetConfigValue(string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(configpath);
            xDoc.DocumentElement.SelectSingleNode(AppKey).InnerText = AppValue; 
            xDoc.Save(configpath); 
        }
        /// 设置app.config中的某个key的value.
        /// </summary>
        /// <param name="AppKey">key</param>
        /// <param name="AppValue">value</param>
        public void SetConfigValue2(string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();

            //此处配置文件在程序目录下
            xDoc.Load(Application.ExecutablePath+".config");
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("value", AppValue);
            }
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(Application.ExecutablePath + ".config");
        }
        
        /**/
        /// <summary>
        /// 功能描述：在PostLogin成功登录后记录下Headers中的cookie，然后获取此网站上其他页面的内容
        /// </summary>
        /// <param name="strURL">获取网站的某页面的地址</param>
        /// <param name="strReferer">引用的地址</param>
        /// <returns>返回页面内容</returns>
        public string GetPage(string strURL, string strReferer, string code)
        {
            return GetPage(strURL, strReferer, code, string.Empty);
        }
        public string GetPage(string strURL, string strReferer, string code, string contentType)
        {
            string strResult = "";
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
            myHttpWebRequest.AllowAutoRedirect = true;
            myHttpWebRequest.KeepAlive = false;
            myHttpWebRequest.Accept = "*/*";
            myHttpWebRequest.Referer = strReferer;
            myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
            if (string.IsNullOrEmpty(contentType))
            {
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            }
            else
            {
                myHttpWebRequest.ContentType = contentType;
            }
            myHttpWebRequest.Method = "GET";
            if (myHttpWebRequest.CookieContainer == null)
            {
                myHttpWebRequest.CookieContainer = new CookieContainer();
            }
            if (this.CookieHeader.Length > 0)
            {
                myHttpWebRequest.Headers.Add("cookie:" + this.CookieHeader);
                myHttpWebRequest.CookieContainer.SetCookies(new Uri(strURL), this.CookieHeader);
            }

            HttpWebResponse response = null;
            System.IO.StreamReader sr = null;
            response = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream streamReceive;
            string gzip = response.ContentEncoding;
            if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
            {
                streamReceive = response.GetResponseStream();
            }
            else
            {
                streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
            }
            sr = new System.IO.StreamReader(streamReceive, Encoding.GetEncoding(code));
            if (response.ContentLength > 1)
            {
                strResult = sr.ReadToEnd();
            }
            else
            {
                char[] buffer = new char[256];
                int count = 0;
                StringBuilder sb = new StringBuilder();
                while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                {
                    sb.Append(new string(buffer));
                }
                strResult = sb.ToString();
            }
            sr.Close();
            response.Close();
            return strResult;
        }
        /// <summary>
        /// MD5文件加密
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string EncryptFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("加密失败,错误信息:" + ex.Message);
            }
        }
        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public static string Encrypt(string strPwd)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列 
                byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值 
                md5.Clear();
                string str = "";
                for (int i = 0; i < md5data.Length; i++)
                {
                    str += md5data[i].ToString("x").PadLeft(2, '0');
                }
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        } 
    }
}