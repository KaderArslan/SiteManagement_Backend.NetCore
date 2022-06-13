using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IMessageRepository
    {
        List<Message> MessageSender(int Admin, int User);

        //Ekleme, Kaydetme
        Message Add(Message item);
    }
}
