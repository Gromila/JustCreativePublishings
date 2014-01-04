using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IUserService : IService
    {
        User GetUserByUsername(String username);
        
        IEnumerable<User> GetTopUsers(int number);
        IEnumerable<User> GetUsersByName(String name);
    }
}
