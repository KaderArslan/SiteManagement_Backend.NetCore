using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoApartmentAdmin : DtoBase
    {
        public int ApartmentId { get; set; }
        [Required(ErrorMessage = "A-Z aralığında değer giriniz.")]
        [StringLength(maximumLength: 1)]
        [DataType(DataType.Text)]
        public string ApartmentBlock { get; set; }

        [Required(ErrorMessage = "True(Boş) ya da False(Dolu) değerini giriniz.")]
        public bool ApartmentIsEmpty { get; set; }

        [Required(ErrorMessage = "2+1 vb. değerler giriniz.")]
        [StringLength(maximumLength: 5)]
        [DataType(DataType.Text)]
        public string ApartmentType { get; set; }

        [Required(ErrorMessage = "Sıfırdan farklı bir değer giriniz.")]
        public int ApartmentFloor { get; set; }

        [Required(ErrorMessage = "Sıfırdan farklı bir değer giriniz.")]
        public int ApartmentNumber { get; set; }

        public bool ApartmentIsOwner { get; set; }
        public DateTime ApartmentStartDate { get; set; }
        public DateTime ApartmentEndDate { get; set; }
    }
}
