﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Interfaces
{
    public interface IRoleRepository
    {
        void Create(IdentityRole entity);

        IEnumerable<IdentityRole> Read(Expression<Func<IdentityRole, bool>> filter = null,
            Func<IQueryable<IdentityRole>, IOrderedQueryable<IdentityRole>> orderBy = null, String includeProperties = "");

        IdentityRole ReadById(Object id);

        void Update(IdentityRole entity);

        void Delete(Object id);
    }
}
