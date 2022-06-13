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
    public class UserLoginManager : GenericManager<User, DtoUser>, IUserLoginService
    {
        public readonly IUserLoginRepository userLoginRepository;
        private IConfiguration configuration;

        public UserLoginManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userLoginRepository = service.GetService<IUserLoginRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoUserToken> Login(DtoULogin login)
        {
            var user = userLoginRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoUserLogin>(user);

                var token = new UserTokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoUserToken()
                {
                    DtoUserLogin = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoUserToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoUserToken>
                {
                    Message = "Kullanıcı maili ya da parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}
