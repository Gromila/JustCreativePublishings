using System;
using JustCreativePublishings.Domain;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        JustCreativePublishingsContext Context { get; }

        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        IRepository<Chapter> ChapterRepository { get; }

        IRepository<Post> PostRepository { get; }

        IRepository<Tag> TagRepository { get; }

        IRepository<Vote> VoteRepository { get; }

        void Save();
    }
}
