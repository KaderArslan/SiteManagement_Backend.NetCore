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
    public class AdminLoginController : ControllerBase
    {
        private readonly IAdminLoginService adminLoginService;

        public AdminLoginController(IAdminLoginService adminLoginService)
        {
            this.adminLoginService = adminLoginService;
        }

        [HttpPost("Login")]
        //[AllowAnonymous]
        //token olmadan da bu işlemi gerçekleştir.
        public IResponse<DtoAdminToken> Login(DtoALogin login)
        {
            try
            {
                return adminLoginService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoAdminToken>
                {
                    Message = "Error :" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

    }
}
