using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces;

namespace JustCreativePublishings.Domain.Repositories
    {
        public class UserRepository : IUserRepository
        {

            private JustCreativePublishingsContext context;

            private DbSet<User> dbSet;

            public UserRepository(JustCreativePublishingsContext context)
            {
                this.context = context;
                dbSet = context.Set<User>();
            }

            void IUserRepository.Create(User entity)
            {
                dbSet.Add(entity);
            }

            IEnumerable<User> IUserRepository.Read(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
            {
                IQueryable<User> query = dbSet;

                if (filter != null)
                    query = query.Where(filter);

                query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                if (orderBy != null)
                    return orderBy(query).ToList();

                return query;
            }

            User IUserRepository.ReadById(object id)
            {
                return dbSet.Find(id);
            }

            void IUserRepository.Update(User entity)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }

            void IUserRepository.Delete(object id)
            {
                User entity = dbSet.Find(id);
                Delete(entity);
            }

            private void Delete(User entity)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
        
        }
    }
