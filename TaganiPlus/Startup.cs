namespace TaganiPlus
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using AutoMapper;
    using Entities.Entities;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Repo.Interfaces;
    using Repo.Repositories;
    using Services;
    using Services.Interfaces;
    using Services.Services;
    using TaganiPlus.AutoMapperProfiles;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<TaganiContext>(options => options.UseSqlServer(this.Configuration["ConnectionStrings:Tagani"]));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "TaganiPlus Web API",
                    Version = "v1",
                    Description = "API Documentation for TaganiPlus"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddControllers();
            services.AddAutoMapper(typeof(ApiProfile), typeof(ServiceProfile));
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = this.Configuration["Jwt:Issuer"],
                        ValidAudience = this.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"]))
                    };
                });

            RegisterServices(ref services);
            RegisterRepositories(ref services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaganiPlus Web API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(ref IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IUsersService, UsersService>();
        }

        private static void RegisterRepositories(ref IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
        }
    }
}
