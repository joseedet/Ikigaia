using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistencia;
using Persistencia.Interface;
using Persistencia.Repository;

namespace WebAPI
{ 
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IkigaiContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
            }
            else
            {
                var conn = configuration.GetConnectionString("Mariadb");
                services.AddDbContext<IkigaiContext>(options => options.UseMySql(conn,
                ServerVersion.AutoDetect(conn)
                ));
                var construc=services.AddIdentityCore<Usuario>();
                var identitybuilder=new IdentityBuilder(construc.UserType,construc.Services);
                identitybuilder.AddEntityFrameworkStores<IkigaiContext>();
                identitybuilder.AddSignInManager<SignInManager<Usuario>>();
            }

            services.AddScoped<IAplicationContext>(provider => provider.GetRequiredService<IkigaiContext>());

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(BaseRepository<>));
            //services.AddTransient<ICustomPostRepository, CustomPostRepository>();

            return services;
        }
    }
}