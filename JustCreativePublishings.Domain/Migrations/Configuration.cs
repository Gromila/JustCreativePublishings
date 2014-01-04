using System.CodeDom;
using System.Web;
using JustCreativePublishings.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<JustCreativePublishings.Domain.JustCreativePublishingsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JustCreativePublishings.Domain.JustCreativePublishingsContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!RoleManager.RoleExists("Admin"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Admin"));
            }

            if (!RoleManager.RoleExists("User"))
            {
                var roleResult = RoleManager.Create(new IdentityRole("User"));
            }

            var user = new User
            {
                UserName = "admin",
                Email = "admin@admin.by",
                DateOfBirth = DateTime.Parse("01.01.1999"),
                IsConfirmed = true,
                ConfirmationToken = "I'mAdminSoGoAway"
            };
            var adminresult = UserManager.Create(user, "givemeaccess");

            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "Admin");
            }
            
            base.Seed(context);
        }
    }
}
