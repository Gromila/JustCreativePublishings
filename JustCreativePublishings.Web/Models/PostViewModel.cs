using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; private set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public bool IsPublished { get; set; }

        public String Author { get; set; }
        
        public int VotesValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "TitleRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Title")]
        public String Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "ShortDescriptionRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "ShortDescription")]
        public String ShortDescription { get; set; }

        public String UserId { get; set; }

        public List<ChapterViewModel> Chapters { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "TagsRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Tags")]
        public String TagsString { get; set; }

        public List<Tag> Tags { get; set; }

        public List<VoteViewModel> Votes { get; set; }

        public PostViewModel()
        {
            Tags = new List<Tag>();
            Chapters = new List<ChapterViewModel>();
            Votes = new List<VoteViewModel>();
        }

    }
}