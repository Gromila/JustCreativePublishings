using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Domain.Entities
{
    public class Post : Entity
    {
        public String Title { get; set; }

        public String ShortDescription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        public bool IsPublished { get; set; }

        public String UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public Post()
        {
            CreationDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Votes = new List<Vote>();
            Tags = new List<Tag>();
            Chapters = new List<Chapter>();
        }
    }
}
