using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteManagement.Entity.Models
{
    //partial buyuk bir classi parcalamak icin kullanilir
    public partial class Admin : EntityBase
    {
        public Admin()
        {
            //Bills = new HashSet<Bill>();
            Messages = new HashSet<Message>();
        }

        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string AdminTcnum { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminPhoneNum { get; set; }
        public string AdminCarStatus { get; set; }
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }
        //public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
