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
    public interface IMessageAdminService : IGenericService<Message, DtoMessageAdmin>
    {
        IResponse<List<DtoMessageAdmin>> MessageSender(int Admin, int User);

        //Find, Getirme
        IResponse<DtoMessageAdmin> Find(int id);

        //Listeleme
        IResponse<List<DtoMessageAdmin>> GetAll();

        //Ekleme, Kaydetme
        IResponse<DtoMessageAdmin> Add(DtoMessageAdmin item, bool saveChanges = true);

        //Guncelleme
        IResponse<DtoMessageAdmin> Update(DtoMessageAdmin item, bool saveChanges = true);

        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);


    }
}
