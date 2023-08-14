using Security.AdapterInHttp.Extensions;
using Security.AdapterOutRepository;
using Security.Application;

var builder = WebApplication.CreateBuilder(args);
string AppName = "MS Security - F2X project";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddRepository();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureVersioning();

var app = builder.Build();

app.AllowSwaggerToListApiVersions(AppName);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
