using Core.DataAccess.Abstracts;
using Core.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveAsync() > 0 ? entity : null;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                var existWithoutExpression = await _dbSet.AnyAsync();
                return existWithoutExpression;
            }

            var existWithExpression = await _dbSet.AnyAsync(expression);
            return existWithExpression;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync() > 0 ? true : false;
        }

        public async Task<TEntity> FirsOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.Status != Enums.Status.Passive).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(x => x.Status != Enums.Status.Passive).Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await SaveAsync() > 0 ? entity : null;
        }
    }
}
