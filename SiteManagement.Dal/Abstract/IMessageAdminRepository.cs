using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IMessageAdminRepository
    {
        List<Message> MessageSender(int Admin, int User);

        //Find, Getirme
        Message Find(int id);

        //Listeleme
        List<Message> GetAll();

        //Ekleme, Kaydetme
        Message Add(Message item);

        //Guncelleme 
        Message Update(Message item);

        //Silme
        bool Delete(int id);
    }
}
