using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : BaseModel<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll() => 
            _dbSet;

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression) =>
            _dbSet.Where(expression);

        public virtual async Task<TEntity> GetAsync(TPrimaryKey key) =>
            await _dbSet.SingleOrDefaultAsync(x => x.Id.Equals(key));

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression) =>
            await _dbSet.SingleOrDefaultAsync(expression);

        public virtual async Task AddAsync(TEntity entity) => 
            await _dbSet.AddAsync(entity);

        public virtual void Remove(TEntity entity) => 
            _dbSet.Remove(entity);

        public virtual TEntity Update(TEntity entity) => 
            _dbSet.Update(entity).Entity;
    }
}