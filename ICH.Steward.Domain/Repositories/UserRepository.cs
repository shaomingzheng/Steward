using System.Collections.Generic;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Steward.Domain.Models;
using ICH.Sugar;

namespace ICH.Steward.Domain.Repositories
{
    /// <summary>
    /// 用户仓库
    /// </summary>
    public class UserRepository : BaseRepository<Sys_UserEntity>, IUserRepository
    {
        public UserRepository(SugarFactory sugarFactory,List<SugarOptions> options) : base(sugarFactory,options)
        {
        }
    }
}
