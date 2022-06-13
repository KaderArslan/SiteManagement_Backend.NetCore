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
    public class BillManager : GenericManager<Bill, DtoBill>, IBillService
    {
        public readonly IBillRepository billRepository;

        public BillManager(IServiceProvider service) : base(service)
        {
            billRepository = service.GetService<IBillRepository>();
        }
    }
}
