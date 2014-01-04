using System;
using System.Data.Entity;
using JustCreativePublishings.Domain;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Domain.Migrations;
using JustCreativePublishings.Domain.Repositories;
using JustCreativePublishings.Interfaces;

namespace JustCreativePublishings.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private readonly JustCreativePublishingsContext context = new JustCreativePublishingsContext();

        private IUserRepository userRepository;

        private IRoleRepository roleRepository;

        private IRepository<Chapter> chapterRepository;

        private IRepository<Post> postRepository;

        private IRepository<Tag> tagRepository;

        private IRepository<Vote> voteRepository;

        public JustCreativePublishingsContext Context
        {
            get { return context; }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository ?? (userRepository = new UserRepository(context));
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return roleRepository ?? (roleRepository = new RoleRepository(context));
            }
        }

        public IRepository<Chapter> ChapterRepository
        {
            get
            {
                return chapterRepository ?? (chapterRepository = new BaseRepository<Chapter>(context));
            }
        }

        public IRepository<Post> PostRepository
        {
            get
            {
                return postRepository ?? (postRepository = new BaseRepository<Post>(context));
            }
        }

        public IRepository<Tag> TagRepository
        {
            get
            {
                return tagRepository ?? (tagRepository = new BaseRepository<Tag>(context));
            }
        }

        public IRepository<Vote> VoteRepository
        {
            get
            {
                return voteRepository ?? (voteRepository = new BaseRepository<Vote>(context));
            }
        }


        public UnitOfWork()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JustCreativePublishingsContext, Configuration>());
        }

        void IUnitOfWork.Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
