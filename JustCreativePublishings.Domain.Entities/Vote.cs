using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Domain.Entities
{
    public class Vote : Entity
    {
        public int Value { get; set; }

        public int? PostId { get; set; }

        public String UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; private set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public Vote()
        {
            CreationDate = DateTime.Now;
        }
    }
}
