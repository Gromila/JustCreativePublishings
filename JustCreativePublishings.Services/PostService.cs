using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class PostService : BaseService, IPostService
    {
        public PostService() : base()
        {
        }

        void IPostService.Create(Post post)
        {
            post.CreationDate = DateTime.Now;
            UnitOfWork.PostRepository.Create(post);
            UnitOfWork.Save();
        }

        void IPostService.Update(Post updPost)
        {
            var post = UnitOfWork.PostRepository.ReadById(updPost.Id);
            post.LastUpdateDate = DateTime.Now;
            post.Title = updPost.Title;
            post.ShortDescription = updPost.ShortDescription;
            post.IsPublished = true;
            for (int i = 0; i < updPost.Chapters.Count; i++)
            {
                var chapter = CheckChapterOnExistance(updPost.Chapters.ToList()[i]);
                if (!post.Chapters.Contains(chapter))
                {
                    post.Chapters.Add(chapter);
                }
            }
            for (int i = 0; i < updPost.Tags.Count; i++)
            {
                if (!post.Tags.Contains(updPost.Tags.ToList()[i]))
                {
                    post.Tags.Add(updPost.Tags.ToList()[i]);
                }
            }
            for (int i = 0; i < post.Tags.Count; i++)
            {
                if (!updPost.Tags.Contains(post.Tags.ToList()[i]))
                {
                    post.Tags.Remove(post.Tags.ToList()[i]);
                }
            }
            UnitOfWork.PostRepository.Update(post);
            UnitOfWork.Save();
        }

        private Chapter CheckChapterOnExistance(Chapter chapter)
        {
            var existedChapter = UnitOfWork.ChapterRepository.Read(filter: c => c.Title == chapter.Title && c.Content == chapter.Content).FirstOrDefault();
            return existedChapter ?? chapter;
        }

        Post IPostService.GetPostById(int id)
        {
            return UnitOfWork.PostRepository.Read(filter: a => a.Id == id && a.IsPublished, includeProperties: "Tags,Chapters,Votes,User").FirstOrDefault();
        }

        String IPostService.GetAuthorName(String userId)
        {
            return UnitOfWork.UserRepository.ReadById(userId).UserName;
        }

        int IPostService.CountVotes(Post post)
        {
            return post.Votes.Sum(vote => vote.Value);
        }

        void IPostService.ReorderChapters(int postId, String order)
        {
            var post = ((IPostService) this).GetPostById(postId);
            var orderNumbers = order.Split(new char[] {'_'});
            for (int i = 0; i < post.Chapters.Count; i++)
            {
                post.Chapters.ToList()[i].OrderNumber = int.Parse(orderNumbers[i]) + 1;
            }
            UnitOfWork.Save();
        }

        IEnumerable<Post> IPostService.GetTopPosts(int number)
        {
            return UnitOfWork.PostRepository.Read(filter: p => p.IsPublished, orderBy: p => p.OrderByDescending(a => a.Votes.Sum(v => v.Value)), includeProperties: "Tags,Chapters,Votes,User").Take(number).ToList();
        }

        void IPostService.Delete(int id)
        {
            var chapters = UnitOfWork.ChapterRepository.Read(filter: c => c.PostId == id).ToList();
            foreach (var chapter in chapters)
            {
                UnitOfWork.ChapterRepository.Delete(chapter);
            }
            UnitOfWork.Save();

            var votes = UnitOfWork.VoteRepository.Read(filter: v => v.PostId == id).ToList();
            foreach (var vote in votes)
            {
                UnitOfWork.VoteRepository.Delete(vote);
            }
            UnitOfWork.Save();

            var post = UnitOfWork.PostRepository.Read(filter: p => p.Id == id, includeProperties: "Tags,Chapters,Votes").FirstOrDefault();
            UnitOfWork.PostRepository.Delete(post);
            UnitOfWork.Save();
        }

        IEnumerable<Post> IPostService.Search(String search)
        {
            return UnitOfWork.PostRepository.Read();
        }

        IEnumerable<Tag> IPostService.GetTags(String tagsString)
        {
            var tags = ParseTags(tagsString);
            return tags.Select(SearchTagInDb).ToList();
        }

        private Tag SearchTagInDb(Tag tag)
        {
            var existedTag = UnitOfWork.TagRepository.Read(a => a.Content == tag.Content).FirstOrDefault();
            return existedTag ?? tag;
        }

        private IEnumerable<Tag> ParseTags(String tagsString)
        {
            var tags = tagsString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tags.Count(); i++)
            {
                tags[i] = tags[i].ToLower();
            }
            return tags.Select(tag => new Tag() { Content = tag }).ToList();
        }

        IEnumerable<Post> IPostService.GetPostsByContent(String content)
        {
            var posts =
                UnitOfWork.PostRepository.Read(
                    filter: p => p.Title.Contains(content) || p.ShortDescription.Contains(content)).ToList();
            var chapters =
                UnitOfWork.ChapterRepository.Read(filter: c => c.Title.Contains(content) || c.Content.Contains(content), includeProperties: "Post");
            posts.AddRange(chapters.Select(chapter => chapter.Post));
            return posts.Distinct().ToList();
        }

        IEnumerable<Post> IPostService.GetPosts()
        {
            return UnitOfWork.PostRepository.Read(includeProperties: "Chapters,Votes,Tags").OrderByDescending(a => a.CreationDate);
        }
    }
}