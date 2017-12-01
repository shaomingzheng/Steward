namespace ICH.Core.Net
{
    public class HttpMethods
    {
        #region Get
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpGet(string url, string param = null)
        {
            return WebUtils.DoGet(url, param);
        }
        #endregion
        #region POST
        /// <summary>
        /// HTTP POST方式请求数据
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="param">POST的数据</param>
        /// <returns></returns>
        public static string HttpPost(string url, string param = null)
        {
           return WebUtils.DoPost(url, param);
        }
        #endregion

        #region Put
        /// <summary>
        /// HTTP PUT方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpPut(string url, string param = null)
        {
            return WebUtils.DoPut(url, param);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// HTTP DELETE方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpDelete(string url, string param = null)
        {
            return WebUtils.DoDelete(url, param);
        }
        #endregion
    }
}
