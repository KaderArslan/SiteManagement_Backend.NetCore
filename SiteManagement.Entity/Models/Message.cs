using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteManagement.Entity.Models
{
    public partial class Message : EntityBase
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageText { get; set; }
        public int MessageSender { get; set; }
        public int MessageReceiver { get; set; }
        public bool MessageIsRead { get; set; }
        public DateTime MessageDate { get; set; }

        public virtual User MessageReceiverNavigation { get; set; }
        public virtual Admin MessageSenderNavigation { get; set; }
    }
}
