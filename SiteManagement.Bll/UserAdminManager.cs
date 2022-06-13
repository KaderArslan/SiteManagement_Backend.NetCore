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
    public class UserAdminManager : GenericManager<User, DtoUserAdmin>, IUserAdminService
    {
        public readonly IUserAdminRepository userAdminRepository;

        public UserAdminManager(IServiceProvider service) : base(service)
        {
            userAdminRepository = service.GetService<IUserAdminRepository>();
        }

        public IResponse<DtoUserAdmin> Add(DtoUserAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<User>(item);

                var result = userAdminRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoUserAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<User, DtoUserAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoUserAdmin>
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
                userAdminRepository.Delete(id);
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

        public IResponse<DtoUserAdmin> Update(DtoUserAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<User>(item);

                var result = userAdminRepository.Update(model);

                if (saveChanges)
                    Save();

                return new Response<DtoUserAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<User, DtoUserAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoUserAdmin>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
