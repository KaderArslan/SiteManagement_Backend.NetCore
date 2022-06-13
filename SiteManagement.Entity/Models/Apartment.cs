using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteManagement.Entity.Models
{
    public partial class Apartment : EntityBase
    {
        public Apartment()
        {
            Admins = new HashSet<Admin>();
            Bills = new HashSet<Bill>();
            Users = new HashSet<User>();
        }

        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public bool ApartmentIsEmpty { get; set; }
        public string ApartmentType { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNumber { get; set; }
        public bool ApartmentIsOwner { get; set; }
        public DateTime ApartmentStartDate { get; set; }
        public DateTime ApartmentEndDate { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
