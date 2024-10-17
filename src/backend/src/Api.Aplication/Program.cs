using Api.Aplication.Configs;
using Infra.UPX4.Ioc.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var config = new Configs(builder.Services, builder.Configuration);
new Swagger(builder.Services, builder.Configuration).Configure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

InjectAllDependencies.Configure(builder.Services, config.AuthToken());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
