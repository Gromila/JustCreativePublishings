using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Domain.Entities
{
    public class Tag : Entity
    {
        public String Content { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Tag()
        {
            Posts = new List<Post>();
        }
    }
}
