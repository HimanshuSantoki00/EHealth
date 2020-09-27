using AutoMapper;
using EH.Entities;
using EH.Entities.Repository;
using EH.Entities.Responses;
using EH.Repository.ContactRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EH.ApplicationServer.ApiHelper
{
    public static class ApplicationExtension
    {
        public static IActionResult SendHttpResponse<TModel>(this IListData<TModel> response)
        {
            return new JsonResult(response) { StatusCode = (int)response.StatusCode };
        }

        public static IActionResult SendHttpResponse<TModel>(this IData<TModel> response)
        {
            return new JsonResult(response) { StatusCode = (int)response.StatusCode };
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IContactRepository, ContactRepository>();
        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(obj => obj.UseSqlServer(configuration["ConnectionStrings:DBConnection"]));
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
