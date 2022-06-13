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
    public class MessageAdminController : ApiBaseController<IMessageAdminService, Message, DtoMessageAdmin>
    {
        private readonly IMessageAdminService messageAdminService;
        public MessageAdminController(IMessageAdminService messageAdminService) : base(messageAdminService)
        {
            this.messageAdminService = messageAdminService;
        }

        [HttpGet("MessageSender")]
        //[AllowAnonymous]
        public IResponse<List<DtoMessageAdmin>> MessageSender(int Admin, int User)
        {
            try
            {
                return messageAdminService.MessageSender(Admin, User);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoMessageAdmin>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("Add")]
        public IResponse<DtoMessageAdmin> Add(DtoMessageAdmin entity)
        {
            try
            {
                return messageAdminService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoMessageAdmin>()
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
                return messageAdminService.DeleteById(id);
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
        public IResponse<DtoMessageAdmin> Update(DtoMessageAdmin entity)
        {
            try
            {
                return messageAdminService.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoMessageAdmin>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
