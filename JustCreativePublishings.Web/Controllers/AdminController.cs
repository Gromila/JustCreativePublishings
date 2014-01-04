using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using JustCreativePublishings.Domain;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private IAdminService adminService;
        private IPostService postService;

        public AdminController(IAdminService adminService, IPostService postService)
        {
            this.adminService = adminService;
            this.postService = postService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowUsersList()
        {
            var users = adminService.GetUsers();
            return View("UserList", users.Select(Mapper.Map<UserViewModel>));
        }

        public ActionResult ShowPosts()
        {
            var posts = adminService.GetPosts();
            return View("PostsList", posts.Select(Mapper.Map<PostViewModel>));
        }

        public ActionResult ChangeRole(String userId, String role)
        {
            adminService.ChangeRole(userId, role);
            return RedirectToAction("ShowUsersList");
        }

        public ActionResult ResetPassword(String userId)
        {
            adminService.ResetPassword(userId);
            return RedirectToAction("ShowUsersList");
        }

        public ActionResult DeleteUser(String userId)
        {
            adminService.DeleteUser(userId);
            return RedirectToAction("ShowUsersList");
        }

        public ActionResult RemovePost(int postId)
        {
            postService.Delete(postId);
            return RedirectToAction("ShowPosts");
        }

        protected override void Dispose(bool disposing)
        {
            adminService.Dispose();
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}