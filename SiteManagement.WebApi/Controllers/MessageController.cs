using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using System.Collections.Generic;

namespace SiteManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MessageController
    {
        private readonly IMessageService messageService;
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet("MessageSender")]
        public IResponse<List<DtoMessage>> MessageSender(int User, int Admin)
        {
            try
            {
                return messageService.MessageSender(User, Admin);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("Add")]
        public IResponse<DtoMessage> Add(DtoMessage entity)
        {
            try
            {
                return messageService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoMessage>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
