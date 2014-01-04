using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Domain.Entities
{
    public class Chapter : Entity
    {
        public String Title { get; set; }

        public String Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; private set; }

        public int OrderNumber { get; set; }

        public int? PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public Chapter()
        {
            CreationDate = DateTime.Now;
        }
    }
}
