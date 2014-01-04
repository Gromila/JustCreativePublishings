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
    public partial class Add : System.Web.UI.Page
    {
        private IPostService postService;

        protected void Page_Load(object sender, EventArgs e)
        {
            postService = new PostService();
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            var post = new Domain.Entities.Post
            {
                Title = TitleTb.Text,
                ShortDescription = ShortDescription.Text,
                Tags = postService.GetTags(Tags.Text).ToList(),
                Chapters = new List<Chapter>
                {
                    new Chapter()
                    {
                        Title = Chapter1Title.Text,
                        Content = Chapter2Content.Text,
                        OrderNumber = 1
                    },
                    new Chapter()
                    {
                        Title = Chapter2Title.Text,
                        Content = Chapter2Content.Text,
                        OrderNumber = 2
                    }
                }
            };
            post.IsPublished = true;
            post.LastUpdateDate = DateTime.Now;
            postService.Create(post);
            Response.Redirect("~/Views/Post/Show?id="+post.Id);
        }
    }
}