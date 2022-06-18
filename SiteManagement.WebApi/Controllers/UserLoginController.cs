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
    [Route("")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService userLoginService;

        public UserLoginController(IUserLoginService userLoginService)
        {
            this.userLoginService = userLoginService;
        }

        [HttpPost("user")]
        [AllowAnonymous]
        //token olmadan da bu işlemi gerçekleştir.
        public IResponse<DtoUserToken> Login(DtoULogin login)
        {
            try
            {
                return userLoginService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoUserToken>
                {
                    Message = "Error :" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

    }
}
