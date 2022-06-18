using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoALogin : DtoBase
    {
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")] //zorunlu alan
        [StringLength(maximumLength: 50)]//uzunlugu belirrtik
        [DataType(DataType.EmailAddress)]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz!")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        //bu parolayı alip sifrelicegiz, logine parametre gonderecegiz
    }
}
