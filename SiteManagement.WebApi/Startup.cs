using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SiteManagement.Bll;
using SiteManagement.Dal.Abstract;
using SiteManagement.Dal.Concrete.Entityframework.Context;
using SiteManagement.Dal.Concrete.Entityframework.Repository;
using SiteManagement.Dal.Concrete.Entityframework.UnitOfWork;
using SiteManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.WebApi
{
    public class Startup   
    {
        readonly string ApiCorsPolicy = "AllowOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region JwtTokenService
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;

                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        //validate doðrulama
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        RequireSignedTokens = true, //token zorunlu mu
                        RequireExpirationTime = true
                    };
                }
                );
            #endregion

            #region ApplicationContext

            services.AddDbContext<SiteManagementContext>();

            services.AddScoped<DbContext, SiteManagementContext>();

            #endregion

            #region ServiceSection
            //IAdminService cagirildiginda AdminManager dan kendini turet
            //services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminLoginService, AdminLoginManager>();

            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IApartmentAdminService, ApartmentAdminManager>();

            services.AddScoped<IBillService, BillManager>();
            services.AddScoped<IBillAdminService, BillAdminManager>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageAdminService, MessageAdminManager>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserAdminService, UserAdminManager>();
            services.AddScoped<IUserLoginService, UserLoginManager>();

            #endregion

            #region RepositorySection
            //genericte burada yazilir
            //services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminLoginRepository, AdminLoginRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAdminRepository, UserAdminRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentAdminRepository, ApartmentAdminRepository>();

            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillAdminRepository, BillAdminRepository>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageAdminRepository, MessageAdminRepository>();

            #endregion

            #region UnitOfWork
            //UnitOfWork aktif etmezsek yoksa kaydetme silme islemleri olmaz listeleme olur unitofWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(ApiCorsPolicy,
                    builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SiteManagement.WebApi", Version = "v1" });
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SiteManagement.WebApi v1"));
            }


            //var app = builder.Build();
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(ApiCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
