using System.Text;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System;
using System.Collections.Immutable;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.TryAddSingleton<TimeProvider>(TimeProvider.System);
//builder.Services.AddDependencyInjection(builder.Configuration);

var conn = builder.Configuration.GetConnectionString("Mariadb");
builder.Services.AddDbContext<IkigaiContext>(options => options.UseMySql(conn,
                ServerVersion.AutoDetect(conn)
                ));
                /* var construc=builder.Services.AddIdentityCore<Usuario>();
                var identitybuilder=new IdentityBuilder(construc.UserType,construc.Services);
                identitybuilder.AddEntityFrameworkStores<IkigaiContext>();
                identitybuilder.AddSignInManager<SignInManager<Usuario>>();  */
            
builder.Services.AddScoped<IkigaiContext>(provider => provider.GetRequiredService<IkigaiContext>());

/* builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IReadRepository<>), typeof(BaseRepository<>)); */
                

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using(var ambiente=app.Services.CreateScope()){
    /* var services=ambiente.ServiceProvider;
    try{
        var _userManager=services.GetRequiredService<UserManager<Usuario>>();
        var context=services.GetRequiredService<IkigaiContext>();
        context.Database.Migrate();
        await DatosPrueba.InsertarData(context, _userManager);
    }
    catch (Exception e){
        var logging=services.GetRequiredService<ILogger<Program>>();
        logging.LogError(e,"Ocurrió un error en la migración");
    } */
} 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
