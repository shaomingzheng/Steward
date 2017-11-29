using System.Collections.Generic;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Steward.Domain.Models;
using ICH.Sugar;

namespace ICH.Steward.Domain.Repositories
{
    public class AppRepository : BaseRepository<Wiki_AppEntity>, IAppRepository
    {
        public AppRepository(SugarFactory sugarFactory,List<SugarOptions> options) : base(sugarFactory,options)
        {
        }
    }
}
