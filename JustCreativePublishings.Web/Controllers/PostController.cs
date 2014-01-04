using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using App_LocalResources;
using AutoMapper;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Models;
using Microsoft.AspNet.Identity;

namespace JustCreativePublishings.Web.Controllers
{
    public class PostController : BaseController
    {
        private IPostService postService;

        private ITagService tagService;

        public PostController(IPostService postService, ITagService tagService)
        {
            this.postService = postService;
            this.tagService = tagService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View(new PostViewModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                post.IsPublished = true;
                post.UserId = User.Identity.GetUserId();
                for (int i = 0; i < post.Chapters.Count; i++)
                {
                    post.Chapters[i].OrderNumber = i + 1;
                }
                var dbPost = Mapper.Map<Post>(post);
                dbPost.Tags = postService.GetTags(post.TagsString).ToList();
                dbPost.LastUpdateDate = DateTime.Now;
                postService.Create(dbPost);
                return RedirectToAction("Show", "Post", new {id = dbPost.Id});
            }
            return View(post);
        }

        [Authorize]
        public ActionResult AddChapterInForm(int chapters)
        {
            return PartialView("Shared/AddChapterPartial", chapters - 1);
        }

        public JsonResult SearchAutoCompleter(String term)
        {
            var tags = tagService.AutoCompleter(term);
            return tags == null ? Json("", JsonRequestBehavior.AllowGet) : Json(tags, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = Mapper.Map<PostViewModel>(postService.GetPostById(id));
            post.Chapters = post.Chapters.OrderBy(a => a.OrderNumber).ToList();
            post.TagsString = tagService.TagsToString(post.Tags);
            return View("Edit", post);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid && post.UserId == User.Identity.GetUserId())
            {
                var dbPost = Mapper.Map<Post>(post);
                dbPost.Tags = postService.GetTags(post.TagsString).ToList();
                postService.Update(dbPost);
                return RedirectToAction("Show", "Post", new {id = post.Id});
            }
            return View(post);
        }
        
        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            tagService.Dispose();
            base.Dispose(disposing);
        }

        [OutputCache(Duration = 30, Location = OutputCacheLocation.Server, VaryByParam = "id")]
        public ActionResult Show(int id = -1)
        {
            if (id == -1)
                return HttpNotFound();
            var post = postService.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = Mapper.Map<PostViewModel>(post);
            postViewModel.Chapters = postViewModel.Chapters.OrderBy(a => a.OrderNumber).ToList();
            postViewModel.VotesValue = postService.CountVotes(post);
            postViewModel.Author = postService.GetAuthorName(post.UserId);
            return View("Show", postViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 300, VaryByParam = "userId")]
        public ActionResult ShowLastTags(String userId)
        {
            return PartialView("_LastTagsPartial", tagService.GetLastUserTags(userId));
        }

        public ActionResult ReorderChapters(String ids, int id)
        {
            postService.ReorderChapters(id, ids);
            return Content("Success");
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10, VaryByParam = "number")]
        public ActionResult GetTagCloud(int number)
        {
            var tags = tagService.GetTopTags(number);
            if (tags == null)
                return Content(GlobalRes.NoTags);
            return PartialView("_TagCloudPartial", tags.ToList());
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5, VaryByParam = "number")]
        public ActionResult GetTopPosts(int number)
        {
            var posts = postService.GetTopPosts(number);
            if (posts == null)
                return Content(GlobalRes.NoPosts);
            return PartialView("_TopPostsPartial", posts.Select(Mapper.Map<PostViewModel>).ToList());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            if (User.Identity.GetUserId() == postService.GetPostById(id).UserId || User.IsInRole("Admin"))
            {
                postService.Delete(id);
            }
            else
            {
                return RedirectToAction("AccessDenied", "User");
            }
            return RedirectToAction("Profile", "User", new {username = User.Identity.GetUserName()});
        }

        public ActionResult ReadingMode(int id = -1)
        {
            if (id == -1)
                return HttpNotFound();
            var post = postService.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = Mapper.Map<PostViewModel>(post);
            postViewModel.Chapters = postViewModel.Chapters.OrderBy(a => a.OrderNumber).ToList();
            postViewModel.VotesValue = postService.CountVotes(post);
            postViewModel.Author = postService.GetAuthorName(post.UserId);
            return View("ReadingMode", postViewModel);
        }

        public ActionResult SavePosition(int postId, int y, int max)
        {
            var position = ((double)y/max).ToString(CultureInfo.InvariantCulture);
            var cookie = Request.Cookies["position" + postId];

            if (cookie != null)
                cookie.Value = position;
            else
            {
                cookie = new HttpCookie("position" + postId) { HttpOnly = false, Value = position, Expires = DateTime.Now.AddYears(1) };
            }
            Response.Cookies.Add(cookie);
            return null;
        }

        public ActionResult LoadPosition(int postId)
        {
            var cookie = Request.Cookies["position"+postId];
            if (cookie == null)
                return Content("0");
            return Content(cookie.Value);
        }
    }
}