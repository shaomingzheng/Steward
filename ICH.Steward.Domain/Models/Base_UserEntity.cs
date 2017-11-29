using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICH.Steward.Domain.Models
{
    [SugarTable("Base_User")]
    public class Base_UserEntity:DomainEntity
    {
        /// <summary>
        ///     UserId
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }

        /// <summary>
        ///     EnCode
        /// </summary>
        /// <returns></returns>
        public string EnCode { get; set; }

        /// <summary>
        ///     Account
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }

        /// <summary>
        ///     Secretkey
        /// </summary>
        /// <returns></returns>
        public string Secretkey { get; set; }

        /// <summary>
        ///     RealName
        /// </summary>
        /// <returns></returns>
        public string RealName { get; set; }

        /// <summary>
        ///     NickName
        /// </summary>
        /// <returns></returns>
        public string NickName { get; set; }

        /// <summary>
        ///     HeadIcon
        /// </summary>
        /// <returns></returns>
        public string HeadIcon { get; set; }

        /// <summary>
        ///     QuickQuery
        /// </summary>
        /// <returns></returns>
        public string QuickQuery { get; set; }

        /// <summary>
        ///     SimpleSpelling
        /// </summary>
        /// <returns></returns>
        public string SimpleSpelling { get; set; }

        /// <summary>
        ///     Gender
        /// </summary>
        /// <returns></returns>
        public int? Gender { get; set; }

        /// <summary>
        ///     Birthday
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Mobile
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }

        /// <summary>
        ///     Telephone
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }

        /// <summary>
        ///     OICQ
        /// </summary>
        /// <returns></returns>
        public string OICQ { get; set; }

        /// <summary>
        ///     WeChat
        /// </summary>
        /// <returns></returns>
        public string WeChat { get; set; }

        /// <summary>
        ///     MSN
        /// </summary>
        /// <returns></returns>
        public string MSN { get; set; }

        /// <summary>
        ///     ManagerId
        /// </summary>
        /// <returns></returns>
        public string ManagerId { get; set; }

        /// <summary>
        ///     Manager
        /// </summary>
        /// <returns></returns>
        public string Manager { get; set; }

        /// <summary>
        ///     OrganizeId
        /// </summary>
        /// <returns></returns>
        public string OrganizeId { get; set; }

        /// <summary>
        ///     DepartmentId
        /// </summary>
        /// <returns></returns>
        public string DepartmentId { get; set; }

        /// <summary>
        ///     RoleId
        /// </summary>
        /// <returns></returns>
        public string RoleId { get; set; }

        /// <summary>
        ///     DutyId
        /// </summary>
        /// <returns></returns>
        public string DutyId { get; set; }

        /// <summary>
        ///     DutyName
        /// </summary>
        /// <returns></returns>
        public string DutyName { get; set; }

        /// <summary>
        ///     学历主键
        /// </summary>
        /// <returns></returns>
        public string DegreeId { get; set; }

        /// <summary>
        ///     学历名称
        /// </summary>
        /// <returns></returns>
        public string DegreeName { get; set; }

        /// <summary>
        ///     PostId
        /// </summary>
        /// <returns></returns>
        public string PostId { get; set; }

        /// <summary>
        ///     PostName
        /// </summary>
        /// <returns></returns>
        public string PostName { get; set; }

        /// <summary>
        ///     WorkGroupId
        /// </summary>
        /// <returns></returns>
        public string WorkGroupId { get; set; }

        /// <summary>
        ///     SecurityLevel
        /// </summary>
        /// <returns></returns>
        public int? SecurityLevel { get; set; }

        /// <summary>
        ///     UserOnLine
        /// </summary>
        /// <returns></returns>
        public int? UserOnLine { get; set; }

        /// <summary>
        ///     OpenId
        /// </summary>
        /// <returns></returns>
        public string OpenId { get; set; }

        /// <summary>
        ///     Question
        /// </summary>
        /// <returns></returns>
        public string Question { get; set; }

        /// <summary>
        ///     AnswerQuestion
        /// </summary>
        /// <returns></returns>
        public string AnswerQuestion { get; set; }

        /// <summary>
        ///     CheckOnLine
        /// </summary>
        /// <returns></returns>
        public int? CheckOnLine { get; set; }

        /// <summary>
        ///     AllowStartTime
        /// </summary>
        /// <returns></returns>
        public DateTime? AllowStartTime { get; set; }

        /// <summary>
        ///     AllowEndTime
        /// </summary>
        /// <returns></returns>
        public DateTime? AllowEndTime { get; set; }

        /// <summary>
        ///     LockStartDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LockStartDate { get; set; }

        /// <summary>
        ///     LockEndDate
        /// </summary>
        /// <returns></returns>
        public DateTime? LockEndDate { get; set; }

        /// <summary>
        ///     FirstVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? FirstVisit { get; set; }

        /// <summary>
        ///     PreviousVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? PreviousVisit { get; set; }

        /// <summary>
        ///     LastVisit
        /// </summary>
        /// <returns></returns>
        public DateTime? LastVisit { get; set; }

        /// <summary>
        ///     LogOnCount
        /// </summary>
        /// <returns></returns>
        public int? LogOnCount { get; set; }

        /// <summary>
        ///     籍贯主键
        /// </summary>
        /// <returns></returns>
        public int? HometownId { get; set; }

        /// <summary>
        ///     籍贯名称
        /// </summary>
        /// <returns></returns>
        public string HometownName { get; set; }

        /// <summary>
        ///     入职日期
        /// </summary>
        /// <returns></returns>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        ///     身份证号码
        /// </summary>
        /// <returns></returns>
        public string IDCard { get; set; }

        /// <summary>
        ///     家庭住址
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }

        /// <summary>
        ///     现住址
        /// </summary>
        /// <returns></returns>
        public string CurrentAddress { get; set; }

        /// <summary>
        ///     离职日期
        /// </summary>
        /// <returns></returns>
        public DateTime? LeaveDate { get; set; }

        /// <summary>
        ///     工作QQ
        /// </summary>
        /// <returns></returns>
        public string WorkOICQ { get; set; }

        /// <summary>
        ///     最后一次访问IP
        /// </summary>
        /// <returns></returns>
        public string LastVisitIP { get; set; }

        /// <summary>
        ///     最后一次访问IP地址
        /// </summary>
        /// <returns></returns>
        public string LastVisitIPAddress { get; set; }

        /// <summary>
        ///     毕业学校
        /// </summary>
        /// <returns></returns>
        public string School { get; set; }

        /// <summary>
        ///     Specialty
        /// </summary>
        /// <returns></returns>
        public string Specialty { get; set; }

        /// <summary>
        ///     如意令序列号
        /// </summary>
        /// <returns></returns>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     转正日期
        /// </summary>
        /// <returns></returns>
        public DateTime? PositiveDates { get; set; }

        /// <summary>
        ///     LeavingReason
        /// </summary>
        /// <returns></returns>
        public string LeavingReason { get; set; }

        /// <summary>
        ///     用户状态0-离职1-在职2-试用
        /// </summary>
        /// <returns></returns>
        public int? UserStatus { get; set; }

        /// <summary>
        ///     紧急联络人
        /// </summary>
        /// <returns></returns>
        public string EmergencyContactPerson { get; set; }

        /// <summary>
        ///     紧急联络人电话
        /// </summary>
        /// <returns></returns>
        public string EmergencyContactNumber { get; set; }

        /// <summary>
        ///     合同到期时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ContractExpiryDate { get; set; }

        /// <summary>
        /// 户口类型
        /// </summary>
        public string ResidenceType { get; set; }

        /// <summary>
        ///     SortCode
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }

        /// <summary>
        ///     DeleteMark
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }

        /// <summary>
        ///     EnabledMark
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }

        /// <summary>
        ///     Description
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
        ///     CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///     CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }

        /// <summary>
        ///     CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }

        /// <summary>
        ///     ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///     ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }

        /// <summary>
        ///     ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        /// <summary>
        /// 社保状态
        /// </summary>
        public int? Social { get; set; }
        /// <summary>
        /// 社保缴纳时间
        /// </summary>
        public DateTime? PaySocialDate { get; set; }
        /// <summary>
        /// 公积金状态
        /// </summary>
        public int? Accumulation { get; set; }
        /// <summary>
        /// 公积金缴纳时间
        /// </summary>
        public DateTime? PayAccumulationDate { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int? Marriage { get; set; }
    }
}
