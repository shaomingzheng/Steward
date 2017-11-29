using System;
using System.Collections.Generic;
using ICH.Core.Regular;
using ICH.Sugar.Conn;
using SqlSugar;

namespace ICH.Sugar
{
    /// <summary>
    /// SqlSugar工厂
    /// </summary>
    public class SugarFactory
    {
        private DBContext _context;
        public SugarFactory(DBContext context)
        {
            _context = context;
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
            var entity = _context.GetConnectionManage(connectionString);
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
    }
}
