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
    public class UserAdminController : ApiBaseController<IUserAdminService, User, DtoUserAdmin>
    {
        private readonly IUserAdminService userAdminService;

        public UserAdminController(IUserAdminService userAdminService) : base(userAdminService)
        {
            this.userAdminService = userAdminService;
        }

        [HttpPost("Add")]
        public IResponse<DtoUserAdmin> Add(DtoUserAdmin entity)
        {
            try
            {
                return userAdminService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoUserAdmin>()
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
                return userAdminService.DeleteById(id);
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
        public IResponse<DtoUserAdmin> Update(DtoUserAdmin entity)
        {
            try
            {
                return userAdminService.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoUserAdmin>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


    }
}
