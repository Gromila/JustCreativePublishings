using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustCreativePublishings.Web.Models
{
    public class VoteViewModel
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public virtual UserViewModel User { get; set; }

        public virtual PostViewModel Post { get; set; }
    }
}