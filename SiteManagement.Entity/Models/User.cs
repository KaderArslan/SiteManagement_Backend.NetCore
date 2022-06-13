using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteManagement.Entity.Models
{
    public partial class User : EntityBase
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            Messages = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserTcnum { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNum { get; set; }
        public string UserCarStatus { get; set; }
        public bool UserIsActive { get; set; }
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
