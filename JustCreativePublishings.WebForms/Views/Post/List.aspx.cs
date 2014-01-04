using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Services;

namespace JustCreativePublishings.WebForms.Views.Post
{
    public partial class List : System.Web.UI.Page
    {
        private IPostService postService;
        private ITagService tagService;

        protected void Page_Load(object sender, EventArgs e)
        {
            postService = new PostService();
            tagService = new TagService();
        }

        public IEnumerable<Domain.Entities.Post> GetPosts()
        {
            List<Domain.Entities.Post> posts;
            return Request.QueryString["tagId"] != null ? tagService.GetPostsByTag(int.Parse(Request.QueryString["tagId"])).ToList() : postService.GetPosts().ToList();
        }
    }
}