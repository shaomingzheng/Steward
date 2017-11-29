using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ICH.Core.Net
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        private static int _timeout = 20000;    //请求与响应的超时时间
        private static int _readWriteTimeout = 60000;   //等待读取数据完成的超时时间

        public static string DoPost(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie = null)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(BuildQuery(parameters, charset));
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoPost(string url, string parameters, string charset, CookieContainer cookie = null)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(parameters);
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse) req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return GetResponseAsString((HttpWebResponse)ex.Response, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }

        public static async Task<string> DoPostAsync(string url, string parameters, string charset, CookieContainer cookie = null)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(parameters);
                var reqStream =await req.GetRequestStreamAsync();

                await reqStream.WriteAsync(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse) await req.GetResponseAsync();
                return await GetResponseAsStringAsync(rsp, Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return GetResponseAsString((HttpWebResponse)ex.Response, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoPost(string url, string parameters, string charset, CookieContainer cookie, string referer)
        {
            HttpWebResponse rsp=null;
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded; charset=" + charset;
                req.CookieContainer = cookie;
                req.Referer = referer;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(parameters);
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (WebException)
            {
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
                //return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }

        public static string DoPost(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie, string referer)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;
                req.Referer = referer;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(BuildQuery(parameters, charset));
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoPost(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie, string referer, IDictionary<string, string> headerParams)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", headerParams);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;
                req.Referer = referer;
                byte[] postData = Encoding.GetEncoding(charset).GetBytes(BuildQuery(parameters, charset));
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoPostHeaders(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie)
        {
            try
            {
                HttpWebRequest req = GetWebRequest(url, "POST", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;
                req.AllowAutoRedirect = false;

                byte[] postData = Encoding.GetEncoding(charset).GetBytes(BuildQuery(parameters, charset));
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return rsp.Headers.ToString();
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }

        public static string DoGet(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie = null)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            try
            {
                HttpWebRequest req = GetWebRequest(url, "GET", null);
                req.ContentType = "text/html, application/xhtml+xml, */*";
                req.CookieContainer = cookie;
                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoGet(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie, string referer)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            try
            {
                HttpWebRequest req = GetWebRequest(url, "GET", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;
                req.Referer = referer;

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoGet(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie, IDictionary<string, string> headerParams)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            try
            {
                HttpWebRequest req = GetWebRequest(url, "GET", headerParams);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoGetHeaders(string url, IDictionary<string, string> parameters, string charset, CookieContainer cookie)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            try
            {
                HttpWebRequest req = GetWebRequest(url, "GET", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.CookieContainer = cookie;

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return rsp.Headers.ToString();
            }
            catch (WebException ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }
        public static string DoGetSetCookie(string url, IDictionary<string, string> parameters, string charset, string cookie)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            try
            {
                HttpWebRequest req = GetWebRequest(url, "GET", null);
                req.ContentType = "application/x-www-form-urlencoded;charset=" + charset;
                req.Headers[HttpRequestHeader.Cookie] = cookie;

                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                return GetResponseAsString(rsp, Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return "网络错误:" + ex.Message + "_" + ex.StackTrace;
            }
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { //直接确认，否则打不开
            return true;
        }
        public static HttpWebRequest GetWebRequest(string url, string method, IDictionary<string, string> headerParams)
        {
            HttpWebRequest req;
            if (url.Contains("https"))
            {
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                req = (HttpWebRequest)WebRequest.Create(url);
            }
            if (headerParams != null && headerParams.Count > 0)
            {
                foreach (string key in headerParams.Keys)
                {
                    req.Headers.Add(key, headerParams[key]);
                }
            }
           // req.ServicePoint.Expect100Continue = false;
            req.Method = method;
            req.KeepAlive = true;
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            req.Timeout = _timeout;
            req.ReadWriteTimeout = _readWriteTimeout;

            return req;
        }
        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static async Task<string> GetResponseAsStringAsync(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return await reader.ReadToEndAsync();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public static string BuildGetUrl(string url, IDictionary<string, string> parameters, string charset)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters, charset);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters, charset);
                }
            }
            return url;
        }
        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters, string charset)
        {
            return BuildQuery(parameters, charset, true);
        }
        /// <summary>
        ///  Charge
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string BuildQuery(IDictionary<string, string> parameters, string charset, bool hasParam)
        {
            StringBuilder postData = new StringBuilder();

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();

            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数

                postData.Append(name);
                postData.Append("=");
                if (charset == "")
                    postData.Append(value);
                else
                    postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding(charset)));
                if (hasParam)
                {
                    postData.Append("&");
                }

            }
            return postData.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 校验SPI请求签名，适用于Content-Type为application/x-www-form-urlencoded或multipart/form-data的GET或POST请求
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string SignRequest(IDictionary<string, string> parameters, string secret)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }
            query.Append(secret);

            return query.ToString();
        }
    }
}
