using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoUser : DtoBase
    {
        public DtoUser()
        {

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

    }
}
