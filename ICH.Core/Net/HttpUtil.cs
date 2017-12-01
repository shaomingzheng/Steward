using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace ICH.Core.Net
{
    public static class HttpUtil
    {
        private static int _readWriteTimeout = 60000;   //等待读取数据完成的超时时间
                                                  
        /// <summary>
        /// 组长文本参数
        /// </summary>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="hasParam">是否已有参数</param>
        /// <returns>请求参数字符串</returns>
        public static string BuildQuery(IDictionary<string, string> parameters, string charset, bool hasParam = true)
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
                postData.Append(charset == "" ? value : HttpUtility.UrlEncode(value, Encoding.GetEncoding(charset)));
                if (hasParam)
                {
                    postData.Append("&");
                }

            }
            return postData.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public static string BuildGetUrl(string url,  string parameters)
        {
            if (parameters != null && parameters.Any())
                url = url.Contains("?") ? $"{url}&{parameters}" : $"{url}?{parameters}";
            return url;
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="charset">字符编码</param>
        /// <returns>带参数的GET请求URL</returns>
        public static string BuildGetUrl(string url, IDictionary<string, string> parameters, string charset = "utf-8")
        {
            if (parameters != null && parameters.Any())
                url = url.Contains("?") ? $"{url}&{BuildQuery(parameters, charset)}" : $"{url}?{BuildQuery(parameters, charset)}";
            return url;
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
        /// <summary>
        /// CheckValidationResult方法，返回true
        /// </summary>
        /// <returns></returns>
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { //直接确认，否则打不开
            return true;
        }

        public static HttpWebRequest GetWebRequest(string url, string method, IDictionary<string, string> headerParams=null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null, Action<HttpWebRequest> request=null)
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
            req.Accept = "*/*";
            req.Method = method;
            req.KeepAlive = true;
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            req.Timeout = timeout;
            req.ReadWriteTimeout = _readWriteTimeout;
            req.ContentType = $"application/x-www-form-urlencoded;charset={charset}";
            req.CookieContainer = cookie;
            if (req.Referer != "")
                req.Referer = referer;

            request?.Invoke(req);

            return req;
        }
    }
}
