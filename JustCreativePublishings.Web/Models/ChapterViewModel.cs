using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustCreativePublishings.Web.Models
{
    public class ChapterViewModel
    {
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Title")]
        public String Title { get; set; }

        [Display(AutoGenerateField = false)]
        public int OrderNumber { get; set; }

        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "ChapterContent")]
        public String Content { get; set; }
    }
}