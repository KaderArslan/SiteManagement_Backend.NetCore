using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoBill : DtoBase
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

    }
}
