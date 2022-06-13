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
    public interface IBillAdminService : IGenericService<Bill, DtoBillAdmin>
    {
        //Find, Getirme
        IResponse<DtoBillAdmin> Find(int id);

        //Listeleme
        IResponse<List<DtoBillAdmin>> GetAll();

        //Ekleme, Kaydetme
        IResponse<DtoBillAdmin> Add(DtoBillAdmin item, bool saveChanges = true);

        //Guncelleme
        IResponse<DtoBillAdmin> Update(DtoBillAdmin item, bool saveChanges = true);

        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
    }
}
