using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoApartment : DtoBase
    {
        public DtoApartment()
        {
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

    }
}
