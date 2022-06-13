using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.Dto;
using SiteManagement.Entity.Models;
using SiteManagement.Interface;
using SiteManagement.WebApi.Base;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApartmentController : ApiBaseController<IApartmentService, Apartment, DtoApartment>
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService) : base(apartmentService)
        {
            this.apartmentService = apartmentService;
        }
    }
}
