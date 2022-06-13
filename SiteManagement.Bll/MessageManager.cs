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
    public class MessageManager : GenericManager<Message, DtoMessage>, IMessageService
    {
        public readonly IMessageRepository messageRepository;

        public MessageManager(IServiceProvider service) : base(service)
        {
            messageRepository = service.GetService<IMessageRepository>();
        }

        public IResponse<DtoMessage> Add(DtoMessage item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Message>(item);

                var result = messageRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoMessage>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Message, DtoMessage>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoMessage>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<DtoMessage>> MessageSender(int Admin, int User)
        {
            try
            {
                var list = messageRepository.MessageSender(Admin, User);
                //liste cekmek bu sekilde, digerleri nesneydi
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessage>(x)).ToList();

                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

    }
}
