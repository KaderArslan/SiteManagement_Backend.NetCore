using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IApartmentAdminRepository
    {
        //Find, Getirme
        Apartment Find(int id);

        //Listeleme
        List<Apartment> GetAllApartments();

        //Ekleme, Kaydetme
        Apartment Add(Apartment item);

        //Guncelleme 
        Apartment Update(Apartment item);

        //Silme
        bool Delete(int id);
    }
}
