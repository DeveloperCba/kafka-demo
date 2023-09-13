using Dapper;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Datas.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    //EntityFrameworkCore
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> GetByIdAsync(string id);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetByIdsAsync(object[] ids);

    Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Expression<Func<TEntity, TEntity>> field = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool isTracking = false
    );

    Task<IEnumerable<TEntity>> GetAllPaginationAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Expression<Func<TEntity, TEntity>> field = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool isTracking = false,
        int pageNumber = 1,
        int pageSize = 10
    );

    Task<TEntity> GetByFilterAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, TEntity>> field = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool isTracking = false
    );

    Task AddAsync(TEntity entity);
    Task AddRangerAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> HasValueAsync(Expression<Func<TEntity, bool>> filter = null);
    Task RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    Task<int> SaveChangesAsync();


    //Dapper
    bool CheckConnection();
    Task<TEntity> GetAsync(string procedureNameOrSql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure);
    Task<TEntity> GetByIdAsync(object id);
    Task<TEntity> GetOrDefaultAsync(string procedureNameOrSql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure);
    Task<IEnumerable<TEntity>> GetAllAsync(string procedureNameOrSql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure);
    Task ExecuteWithoutReturnAsync(string procedureNameOrSql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure);
    Task<TEntity> ExecuteReturnScalerAsync(string procedureNameOrSql, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure);
}