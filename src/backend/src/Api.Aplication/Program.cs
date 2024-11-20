using Api.UPX4.Configs;
using Infra.UPX4.Ioc.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var config = new Configs(builder.Services, builder.Configuration);
new Swagger(builder.Services, builder.Configuration).Configure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

InjectAllDependencies.Configure(builder.Services, config.AuthToken());



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permite todas as origens
              .AllowAnyMethod() // Permite todos os métodos (GET, POST, etc.)
              .AllowAnyHeader(); // Permite todos os cabeçalhos
    });
});

var app = builder.Build();

// Use o CORS na aplicação
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
