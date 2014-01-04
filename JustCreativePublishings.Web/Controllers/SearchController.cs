using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Models;

namespace JustCreativePublishings.Web.Controllers
{
    public class SearchController : BaseController
    {
        private ITagService tagService;

        private IPostService postService;

        private IUserService userService;

        public SearchController(ITagService tagService, IPostService postService, IUserService userService)
        {
            this.tagService = tagService;
            this.postService = postService;
            this.userService = userService;
        }

        public ActionResult SearchByTag(int id)
        {
            var posts = tagService.GetPostsByTag(id);
            return View("TagSearchResults", posts.Select(Mapper.Map<PostViewModel>).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            tagService.Dispose();
            postService.Dispose();
            userService.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Search(String searchString)
        {
            ViewBag.SearchString = searchString;
            return View("SearchResults");
        }

        public ActionResult SearchTags(String searchString)
        {
            var tags = tagService.GetTagsByContent(searchString);
            return PartialView("Shared/_TagsPartial", tags);
        }

        public ActionResult SearchUsers(String searchString)
        {
            var users = userService.GetUsersByName(searchString);
            return PartialView("_TopUsersPartial", users.Select(Mapper.Map<UserViewModel>).ToList());
        }

        public ActionResult SearchPosts(String searchString)
        {
            var posts = postService.GetPostsByContent(searchString);
            return PartialView("_TopPostsPartial", posts.Select(Mapper.Map<PostViewModel>).ToList());
        }
    }
}