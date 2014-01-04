using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using JustCreativePublishings.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Domain
{
    public class JustCreativePublishingsContext : IdentityDbContext<User>
    {
        public JustCreativePublishingsContext() : base("DefaultConnection")
        { }
        
        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Vote> Votes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
