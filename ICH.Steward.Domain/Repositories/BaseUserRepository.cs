using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICH.Steward.Domain.DEncrypt;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Steward.Domain.Models;
using ICH.Sugar;

namespace ICH.Steward.Domain.Repositories
{
    /// <summary>
    /// 用户仓库
    /// </summary>
    public class BaseUserRepository : BaseRepository<Base_UserEntity>, IBaseUserRepository
    {
        private SugarFactory _sugarFactory;
        public BaseUserRepository(SugarFactory sugarFactory,List<SugarOptions> options) : base(sugarFactory,options)
        {
            _sugarFactory = sugarFactory;
        }

        public Task<bool> BatchSetOpenIdAsync()
        {
            Task<bool> result = new Task<bool>(() =>
            {
                var execute = false;
                var client = _sugarFactory.GetInstance(_options.First().ConnectionString, _options.First().ProviderName);
                client.Ado.UseTran(() =>
                {
                    var list = client.Queryable<Base_UserEntity>().Select(c => new Base_UserEntity { UserId = c.UserId }).ToList();
                    foreach (var data in list)
                    {
                        data.OpenId = Encrypt.Md5($"{data.UserId.ToUpper()}{"fl7236a0c8e83fa133".ToUpper()}");
                    }
                    execute= client.Updateable(list).Where(true).ExecuteCommandHasChange();
                });
                return execute;
                
            });
            result.Start();

        
            return result;
        }

        public Task<bool> InsertAsync(Base_UserEntity entity)
        {
            return Task.FromResult(_sugarFactory.GetInstance(_options.First().ConnectionString, _options.First().ProviderName).Insertable(entity)
                .ExecuteCommandIdentityIntoEntity());
        }

        public Task<bool> Insert3Async(Base_UserEntity entity)
        {
            Task<bool> result = new Task<bool>(() =>
            {
                return _sugarFactory.GetInstance(_options.First().ConnectionString, _options.First().ProviderName).Insertable(entity)
                    .ExecuteCommandIdentityIntoEntity();
            });
            result.Start();
            return result;
        }

        public Task<bool> Insert2Async(Base_UserEntity entity)
        {
            return _sugarFactory.GetInstance(_options.First().ConnectionString, _options.First().ProviderName).Insertable(entity)
                .ExecuteCommandIdentityIntoEntityAsync();
        }
    }
}
