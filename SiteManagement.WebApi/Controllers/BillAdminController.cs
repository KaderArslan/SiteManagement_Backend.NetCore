using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.Base;
using SiteManagement.Entity.Dto;
using SiteManagement.Entity.IBase;
using SiteManagement.Entity.Models;
using SiteManagement.Interface;
using SiteManagement.WebApi.Base;
using System;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillAdminController : ApiBaseController<IBillAdminService, Bill, DtoBillAdmin>
    {
        private readonly IBillAdminService billAdminService;

        public BillAdminController(IBillAdminService billAdminService) : base(billAdminService)
        {
            this.billAdminService = billAdminService;
        }

        [HttpPost("Add")]
        public IResponse<DtoBillAdmin> Add(DtoBillAdmin entity)
        {
            try
            {
                return billAdminService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoBillAdmin>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                return billAdminService.DeleteById(id);
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = false
                };
            }
        }

        [HttpPut("Update")]
        public IResponse<DtoBillAdmin> Update(DtoBillAdmin entity)
        {
            try
            {
                return billAdminService.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoBillAdmin>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


    }
}
