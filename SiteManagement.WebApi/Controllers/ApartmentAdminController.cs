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

    public class ApartmentAdminController : ApiBaseController<IApartmentAdminService, Apartment, DtoApartmentAdmin>
    {
        private readonly IApartmentAdminService apartmentAdminService;

        public ApartmentAdminController(IApartmentAdminService apartmentAdminService) : base(apartmentAdminService)
        {
            this.apartmentAdminService = apartmentAdminService;
        }

        [HttpPost("Add")]
        public IResponse<DtoApartmentAdmin> Add(DtoApartmentAdmin entity)
        {
            try
            {
                return apartmentAdminService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoApartmentAdmin>()
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
                return apartmentAdminService.DeleteById(id);
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
        public IResponse<DtoApartmentAdmin> Update(DtoApartmentAdmin entity)
        {
            try
            {
                return apartmentAdminService.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoApartmentAdmin>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


        [HttpGet("GetAllApartments")]
        [AllowAnonymous]
        public IResponse<List<DtoApartmentAdmin>> GetAllApartments()
        {
            try
            {
                return apartmentAdminService.GetAll();
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


    }
}
