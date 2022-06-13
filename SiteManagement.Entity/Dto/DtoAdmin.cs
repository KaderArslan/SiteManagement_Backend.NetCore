using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoAdmin : DtoBase
    {
        public DtoAdmin()
        {

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

    }
}
