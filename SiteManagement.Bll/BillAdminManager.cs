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
    public class BillAdminManager : GenericManager<Bill, DtoBillAdmin>, IBillAdminService
    {
        public readonly IBillAdminRepository billAdminRepository;

        public BillAdminManager(IServiceProvider service) : base(service)
        {
            billAdminRepository = service.GetService<IBillAdminRepository>();
        }

        public IResponse<DtoBillAdmin> Add(DtoBillAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Bill>(item);

                var result = billAdminRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoBillAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Bill, DtoBillAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoBillAdmin>
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
                billAdminRepository.Delete(id);
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

        public IResponse<DtoBillAdmin> Update(DtoBillAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Bill>(item);

                var result = billAdminRepository.Update(model);

                if (saveChanges)
                    Save();

                return new Response<DtoBillAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<Bill, DtoBillAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoBillAdmin>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
