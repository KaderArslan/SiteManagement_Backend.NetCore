using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoUserAdmin : DtoBase
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "İsim boş bırakılamaz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Soyisim boş bırakılamaz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "TCNo boş bırakılamaz.")]
        [StringLength(maximumLength: 11)]
        [DataType(DataType.Text)]
        public string UserTcnum { get; set; }

        [Required(ErrorMessage = "Email adresi boş bırakılamaz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz!")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [StringLength(maximumLength: 11)]
        [DataType(DataType.Text)]
        public string UserPhoneNum { get; set; }

        [StringLength(maximumLength: 9)]
        [DataType(DataType.Text)]
        public string UserCarStatus { get; set; }

        [Required(ErrorMessage = "True(Aktif) ya da False(Değil) değerini giriniz.")]
        public bool UserIsActive { get; set; }

        [Required(ErrorMessage = "Lütfen Apartmant ID bilgisini giriniz.")]
        public int ApartmentId { get; set; }
    }
}
