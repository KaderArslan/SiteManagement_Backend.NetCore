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
    public class BillController : ApiBaseController<IBillService, Bill, DtoBill>
    {
        private readonly IBillService billService;

        public BillController(IBillService billService) : base(billService)
        {
            this.billService = billService;
        }
    }
}
