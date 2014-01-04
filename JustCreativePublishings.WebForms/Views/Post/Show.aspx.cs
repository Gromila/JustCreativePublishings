using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Services;

namespace JustCreativePublishings.WebForms.Views.Post
{
    public partial class Show : System.Web.UI.Page
    {
        private IPostService postService;

        protected void Page_Load(object sender, EventArgs e)
        {
            postService = new PostService();
        }

        public IEnumerable<Chapter> GetChapters()
        {
            return postService.GetPostById(id: int.Parse(Request.QueryString["id"])).Chapters;
        }

        public Domain.Entities.Post GetPost()
        {
            var post = postService.GetPostById((int.Parse(Request.QueryString["id"])));
            return post;
        }

        public IEnumerable<Tag> GetTags()
        {
            return postService.GetPostById(int.Parse(Request.QueryString["id"])).Tags;
        }

        protected void DeletePost(object sender, EventArgs e)
        {
            postService.Delete(int.Parse(Request.QueryString["id"]));
            Response.Redirect("~/");
        }
    }
}