using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity, in TPrimaryKey> 
        where TEntity : BaseModel<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(TPrimaryKey key);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}