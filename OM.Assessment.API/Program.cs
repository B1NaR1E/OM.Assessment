using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OM.Assessment.API.Configs;
using OM.Assessment.API.Extensions;
using OM.Assessment.API.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddHealthChecks();
services.AddSwagger(builder.Configuration);

// Load configurations
var dataApiSettings = builder.Configuration.GetSection(nameof(DataApiConfig));
services.Configure<DataApiConfig>(dataApiSettings);

var swaggerSettings = builder.Configuration.GetSection(nameof(SwaggerSettings));
services.Configure<SwaggerSettings>(swaggerSettings);

// Register Services
services.AddSingleton<ICountryService, CountryService>();

services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
        }
    ));

// App
var app = builder.Build();

app.UseRouting();
app.UseSwagger(builder.Configuration);
app.UseCors("CorsPolicy");
app.MapControllers();
app.UseHealthChecks();

app.Run();