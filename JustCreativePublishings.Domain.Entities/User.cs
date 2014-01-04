using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JustCreativePublishings.Domain.Entities
{
    public class User : IdentityUser
    {
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; private set; }

        public String ConfirmationToken { get; set; }

        public bool IsConfirmed { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public User()
        {
            RegistrationDate = DateTime.Now;
            Posts = new List<Post>();
            Votes = new List<Vote>();
        }

    }
}
