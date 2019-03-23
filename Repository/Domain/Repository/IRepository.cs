using Repository.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : BaseModel
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPrimaryKey key);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}