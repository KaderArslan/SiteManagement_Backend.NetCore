using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SiteManagement.Entity.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Bll
{
    public class UserTokenManager
    {
        IConfiguration configuration;

        public UserTokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //token uretecek
        public string CreateAccessToken(DtoUserLogin user)
        {

            //token parçaları
            //1. claim id gibi, usercode gibi role gibi bilgileri claimlere gomeriz
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.UserEmail),

                new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //2. claim roller admin rolü, yonetici rolu, personel rolü
            //rol keyleri
            var claimsRoleList = new List<Claim>
            {
                new Claim("role","User"),
                //new Claim("role2","Yönetici"),
                //new Claim("role3","Personel")
            };

            //3. security key, key ile sifreleme yapacagiz keyide appsettinden okucagiz configuration gibi
            //verdiğim değerin bytenı verecek
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //4. şifrelenmiş kimlik oluşturma , hangi şifreleme algoritması ile yapacaksın çektiğimiz keyi bununla şifreliceğiz
            //key ele gecirelemezse tokenı ele geçirsek dahi yeni bir token oluşturamayız
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //5. token ayarları, ne kadar süre devam etsin, hangi apilerden erişebilsin gibi ayarlar
            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:Issuer"],//token dağıtıcı url
                audience: configuration["Tokens:Issuer"],//erişilebilecek apiler
                expires: DateTime.Now.AddDays(1),//ömrü token alındıktan itibaren başlasın ve 1 gün süresini ayarladık
                //expires: DateTime.Now.AddMinutes(5),
                notBefore: DateTime.Now,//token alındıktan hemen sonra aktif olsun
                signingCredentials: cred,//şifrelenmiş keyimizi verdik, kimlik verdik
                claims: claimsIdentity.Claims//claimsleri verdik.

            );

            //6. token oluşturma sınıfı ile örnek alıp (intances aslında) üretmek burda token üretilir, üretip returnle dondureceğiz
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;

        }
    }
}
