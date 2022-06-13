using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoBillAdmin : DtoBase
    {
        public int BillId { get; set; }
        [Required(ErrorMessage = "Fatura Tipi: Elektrik, su ya da aidat.")]
        [StringLength(maximumLength: 30)]
        [DataType(DataType.Text)]
        public string BillType { get; set; }

        [Required(ErrorMessage = "Fatura Tutarını giriniz")]
        public decimal BillSum { get; set; }

        [Required(ErrorMessage = "True(Ödenmedi) ya da False(Ödendi) değerini giriniz.")]
        public bool BillIsPaid { get; set; }

        [Required(ErrorMessage = "Fatura ödeme tarihini giriniz")]
        public DateTime BillDate { get; set; }

        [Required(ErrorMessage = "Apartman ID bilgisini giriniz.")]
        public int ApartmentId { get; set; }

        [Required(ErrorMessage = "User ID bilgisini giriniz.")]
        public int UserId { get; set; }
    }
}
