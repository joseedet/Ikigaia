using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("Mariadb");
builder.Services.AddDbContext<IkigaiContext>(options => options.UseMySql(conn,
ServerVersion.AutoDetect(conn)
));
var construc=builder.Services.AddIdentityCore<Usuario>();
var identitybuilder=new IdentityBuilder(construc.UserType,construc.Services);
identitybuilder.AddEntityFrameworkStores<IkigaiContext>();
identitybuilder.AddSignInManager<SignInManager<Usuario>>();
builder.Services.TryAddSingleton<TimeProvider>(TimeProvider.System);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
