using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class UserService : BaseService, IUserService
    {
        User IUserService.GetUserByUsername(String username)
        {
            return UnitOfWork.UserRepository.Read(a => a.UserName == username).SingleOrDefault();
        }

        IEnumerable<User> IUserService.GetTopUsers(int number)
        {
            return UnitOfWork.UserRepository.Read(orderBy: u => u.OrderByDescending(p => p.Posts.Count)).Take(number);
        }

        IEnumerable<User> IUserService.GetUsersByName(String name)
        {
            return
                UnitOfWork.UserRepository.Read(filter: user => user.UserName.Contains(name), includeProperties: "Posts")
                    .OrderByDescending(user => user.Posts.Count);
        }
    }
}
