using System;
using System.Linq;
using System.Web.Mvc;
using App_LocalResources;
using AutoMapper;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Models;

namespace JustCreativePublishings.Web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;

        private IStatisticsService statisticsService;
        
        public UserController(IUserService userService, IStatisticsService statisticsService)
        {
            this.userService = userService;
            this.statisticsService = statisticsService;
        }

        [OutputCache(Duration = 60, VaryByParam = "username")]
        public ActionResult Profile(String username)
        {
            if (String.IsNullOrEmpty(username))
                return HttpNotFound();
            var user = Mapper.Map<UserViewModel>(userService.GetUserByUsername(username));
            return View("Profile", user);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 1800, VaryByParam = "number")]
        public ActionResult GetTopUsers(int number)
        {
            var users = userService.GetTopUsers(number);
            if (users == null)
                return Content(GlobalRes.NoUsers);
            return PartialView("_TopUsersPartial", users.Select(Mapper.Map<UserViewModel>).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            statisticsService.Dispose();
            base.Dispose(disposing);
        }

        [OutputCache(Duration = 600, VaryByParam = "userId")]
        public ActionResult UserStats(String userId)
        {
            var model = statisticsService.GetUserStats(userId);
            return PartialView("Shared/_UserStatsPartial", model);
        }
    }
}