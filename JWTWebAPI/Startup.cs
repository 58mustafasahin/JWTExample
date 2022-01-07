using JWTBusiness.Abstract;
using JWTBusiness.Concrete;
using JWTDAL.Context;
using JWTDAL.LoginSecurity.Encryption;
using JWTDAL.LoginSecurity.Entity;
using JWTDAL.LoginSecurity.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace JWTWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //  https://code-maze.com/swagger-ui-asp-net-core-web-api/
            //  Build->Errors and warnings-> 1701;1702;1591
            //  Output-> ✓ XML documentation file:
            services.AddSwaggerGen(c =>
            { 
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTWebAPI", Version = "v1",
                    Description = "An API to perform JWT operations",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mustafa ŞAHİN",
                        Email = "58.mustafasahin@gmail.com",
                        Url = new Uri("https://github.com/58mustafasahin"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "JWT API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            //Adding Db context
            services.AddDbContext<JWTDbContext>();
            //Adding services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, TokenHelper>();


            //JWT configurations
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtOption =>
            {
                jwtOption.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWTWebAPI v1"));
            }

            app.UseRouting();
            //activateto use Authenticate process
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
