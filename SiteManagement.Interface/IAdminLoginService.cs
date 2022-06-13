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
    public interface IAdminLoginService : IGenericService<Admin, DtoAdmin>
    {
        //Admin Login
        IResponse<DtoAdminToken> Login(DtoALogin login);
    }
}
