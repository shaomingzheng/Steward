using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ICH.Core.Net
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        #region  HTTP GET

        /// <summary>
        /// HTTP GET请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, string parameters, IDictionary<string, string> headerParams = null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters), "GET", headerParams, referer, charset, timeout, cookie).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }

        /// <summary>
        /// HTTP GET请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, IDictionary<string, string> parameters, IDictionary<string, string> headerParams = null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters, charset), "GET", headerParams, referer, charset, timeout, cookie).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP GET请求（返回Header信息）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoGetHeaders(string url, IDictionary<string, string> parameters, IDictionary<string, string> headerParams = null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters, charset), "GET", headerParams, referer, charset, timeout, cookie).GetResponse()).Headers.ToString();
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        ///  HTTP GET请求（将Cookie放置到Header中）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoGetSetCookie(string url, IDictionary<string, string> parameters, string charset = "utf-8", int timeout = 20000, string cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters, charset), "GET", null, "", charset, timeout, null, t => t.Headers[HttpRequestHeader.Cookie] = cookie).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        #endregion

        #region HTTP POST
        /// <summary>
        /// HTTP POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPost(string url, string parameters, string referer = "", IDictionary<string, string> headerParams = null, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(url, "POST", headerParams, referer, charset, timeout, cookie)
                        .GetRequestStream(charset, parameters).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPost(string url, IDictionary<string, string> parameters, string referer = "", IDictionary<string, string> headerParams = null, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(url, "POST", headerParams, referer, charset, timeout, cookie)
                        .GetRequestStream(charset, parameters).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }

        /// <summary>
        /// HTTP POST请求（HTTP异常仍然返回Response信息）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPostGetResponse(string url, string parameters, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = (HttpWebResponse)HttpUtil.GetWebRequest(url, "POST", null, "", charset, timeout, cookie)
                    .GetRequestStream(charset, parameters).GetResponse();
                return webResponse.GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException)
            {
                return webResponse.GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP POST请求（返回Header信息）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPostHeaders(string url, IDictionary<string, string> parameters, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(url, "POST", null, "", charset, timeout, cookie, c => c.AllowAutoRedirect = false)
                    .GetRequestStream(charset, parameters).GetResponse()).Headers.ToString();
            }
            catch (Exception ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP POST请求（执行带文件上传）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="fileParams">请求文件参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public string DoPost(string url, IDictionary<string, string> parameters, IDictionary<string, FileItem> fileParams, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            // 如果没有文件参数，则走普通POST请求
            if (fileParams == null || fileParams.Count == 0)
            {
                return DoPost(url, parameters);
            }

            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线

            HttpWebRequest req = HttpUtil.GetWebRequest(url, "POST", null, referer, charset, timeout, cookie);
            req.ContentType = $"multipart/form-data;charset={charset};boundary={boundary}";

            System.IO.Stream reqStream = req.GetRequestStream();
            byte[] itemBoundaryBytes = Encoding.GetEncoding(charset).GetBytes(string.Format("\r\n--{0}\r\n", boundary));
            byte[] endBoundaryBytes = Encoding.GetEncoding(charset).GetBytes(string.Format("\r\n--{0}--\r\n", boundary));

            // 组装文本请求参数
            string textTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
            IEnumerator<KeyValuePair<string, string>> textEnum = parameters.GetEnumerator();
            while (textEnum.MoveNext())
            {
                string name = textEnum.Current.Key;
                string value = textEnum.Current.Value;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    string textEntry = string.Format(textTemplate, textEnum.Current.Key, textEnum.Current.Value);
                    byte[] itemBytes = Encoding.UTF8.GetBytes(textEntry);
                    reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    reqStream.Write(itemBytes, 0, itemBytes.Length);
                }
            }

            // 组装文件请求参数
            string fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
            IEnumerator<KeyValuePair<string, FileItem>> fileEnum = fileParams.GetEnumerator();
            while (fileEnum.MoveNext())
            {
                string key = fileEnum.Current.Key;
                FileItem fileItem = fileEnum.Current.Value;
                string fileEntry = string.Format(fileTemplate, key, fileItem.GetFileName(), fileItem.GetMimeType());
                byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
                reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                reqStream.Write(itemBytes, 0, itemBytes.Length);

                byte[] fileBytes = fileItem.GetContent();
                reqStream.Write(fileBytes, 0, fileBytes.Length);
            }

            reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            reqStream.Close();

            return ((HttpWebResponse)req.GetResponse()).GetResponseAsString(Encoding.GetEncoding(charset));
        }
        #endregion

        #region HTTP PUT
        /// <summary>
        /// HTTP PUT请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPut(string url, string parameters, string referer = "", IDictionary<string, string> headerParams = null, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(url, "PUT", headerParams, referer, charset, timeout, cookie)
                        .GetRequestStream(charset, parameters).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP PUT请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoPut(string url, IDictionary<string, string> parameters, string referer = "", IDictionary<string, string> headerParams = null, string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(url, "PUT", headerParams, referer, charset, timeout, cookie)
                        .GetRequestStream(charset, parameters).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        #endregion

        #region HTTP DELETE
        /// <summary>
        /// HTTP GET请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoDelete(string url, string parameters, IDictionary<string, string> headerParams = null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters), "DELETE", headerParams, referer, charset, timeout, cookie).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        /// <summary>
        /// HTTP DELETE请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求文本参数</param>
        /// <param name="headerParams">请求头文本参数</param>
        /// <param name="referer">请求来源</param>
        /// <param name="charset">字符集</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="cookie">Cookies</param>
        /// <returns>HTTP响应</returns>
        public static string DoDelete(string url, IDictionary<string, string> parameters, IDictionary<string, string> headerParams = null, string referer = "", string charset = "utf-8", int timeout = 20000, CookieContainer cookie = null)
        {
            try
            {
                return ((HttpWebResponse)HttpUtil.GetWebRequest(HttpUtil.BuildGetUrl(url, parameters, charset), "DELETE", headerParams, referer, charset, timeout, cookie).GetResponse())
                    .GetResponseAsString(Encoding.GetEncoding(charset));
            }
            catch (WebException ex)
            {
                return $"网络错误：{ex.Message}_{ex.StackTrace}";
            }
        }
        #endregion
    }
}
