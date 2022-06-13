using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoMessage : DtoBase
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageText { get; set; }
        public int MessageSender { get; set; }
        public int MessageReceiver { get; set; }
        public bool MessageIsRead { get; set; }
        public DateTime MessageDate { get; set; }

    }
}
