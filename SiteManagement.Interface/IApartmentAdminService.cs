using SiteManagement.Entity.Dto;
using SiteManagement.Entity.IBase;
using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Interface
{
    public interface IApartmentAdminService : IGenericService<Apartment, DtoApartmentAdmin>
    {
        //Find, Getirme
        IResponse<DtoApartmentAdmin> Find(int id);

        //Listeleme
        IResponse<List<DtoApartmentAdmin>> GetAllApartments();

        //Ekleme, Kaydetme
        IResponse<DtoApartmentAdmin> Add(DtoApartmentAdmin item, bool saveChanges = true);

        //Guncelleme
        IResponse<DtoApartmentAdmin> Update(DtoApartmentAdmin item, bool saveChanges = true);

        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);

    }
}
