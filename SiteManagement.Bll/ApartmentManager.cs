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
    public class ApartmentManager : GenericManager<Apartment, DtoApartment>, IApartmentService
    {
        public readonly IApartmentRepository apartmentRepository;

        public ApartmentManager(IServiceProvider service) : base(service)
        {
            apartmentRepository = service.GetService<IApartmentRepository>();
        }
    }
}
