using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface ITagService : IService
    {
        void Create(Tag tag);

        IEnumerable<Tag> GetTags(String tagsString);

        IEnumerable<String> AutoCompleter(String term);

        IEnumerable<Tag> GetLastUserTags(String userId);

        String TagsToString(List<Tag> tags);

        IEnumerable<Tag> GetTopTags(int number);
        
        IEnumerable<Post> GetPostsByTag(int id);
        IEnumerable<Tag> GetTagsByContent(String content);
    }
}
