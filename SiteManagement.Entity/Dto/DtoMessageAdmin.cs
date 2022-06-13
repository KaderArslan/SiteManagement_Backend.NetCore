using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoMessageAdmin : DtoBase
    {
        public int MessageId { get; set; }
        [Required(ErrorMessage = "Mesaj Başlık bilgisini giriniz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string MessageTitle { get; set; }

        [Required(ErrorMessage = "Mesaj İçerik bilgisini giriniz.")]
        [StringLength(maximumLength: 300)]
        [DataType(DataType.Text)]
        public string MessageText { get; set; }

        [Required(ErrorMessage = "Mesaj gönderen kişi bilgisini giriniz (1,2,...).")]
        public int MessageSender { get; set; }

        [Required(ErrorMessage = "Mesajı alacak kişi bilgisini giriniz (1,2,...).")]
        public int MessageReceiver { get; set; }

        public bool MessageIsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
