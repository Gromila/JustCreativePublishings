using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IAdminService : IService
    {
        IEnumerable<User> GetUsers();

        void ChangeRole(String userId, String role);

        void DeleteUser(String userId);

        void ResetPassword(String userId);

        IEnumerable<Post> GetPosts();
    }
}
