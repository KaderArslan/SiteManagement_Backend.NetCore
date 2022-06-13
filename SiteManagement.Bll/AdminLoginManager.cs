using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    public class AdminLoginManager : GenericManager<Admin, DtoAdmin>, IAdminLoginService
    {
        public readonly IAdminLoginRepository adminLoginRepository;
        private IConfiguration configuration;

        public AdminLoginManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            adminLoginRepository = service.GetService<IAdminLoginRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoAdminToken> Login(DtoALogin login)
        {
            var admin = adminLoginRepository.Login(ObjectMapper.Mapper.Map<Admin>(login));

            if (admin != null)
            {
                var dtoAdmin = ObjectMapper.Mapper.Map<DtoAdminLogin>(admin);

                var token = new AdminTokenManager(configuration).CreateAccessToken(dtoAdmin);

                var userToken = new DtoAdminToken()
                {
                    DtoAdminLogin = dtoAdmin,
                    AccessToken = token
                };

                return new Response<DtoAdminToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoAdminToken>
                {
                    Message = "Kullanıcı maili ya da parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}
