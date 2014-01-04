using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Services
{
    public class AdminService : BaseService, IAdminService
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AdminService()
        {
            userManager = new UserManager<User>(new UserStore<User>(UnitOfWork.Context));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(UnitOfWork.Context));
        }

        IEnumerable<User> IAdminService.GetUsers()
        {
            return UnitOfWork.UserRepository.Read();
        }

        void IAdminService.ChangeRole(String userId, String role)
        {
            var oldRole = UnitOfWork.UserRepository.ReadById(userId).Roles.First().Role.Name;
            userManager.RemoveFromRole(userId, oldRole);
            userManager.AddToRole(userId, role);
        }

        void IAdminService.DeleteUser(String userId)
        {
            var votes = UnitOfWork.VoteRepository.Read(v => v.UserId == userId);
            foreach (var vote in votes)
            {
                UnitOfWork.VoteRepository.Delete(vote);
            }
            UnitOfWork.Save();

            var posts = UnitOfWork.PostRepository.Read(filter: p => p.UserId == userId, includeProperties: "Votes,Tags,Chapters");
            foreach (var post in posts)
            {
                var chapters = UnitOfWork.ChapterRepository.Read(filter: c => c.PostId == post.Id).ToList();
                foreach (var chapter in chapters)
                {
                    UnitOfWork.ChapterRepository.Delete(chapter);
                }
                UnitOfWork.Save();

                votes = UnitOfWork.VoteRepository.Read(filter: v => v.PostId == post.Id).ToList();
                foreach (var vote in votes)
                {
                    UnitOfWork.VoteRepository.Delete(vote);
                }
                UnitOfWork.Save();

                var currentpost = UnitOfWork.PostRepository.Read(filter: p => p.Id == post.Id, includeProperties: "Tags,Chapters,Votes").FirstOrDefault();
                UnitOfWork.PostRepository.Delete(post);
                UnitOfWork.Save();
            }
            UnitOfWork.Save();
            
            var user = UnitOfWork.UserRepository.ReadById(userId);
            Roles.RemoveUserFromRoles(user.UserName, Roles.GetRolesForUser(user.UserName));
            Membership.Provider.DeleteUser(user.UserName, false);
        }

        void IAdminService.ResetPassword(String userId)
        {
            userManager.RemovePassword(userId);
            userManager.AddPassword(userId, "defaultPassword");
        }

        IEnumerable<Post> IAdminService.GetPosts()
        {
            return UnitOfWork.PostRepository.Read();
        }
    }
}
