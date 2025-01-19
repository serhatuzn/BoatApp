using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using BoatApp.Data.Entites;
using System.Linq.Expressions;


namespace BoatApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
            where TEntity : BaseEntity
    {
        private readonly BoatAppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BoatAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.ModifiedDate = DateTime.UtcNow;
                entity.IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _dbSet.FirstOrDefault(predicate);
            
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _dbSet : _dbSet.Where(predicate);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
        }
    }
}

