using Collected.AdapterInHttp.Extensions;
using Collected.AdapterOutRepository;
using Collected.AdapterOutReport;
using Collected.AdapterOutRepository.SqlServerDB;
using Collected.Application;
using Collected.AdapterOutF2XService;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader();
                      });
});

string AppName = "MS Collected - F2X project";
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();
// Add services to the container.
builder.Services.AddJwtCustomized(configuration);
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddRepository();
builder.Services.AddReport();
builder.Services.AddF2XServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenCustomized(AppName);
builder.Services.ConfigureVersioning();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.AllowSwaggerToListApiVersions(AppName);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
