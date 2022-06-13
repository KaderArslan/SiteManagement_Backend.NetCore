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
    public class ApartmentAdminManager : GenericManager<Apartment, DtoApartmentAdmin>, IApartmentAdminService
    {
        public readonly IApartmentAdminRepository apartmentAdminRepository;

        public ApartmentAdminManager(IServiceProvider service) : base(service)
        {
            apartmentAdminRepository = service.GetService<IApartmentAdminRepository>();
        }

        public IResponse<DtoApartmentAdmin> Add(DtoApartmentAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Apartment>(item);

                var result = apartmentAdminRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoApartmentAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Apartment, DtoApartmentAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoApartmentAdmin>
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
                apartmentAdminRepository.Delete(id);
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

        public IResponse<List<DtoApartmentAdmin>> GetAllApartments()
        {
            try
            {
                var list = apartmentAdminRepository.GetAllApartments();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoApartmentAdmin>(x)).ToList();

                return new Response<List<DtoApartmentAdmin>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<DtoApartmentAdmin>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


        public IResponse<DtoApartmentAdmin> Update(DtoApartmentAdmin item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Apartment>(item);

                var result = apartmentAdminRepository.Update(model);

                if (saveChanges)
                    Save();

                return new Response<DtoApartmentAdmin>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<Apartment, DtoApartmentAdmin>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoApartmentAdmin>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
