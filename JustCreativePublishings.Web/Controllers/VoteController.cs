using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Models;
using Microsoft.AspNet.Identity;

namespace JustCreativePublishings.Web.Controllers
{
    public class VoteController : BaseController
    {
        private IVoteService voteService;

        public VoteController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        public ActionResult Vote(int id, int voteValue, int votes)
        {
            if (Request.IsAuthenticated)
            {
                votes = voteService.UpdateVotesForPost(id, User.Identity.GetUserId(), voteValue);
            }
            return Json(votes, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60, VaryByParam = "userId")]
        public ActionResult ShowLastVotes(String userId)
        {
            var votes = voteService.GetLastVotes(userId).Select(Mapper.Map<VoteViewModel>).ToList();
            return PartialView("_LastVotesPartial", votes);
        }

        protected override void Dispose(bool disposing)
        {
            voteService.Dispose();
            base.Dispose(disposing);
        }
    }
}
