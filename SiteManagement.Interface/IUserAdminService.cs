using SiteManagement.Entity.Dto;
using SiteManagement.Entity.IBase;
using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Interface
{
    public interface IUserAdminService : IGenericService<User, DtoUserAdmin>
    {
        //Find, Getirme
        IResponse<DtoUserAdmin> Find(int id);

        //Listeleme
        IResponse<List<DtoUserAdmin>> GetAll();

        //Ekleme, Kaydetme
        IResponse<DtoUserAdmin> Add(DtoUserAdmin item, bool saveChanges = true);
        //Response AddEmployee(DtoUserAdmin user);

        //Guncelleme
        IResponse<DtoUserAdmin> Update(DtoUserAdmin item, bool saveChanges = true);

        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
    }
}
