using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ICH.Core.Net
{
    public static class HttpExtension
    {
        /// <summary>
        /// 把请求文本参数转换为流数据写入请求
        /// </summary>
        /// <param name="req">HTTP请求对象</param>
        /// <param name="charset">字符集</param>
        /// <param name="parameters">请求文本参数</param>
        /// <returns>HTTP请求对象</returns>
        public static HttpWebRequest GetRequestStream(this HttpWebRequest req, string charset, string parameters)
        {
            byte[] postData = Encoding.GetEncoding(charset).GetBytes(parameters);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();
            return req;
        }
        /// <summary>
        /// 把请求文本参数转换为流数据写入请求
        /// </summary>
        /// <param name="req">HTTP请求对象</param>
        /// <param name="charset">字符集</param>
        /// <param name="parameters">请求文本参数</param>
        /// <returns>HTTP请求对象</returns>
        public static HttpWebRequest GetRequestStream(this HttpWebRequest req, string charset, IDictionary<string, string> parameters)
        {
            byte[] postData = Encoding.GetEncoding(charset).GetBytes(HttpUtil.BuildQuery(parameters, charset));
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();
            return req;
        }
        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static string GetResponseAsString(this HttpWebResponse rsp, Encoding encoding)
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
                reader?.Close();
                stream?.Close();
                rsp?.Close();
            }
        }
    }
}
