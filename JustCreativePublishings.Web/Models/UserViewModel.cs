using System;
using System.Collections.Generic;

namespace JustCreativePublishings.Web.Models
{
    public class UserViewModel
    {
        public String UserName { get; set; }

        public String Id { get; set; }

        public String Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }

        public ICollection<VoteViewModel> Votes { get; set; }

        public UserViewModel()
        {
            Posts = new List<PostViewModel>();
            Votes = new LinkedList<VoteViewModel>();
        }
    }
}