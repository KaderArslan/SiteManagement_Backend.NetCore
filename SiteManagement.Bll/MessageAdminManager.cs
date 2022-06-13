using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Base;
using SiteManagement.Entity.Dto;
using SiteManagement.Entity.IBase;
using SiteManagement.Entity.Models;
using SiteManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Bll
{
    public class MessageAdminManager : GenericManager<Message, DtoMessageAdmin>, IMessageAdminService
    {
        public readonly IMessageAdminRepository messageAdminRepository;

        public MessageAdminManager(IServiceProvider service) : base(service)
        {
            messageAdminRepository = service.GetService<IMessageAdminRepository>();
        }

        public IResponse<DtoMessageAdmin> Add(DtoMessageAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Message>(item);

                var result = messageAdminRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoMessageAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Message, DtoMessageAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoMessageAdmin>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                messageAdminRepository.Delete(id);
                if (saveChanges)
                    Save();

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
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

        public IResponse<List<DtoMessageAdmin>> MessageSender(int Admin, int User)
        {
            try
            {
                var list = messageAdminRepository.MessageSender(Admin, User);
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessageAdmin>(x)).ToList();

                return new Response<List<DtoMessageAdmin>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<DtoMessageAdmin> Update(DtoMessageAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Message>(item);

                var result = messageAdminRepository.Update(model);

                if (saveChanges)
                    Save();

                return new Response<DtoMessageAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<Message, DtoMessageAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoMessageAdmin>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
