using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Hayaa.ServicePlatform.Client.Util
{
    /// <summary>
    /// http请求助手
    /// </summary>
    internal class HttpRequestHelper
    {
        /// <summary>
        /// 采用post方式发送json参数并获取json格式返回数据
        /// 默认超时时间90秒
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="jsonParameter">json格式参数</param>
        /// <returns>正常则返回json的字符串数据，异常返回null</returns>
        internal string TransactionByJson(string requestUrl, string jsonParameter, int timeOut = 90000)
        {
            if (!requestUrl.Contains("http"))
                requestUrl = string.Format("http://{0}", requestUrl);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonParameter);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            string result = null;
            try
            {
                Stream reqstream = request.GetRequestStream();
                reqstream.Write(bytes, 0, bytes.Length);
                request.Timeout = timeOut;
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                result = streamReader.ReadToEnd();
                streamReceive.Dispose();
                streamReader.Dispose();
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
        /// <summary>
        /// 常规形式的HTTP请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="urlParam">请求参数</param>
        /// <param name="method">请求类型post、get</param>
        /// <param name="contentType">协议数据类型</param>
        /// <returns>正常则返回响应文本数据，异常返回null</returns>
        internal string Transaction(string requestUrl, Dictionary<string, string> urlParam, string method = "post", string contentType = "application/x-www-form-urlencoded")
        {
            if (!requestUrl.Contains("http"))
                requestUrl = string.Format("http://{0}", requestUrl);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            Encoding encoding = Encoding.UTF8;
            StringBuilder param = new StringBuilder("&");
            if (urlParam != null)
            {
                foreach (var kv in urlParam)
                {
                    param.Append(string.Format("{0}={1}&", kv.Key, kv.Value));
                }
            }
            byte[] bs = Encoding.ASCII.GetBytes(param.ToString().TrimEnd('&'));
            string responseData = String.Empty;
            req.Method = method;
            req.ContentType = contentType;
            req.ContentLength = bs.Length;
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                responseData = null;
            }
            return responseData;
        }
    }
}
