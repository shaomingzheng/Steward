using System.Collections.Generic;

namespace ICH.Core.Web
{
    #region
    public class ResponseResult
    {
        /// <summary>
        /// 单数据对象的返回格式
        /// </summary>
        /// <returns></returns>
        public static dynamic Execute()
        {
            return Execute(new object());
        }

        /// <summary>
        /// 单数据对象的返回格式
        /// </summary>
        /// <param name="code">业务返回码</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        public static dynamic Execute(string code, string message)
        {
            return Execute(new object(), code,message );
        }

        /// <summary>
        /// 单数据对象的返回格式
        /// </summary>
        /// <param name="code">业务返回码</param>
        /// <param name="message">返回信息</param>
        /// <param name="data">业务实体</param>
        /// <returns></returns>
        public static dynamic Execute(dynamic data, string code = "0", string message = "ok")
        {
            return new { data, code, message };
        }

        ///// <summary>
        ///// 单数据对象的返回格式
        ///// </summary>
        ///// <typeparam name="T">业务实体类型</typeparam>
        ///// <param name="code">业务返回码</param>
        ///// <param name="message">返回信息</param>
        ///// <param name="data">业务实体</param>
        ///// <returns></returns>
        //public static dynamic Execute<T>(T data, string code = "0", string message = "ok") where T : class
        //{
        //    return new { data, code, message };
        //}


        ///// <summary>
        ///// 多数据对象的返回格式（不带分页）
        ///// </summary>
        ///// <typeparam name="T">业务实体类型</typeparam>
        ///// <param name="code">返回码</param>
        ///// <param name="message">返回信息</param>
        ///// <param name="data">业务实体列表</param>
        ///// <returns></returns>
        //public static dynamic Execute<T>( IEnumerable<T> data,string code = "0", string message = "ok") where T : class
        //{
        //    return new { data, code, message,  };
        //}

        /// <summary>
        /// 多数据带分页的返回格式
        /// </summary>
        /// <typeparam name="T">业务实体类型</typeparam>
        /// <param name="code">返回码</param>
        /// <param name="message">返回信息</param>
        /// <param name="pagination">前端分页控件实体</param>
        /// <param name="list">业务实体列表</param>
        /// <returns></returns>
        public static dynamic Execute<T>(Pagination pagination, IEnumerable<T> list,string code="0", string message="ok") where T : class
        {
            //const int total = 0;
            return new
            {
                data = new { list, total = pagination.records, current = pagination.page, page_size = pagination.rows,  page_total = pagination.total },
                code,
                message
            };
        }

    }
    #endregion
}
