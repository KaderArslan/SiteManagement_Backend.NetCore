using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IBillAdminRepository
    {
        //Find, Getirme
        Bill Find(int id);

        //Listeleme
        List<Bill> GetAll();

        //Ekleme, Kaydetme
        Bill Add(Bill item);

        //Guncelleme 
        Bill Update(Bill item);

        //Silme
        bool Delete(int id);
    }
}
