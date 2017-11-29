using System;
using ICH.Util;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ICH.Sugar.Conn
{
    public class DBContext
    {
        public DBContext()
        {
            
        }
        private IMemoryCache _cache;
        public DBContext(IMemoryCache cache)
        {
            _cache = cache;
        }
        public string DBUrl { get; set; }
        public string APIKey { get; set; }
        public  ConnectionManage GetConnectionManage(string dbKey)
        {
            var entity= _cache.Get<ConnectionManage>(dbKey);
            if (entity != null)
            {
                return entity;
            }
            var ss = string.Format("key={0}&entityKey={1}", APIKey, dbKey);
            var result = HttpMethods.PostExecuteResult(DBUrl, "POST", ss);
            var data = JsonConvert.DeserializeObject<dynamic>(result);
            entity = data;
            if (!string.IsNullOrEmpty(entity.PkConnection))
                entity.PkConnection = DESEncrypt.Decrypt(entity.PkConnection, entity.BasicsId);
            if (!string.IsNullOrEmpty(entity.SpareConnection))
                entity.SpareConnection = DESEncrypt.Decrypt(entity.SpareConnection, entity.BasicsId);
            _cache.Set(dbKey,entity,TimeSpan.FromSeconds(300));
            return entity;
        }
    }
}
