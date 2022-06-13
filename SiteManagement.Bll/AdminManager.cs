using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Dto;
using SiteManagement.Entity.Models;
using SiteManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Bll
{
    public class AdminManager : GenericManager<Admin, DtoAdmin>, IAdminService
    {
        public readonly IAdminRepository adminRepository;

        public AdminManager(IServiceProvider service) : base(service)
        {
            adminRepository = service.GetService<IAdminRepository>();
        }
    }
}
