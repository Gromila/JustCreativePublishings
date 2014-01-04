using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Create(TEntity entity);
        
        IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, String includeProperties = "");

        TEntity ReadById(Object id);

        void Update(TEntity entity);
        
        void Delete(TEntity entity);
    }
}
