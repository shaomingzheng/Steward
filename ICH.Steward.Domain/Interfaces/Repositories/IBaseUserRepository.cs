using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICH.Steward.Domain.Models;

namespace ICH.Steward.Domain.Interfaces.Repositories
{
    public interface IBaseUserRepository : IBaseRepository<Base_UserEntity>
    {
        Task<bool> BatchSetOpenIdAsync();
    }
}
