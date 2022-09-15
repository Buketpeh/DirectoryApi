using PhoneDirectoryApi.Core.Models;
using System.Linq.Expressions;

namespace PhoneDirectoryApi.Core.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class,new()
    {
        GetManyResult<TEntity> AsQueryable();
        Task<GetManyResult<TEntity>> AsQueryableAsync();
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<GetManyResult<TEntity>> FilterByAsync (Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> GetById(string Id);
       Task <GetOneResult<TEntity>> GetByIdAsync(string Id);
        GetOneResult<TEntity> InsertOne(TEntity entity);
        Task<GetOneResult <TEntity>> InsertOneAsync(TEntity entity);
        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);
        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        GetOneResult<TEntity> ReplaceOne(TEntity entity,string id);
        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity,string id );

        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> DeleteById(string id);
        Task<GetOneResult<TEntity>> DeleteByIdAsync(string id);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
        void DeleteMany(Expression<Func<TEntity, bool>> filter);
    }
}
