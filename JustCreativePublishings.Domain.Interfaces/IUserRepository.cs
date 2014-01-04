using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces
{
    public interface IUserRepository
    {
        void Create(User entity);

        IEnumerable<User> Read(Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, String includeProperties = "");

        User ReadById(Object id);

        void Update(User entity);

        void Delete(Object id);
    }
}
