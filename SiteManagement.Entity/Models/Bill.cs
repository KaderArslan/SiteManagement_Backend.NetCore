using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteManagement.Entity.Models
{
    public partial class Bill : EntityBase
    {
        public int BillId { get; set; }
        public string BillType { get; set; }
        public decimal BillSum { get; set; }
        public bool BillIsPaid { get; set; }
        //public DateTime BillEndDate { get; set; }
        public DateTime BillDate { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        //public int AdminId { get; set; }

        //public virtual Admin Admin { get; set; }
        public virtual Apartment Apartment { get; set; }
        public virtual User User { get; set; }
    }
}
