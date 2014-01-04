using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Web.Filters;

namespace JustCreativePublishings.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IStatisticsService statisticsService;

        public HomeController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [OutputCache(Duration = int.MaxValue, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1800, VaryByParam = "none")]
        public ActionResult GetMainChart()
        {
            var stat = statisticsService.GetTopAuthors(4);
            return PartialView("Shared/_MainChartPartial", stat);
        }

        protected override void Dispose(bool disposing)
        {
            statisticsService.Dispose();
            base.Dispose(disposing);
        }
    }
}