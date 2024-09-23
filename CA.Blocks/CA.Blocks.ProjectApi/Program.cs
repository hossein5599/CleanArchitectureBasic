using CA.Blocks.ProjectApi.Configurations;
using Serilog;
using CA.Blocks.Application.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration, builder.Host).AddProjectServices(builder.Configuration);

builder.Host.UseSerilog();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.BaseAppUse().AppUse(builder.Configuration);

app.Run();
