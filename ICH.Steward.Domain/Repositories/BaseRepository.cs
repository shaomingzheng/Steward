using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using ICH.Data.Sugar;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Sugar;
using ICH.Util.WebControl;
using SqlSugar;

namespace ICH.Steward.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public List<SugarOptions> _options;
        private SugarOptions _option;

        private SugarFactory _sugarFactory;

        public BaseRepository(SugarFactory sugarFactory,List<SugarOptions> options)
        {
            _options = options;
            _option = _options.First();
            _sugarFactory = sugarFactory;
        }

        public BaseRepository(List<SugarOptions> options,string name)
        {
            _options = options;
            _option = _options.Find(c => c.Name == name);
        }

        public Task<bool> AddAsync(T entity)
        {
           return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Insertable(entity)
                .ExecuteCommandIdentityIntoEntityAsync();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
           return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression)
                .CountAsync();
        }
        public Task<bool> DeleteAsync(T entity)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Deleteable(entity).ExecuteCommandHasChangeAsync();
        }

        public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Deleteable(expression).ExecuteCommandHasChangeAsync();
        }

        public Task<bool> UpdateAsync(T entity, bool isNoUpdateNull = true)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Updateable(entity).ExecuteCommandHasChangeAsync();
        }

        public Task<bool> UpdateAsync(List<T> list, bool isNoUpdateNull=true)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Updateable(list).Where(isNoUpdateNull).ExecuteCommandHasChangeAsync();
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().AnyAsync(expression);
        }

        public Task<T> FindEntityAsync(Expression<Func<T, bool>> expression)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().FirstAsync(expression);
        }

        public Task<T> FindEntityAsync(string keyValue)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().In(keyValue).SingleAsync();
        }

        public Task<List<T>> FindListAsync<TParamter>(params TParamter[] pkValues)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().In(pkValues).ToListAsync();
        }

        public Task<List<T>> FindListAsync(Expression<Func<T, bool>> expression)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).ToListAsync();
        }

        public Task<List<T>> FindListAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> select)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(where).Select(select).ToListAsync();
        }

        public Task<List<T>> FindListAsync(Expression<Func<T, bool>> expression, string orderFields)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).OrderBy(orderFields).ToListAsync();
        }

        public Task<List<T>> FindListAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> select, string orderFields)
        {
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(where).Select(select).OrderBy(orderFields).ToListAsync();
        }

        public Task<KeyValuePair<List<T>, int>> FindListAsync(Expression<Func<T, bool>> expression, string orderFields, bool isAsc, int pageSize, int pageIndex)
        {
            orderFields = $"{orderFields} {(isAsc ? "asc" : "desc")}";
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).OrderBy(orderFields).ToPageListAsync(pageIndex, pageSize, 0);
        }

        public Task<KeyValuePair<List<T>, int>> FindListAsync(Expression<Func<T, bool>> expression, Pagination pagination)
        {
            var orderFields = $"{pagination.sidx} {(pagination.sord.ToLower() == "asc" ? "asc" : "desc")}";
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).OrderBy(orderFields).ToPageListAsync(pagination.page, pagination.rows, 0);
        }

        public Task<KeyValuePair<DataTable, int>> FindDataTableAsync(Expression<Func<T, bool>> expression, string orderFields, bool isAsc, int pageSize, int pageIndex)
        {
            orderFields = $"{orderFields} {(isAsc ? "asc" : "desc")}";
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).OrderBy(orderFields).ToDataTablePageAsync(pageIndex, pageSize, 0);
        }

        public Task<KeyValuePair<DataTable, int>> FindDataTableAsync(Expression<Func<T, bool>> expression, Pagination pagination)
        {
            var orderFields = $"{pagination.sidx} {(pagination.sord.ToLower() == "asc" ? "asc" : "desc")}";
            return _sugarFactory.GetInstance(_option.ConnectionString, _option.ProviderName).Queryable<T>().Where(expression).OrderBy(orderFields).ToDataTablePageAsync(pagination.page, pagination.rows, 0);
        }
    }
}
