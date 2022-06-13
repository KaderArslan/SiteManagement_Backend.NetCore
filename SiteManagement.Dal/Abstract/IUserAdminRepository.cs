using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Abstract
{
    public interface IUserAdminRepository
    {
        //Find, Getirme
        User Find(int id);

        //Listeleme
        List<User> GetAll();

        //Ekleme, Kaydetme
        User Add(User item);

        //Guncelleme 
        User Update(User item);

        //Silme
        bool Delete(int id);
    }
}
