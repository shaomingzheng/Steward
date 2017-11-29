using System;
using SqlSugar;

namespace ICH.Steward.Domain.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("sys_user")]
    public class Sys_UserEntity : DomainEntity
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "username")]
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(ColumnName = "cellphone")]
        public string CellPhone { get; set; }
        /// <summary>
        /// 账号类型-1:主账号，2：子账号
        /// </summary>
        [SugarColumn(ColumnName = "account_type")]
        public int? AccountType { get; set; }
        /// <summary>
        /// 最后一次登录IP地址
        /// </summary>
        [SugarColumn(ColumnName = "last_login_ip")]
        public string LastLoginIp { get; set; }
        ///// <summary>
        ///// 账号是否已激活
        ///// </summary>
        //[SugarColumn(ColumnName = "isactived")]
        //public bool? IsActived { get; set; }
        /// <summary>
        /// 个人头像
        /// </summary>
        [SugarColumn(ColumnName = "figureurl")]
        public string FigureUrl { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; }
        /// <summary>
        /// 账号是否被锁定
        /// </summary>
        [SugarColumn(ColumnName = "locked")]
        public bool? Locked { get; set; }
        /// <summary> 
        /// 用户密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// 加密盐
        /// </summary>
        [SugarColumn(ColumnName = "salt")]
        public string Salt { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "sex")]
        public int Sex { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        [SugarColumn(ColumnName = "last_login_time")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        [SugarColumn(ColumnName = "login_count")]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 登录错误次数
        /// </summary>
        [SugarColumn(ColumnName = "login_error_count")]
        public int? LoginErrorCount { get; set; }
        /// <summary>
        /// 最后一次尝试登录时间
        /// </summary>
        [SugarColumn(ColumnName = "last_try_login_time")]
        public DateTime? LastTryLoginTime { get; set; }
        /// <summary>
        /// 注册IP
        /// </summary>
        [SugarColumn(ColumnName = "register_ip")]
        public string RegisterIp { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [SugarColumn(ColumnName = "register_time")]
        public DateTime? RegisterTime { get; set; }
        /// <summary>
        /// 注册来源ID
        /// </summary>
        [SugarColumn(ColumnName = "register_source_id")]
        public string RegisterSourceId { get; set; }
        /// <summary>
        /// 注册来源
        /// </summary>
        [SugarColumn(ColumnName = "register_source_name")]
        public string RegisterSourceName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [SugarColumn(ColumnName = "enabled_mark")]
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 企业标识
        /// </summary>
        [SugarColumn(ColumnName = "corpid")]
        public int? CorpId { get; set; }
        /// <summary>
        /// 主账号主键
        /// </summary>
        [SugarColumn(ColumnName = "master_id")]
        public string MasterId { get; set; }
        /// <summary>
        /// 身份认证外键
        /// </summary>
        [SugarColumn(ColumnName = "authentication_id")]
        public string AuthenticationId { get; set; }
        /// <summary>
        /// 身份认证状态
        /// </summary>
        [SugarColumn(ColumnName = "authentication_status")]
        public string AuthenticationStatus { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [SugarColumn(ColumnName = "actived")]
        public bool? Actived { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [SugarColumn(ColumnName = "birthday")]
        public DateTime? Birthday { get; set; }
    }
}
