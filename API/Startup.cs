using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
       
        //2.13{
             private readonly IConfiguration _config;
        //}2.13
        public Startup(IConfiguration config/*(2.13)configuration*/)
        {
            

            //2.13{
            _config = config;
            //  Configuration = configuration;

            //}2.13
        }
//2.13{
   //     public IConfiguration Configuration { get; }
//}2.13
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
/*
//4.41{
    services.AddScoped<ITokenService, TokenService>();

//2.12{
            services.AddDbContext<DataContext>(options =>{
          //      options.UseSqlite("Connection string");
                 options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
          
            });

//}2.12  */
//4.45{
services.AddApplicationServices(_config);
      //}4.45
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    
            });
            //3.24{
            services.AddCors();
        //}3.24

/*
        //4.44{
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters=new TokenValidationParameters{
                ValidateIssuerSigningKey=true,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                ValidateIssuer=false,
                ValidateAudience=false
            };
        });
        //}4.44    */
        services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
//3.24{
      //      app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
//}3.24
//3.28{
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
//}3.28

       //4.44{  
          app.UseAuthentication();
         //}4.44
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
