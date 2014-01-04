using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces;

namespace JustCreativePublishings.Domain.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private JustCreativePublishingsContext context;

        private DbSet<TEntity> dbSet;

        public BaseRepository(JustCreativePublishingsContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        void IRepository<TEntity>.Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        IEnumerable<TEntity> IRepository<TEntity>.Read(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, String includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            
            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                return orderBy(query).ToList();
            
            return query;
        }

        TEntity IRepository<TEntity>.ReadById(object id)
        {
            return dbSet.Find(id);
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
