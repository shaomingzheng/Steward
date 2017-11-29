using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ICH.Util.WebControl;
using SqlSugar;

namespace ICH.Steward.Domain.Interfaces.Repositories
{
    /// <summary>
    /// 接口基类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        Task<bool> AddAsync(T entity);
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns>记录数</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isNoUpdateNull">不更新Null</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(T entity, bool isNoUpdateNull = true);
        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isNoUpdateNull">不更新Null</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(List<T> entity, bool isNoUpdateNull = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        Task<bool> DeleteAsync(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns>是否成功</returns>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns>布尔值</returns>
        Task<bool> ExistAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Task<T> FindEntityAsync(string keyValue);
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <typeparam name="TParamter"></typeparam>
        /// <param name="pkValues">主键集合</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync<TParamter>(params TParamter[] pkValues);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns>布尔值</returns>
        Task<T> FindEntityAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="where">where查询表达式</param>
        /// <param name="select">select选择表达式</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> select);
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <param name="orderFields">排序名称</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> expression, string orderFields);

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="where">where查询表达式</param>
        /// <param name="select">select选择表达式</param>
        /// <param name="orderFields">排序名称</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> select, string orderFields);
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="expression">查询表达式</param>
        /// <param name="orderFields">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<KeyValuePair<List<T>, int>> FindListAsync(Expression<Func<T, bool>> expression, string orderFields, bool isAsc, int pageSize, int pageIndex);
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <param name="pagination">分页对象</param>
        /// <returns></returns>
        Task<KeyValuePair<List<T>, int>> FindListAsync(Expression<Func<T, bool>> expression, Pagination pagination);
        /// <summary>
        /// 查找分页数据Table
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="expression">查询表达式</param>
        /// <param name="orderFields">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<KeyValuePair<DataTable, int>> FindDataTableAsync(Expression<Func<T, bool>> expression, string orderFields,
            bool isAsc, int pageSize, int pageIndex);
        /// <summary>
        /// 查找分页数据Table
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <param name="pagination">分页对象</param>
        /// <returns></returns>
        Task<KeyValuePair<DataTable, int>> FindDataTableAsync(Expression<Func<T, bool>> expression,
            Pagination pagination);
    }
}
