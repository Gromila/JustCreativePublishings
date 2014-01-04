using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class TagService : BaseService, ITagService
    {
        public TagService() : base() { }

        void ITagService.Create(Tag tag)
        {
            UnitOfWork.TagRepository.Create(tag);
            UnitOfWork.Save();
        }

        IEnumerable<Tag> ITagService.GetTags(String tagsString)
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

        IEnumerable<String> ITagService.AutoCompleter(string term)
        {
            term = term.Split(new char[] { ',', ' ' }).Last();
            return String.IsNullOrWhiteSpace(term) ? null :
                UnitOfWork.TagRepository.Read(a => a.Content.Contains(term))
                    .Select(label => label.Content)
                    .Distinct()
                    .Take(10);
        }

        IEnumerable<Tag> ITagService.GetLastUserTags(String userId)
        {
            var tags = new List<Tag>();
            var posts = UnitOfWork.UserRepository.ReadById(userId).Posts;
            foreach (var post in posts)
            {
                tags.AddRange(post.Tags);
            }
            return tags.Distinct().Take(10).ToList();
        }

        String ITagService.TagsToString(List<Tag> tags)
        {
            return tags.Aggregate(String.Empty, (current, tag) => current + tag.Content + " ");
        }

        IEnumerable<Tag> ITagService.GetTopTags(int number)
        {
            return
                UnitOfWork.TagRepository.Read()
                    .OrderByDescending(tag => tag.Posts.Count)
                    .Distinct()
                    .Take(number)
                    .OrderBy(tag => tag.Posts.Count)
                    .ToList();
        }

        public IEnumerable<Post> GetPostsByTag(int id)
        {
            return UnitOfWork.TagRepository.ReadById(id).Posts.Where(p => p.IsPublished).OrderByDescending(a => a.Votes.Sum(v => v.Value));
        }

        IEnumerable<Tag> ITagService.GetTagsByContent(String content)
        {
            return
                UnitOfWork.TagRepository.Read(filter: tag => tag.Content.Contains(content), includeProperties: "Posts")
                    .OrderByDescending(tag => tag.Posts.Count);
        }
    }
}
