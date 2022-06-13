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
    public interface IMessageService : IGenericService<Message, DtoMessage>
    {
        IResponse<List<DtoMessage>> MessageSender(int Admin, int User);

        //Ekleme, Kaydetme
        IResponse<DtoMessage> Add(DtoMessage item, bool saveChanges = true);


    }
}
