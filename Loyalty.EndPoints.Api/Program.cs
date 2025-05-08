using Keycloak.AuthServices.Authentication;
using Loaylty.Infrastructure;
using Loaylty.Infrastructure.Persistence.Common;
using Loyalty.Application;
using Loyalty.EndPoints.Api.Extensions;
using Loyalty.EndPoints.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationSwagger(builder.Configuration).AddAuth(builder.Configuration);


builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis"];
});


builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseApplicationSwagger(builder.Configuration)
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();


app.Run();
