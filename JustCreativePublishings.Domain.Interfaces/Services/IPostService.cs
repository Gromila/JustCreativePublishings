using System;
using System.Collections;
using System.Collections.Generic;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IPostService : IService
    {
        void Create(Post post);

        Post GetPostById(int id);

        String GetAuthorName(String id);

        int CountVotes(Post post);

        void Update(Post post);

        void ReorderChapters(int postId, String order);

        IEnumerable<Post> GetTopPosts(int number);

        void Delete(int id);

        IEnumerable<Post> Search(String search);

        IEnumerable<Tag> GetTags(String tagsString);

        IEnumerable<Post> GetPostsByContent(String content);

        IEnumerable<Post> GetPosts();
    }
}
