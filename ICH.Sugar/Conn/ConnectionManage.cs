using System;

namespace ICH.Sugar.Conn
{
    [Serializable]
    public class ConnectionManage
    {
        #region 成员
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 应用id
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 账号id
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// 数据库id
        /// </summary>
        public string BasicsId { get; set; }
        /// <summary>
        /// 主地址连接字符串
        /// </summary>
        public string PkConnection { get; set; }
        /// <summary>
        /// 备地址连接字符串
        /// </summary>
        public string SpareConnection { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DBType { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        public string DBVersion { get; set; }
        /// <summary>
        /// 配置人
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string EditUserId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? EditDateTime { get; set; }
        #endregion

    }
}
