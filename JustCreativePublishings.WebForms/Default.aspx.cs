using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Services;

namespace JustCreativePublishings.WebForms
{
    public partial class _Default : Page
    {
        private ITagService tagService;
        private IPostService postService;

        protected void Page_Load(object sender, EventArgs e)
        {
            tagService = new TagService();
            postService = new PostService();
        }

        public IEnumerable<Tag> GetTags()
        {
            return tagService.GetTopTags(20);
        }

        public IEnumerable<Post> GetPosts()
        {
            return postService.GetTopPosts(5);
        }
    }
}