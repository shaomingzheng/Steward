using System;
using System.Collections.Generic;
using ICH.Core.Net;
using ICH.Core.Regular;
using ICH.Core.Security;
using ICH.Sugar.Conn;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SqlSugar;

namespace ICH.Sugar
{
    /// <summary>
    /// SqlSugar工厂
    /// </summary>
    public class SugarFactory
    {
        private IMemoryCache _memoryCache;
        private DBContext _context;
        public SugarFactory(DBContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connectionString">连接字符串或数据库KEY</param>
        /// <param name="providerName">数据库类型</param>
        /// <returns></returns>
        public SqlSugarClient GetInstance(string connectionString,string providerName)
        {
            if (!Regular.IsGuidByParse(connectionString))
                return  new SqlSugarClient(new ConnectionConfig { ConnectionString = connectionString, DbType = Types[providerName], IsAutoCloseConnection = true });
            var entity = GetConnectionManage(connectionString);
            SqlSugarClient db;
            string connectionStr;
            //判断当前主链接是否可用
            try
            {
                connectionStr = entity.PkConnection;
                db = new SqlSugarClient(new ConnectionConfig { ConnectionString = connectionStr, DbType = Types[entity.DBType], IsAutoCloseConnection = true });
                db.Ado.GetScalar("select 1+1");
                return db;
            }
            catch (Exception)
            {
                //说明主服务器不可用
                connectionStr = entity.SpareConnection;
                db = new SqlSugarClient(new ConnectionConfig { ConnectionString = connectionStr, DbType = Types[entity.DBType], IsAutoCloseConnection = true });
                db.Ado.GetScalar("select 1+1");
                return db;
            }
            
        }

        private static readonly Dictionary<string, DbType> Types = new Dictionary<string, DbType>
        {
            {"MySql.Data.MySqlClient",DbType.MySql},
            {"System.Data.SqlClient",DbType.SqlServer},
            {"System.Data.SQLite",DbType.Sqlite},
            {"System.Data.OracleClient",DbType.Oracle},
            {"MySql",DbType.MySql},
            {"SqlServer",DbType.SqlServer},
            {"Sqlite",DbType.Sqlite},
            {"Oracle",DbType.Oracle},
        };

        public ConnectionManage GetConnectionManage(string dbKey)
        {
            var entity = _memoryCache.Get<ConnectionManage>(dbKey);
            if (entity != null)
            {
                return entity;
            }
            var ss = string.Format("key={0}&entityKey={1}", _context.APIKey, dbKey);
            var result = HttpMethods.PostExecuteResult(_context.DBUrl, "POST", ss);
            var data = JsonConvert.DeserializeObject<dynamic>(result);
            entity = data;
            if (!string.IsNullOrEmpty(entity.PkConnection))
                entity.PkConnection = DES.Decrypt(entity.PkConnection, entity.BasicsId);
            if (!string.IsNullOrEmpty(entity.SpareConnection))
                entity.SpareConnection = DES.Decrypt(entity.SpareConnection, entity.BasicsId);
            _memoryCache.Set(dbKey, entity, TimeSpan.FromSeconds(300));
            return entity;
        }
    }
}
