using System;
using SqlSugar;

namespace ICH.Steward.Domain.Models
{
    /// <summary>
    /// 应用信息
    /// </summary>
    [SugarTable("wiki_app")]
    public class Wiki_AppEntity : DomainEntity
    {
        /// <summary>
        /// 应用主键
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        [SugarColumn(ColumnName = "Fullname")]
        public string FullName { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        [SugarColumn(ColumnName = "intro")]
        public string Intro { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        [SugarColumn(ColumnName = "host_url")]
        public string HostUrl { get; set; }
        /// <summary>
        /// logo地址
        /// </summary>
        [SugarColumn(ColumnName = "logo_url")]
        public string LogoUrl { get; set; }
        /// <summary>
        /// 开发者ID
        /// </summary>
        [SugarColumn(ColumnName = "app_id")]
        public string AppId { get; set; }
        /// <summary>
        /// 开发者密码
        /// </summary>
        [SugarColumn(ColumnName = "app_secret")]
        public string AppSecret { get; set; }
        /// <summary>
        /// 注册用户主键
        /// </summary>
        [SugarColumn(ColumnName = "register_userid")]
        public string RegisterUserId { get; set; }
        /// <summary>
        /// 注册用户名称
        /// </summary>
        [SugarColumn(ColumnName = "register_username")]
        public string RegisterUsername { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        [SugarColumn(ColumnName = "register_date")]
        public DateTime? RegisterDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [SugarColumn(ColumnName = "enabledmark")]
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnName = "deletemark")]
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// 企业回调URL
        /// </summary>
        [SugarColumn(ColumnName = "redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
