using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoULogin : DtoBase
    {
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz!")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
