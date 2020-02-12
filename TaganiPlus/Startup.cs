namespace TaganiPlus
{
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
