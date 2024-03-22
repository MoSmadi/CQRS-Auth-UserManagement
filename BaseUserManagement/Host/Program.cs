using BaseUserManagement.Api.Middlewares;
using BaseUserManagement.Application;
using BaseUserManagement.Domain;
using BaseUserManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add containers.
builder.Services.AddControllers();
builder.Services.AddApplicationConfigurations(builder.Configuration);
builder.Services.AddDomainConfigurations(builder.Configuration);
builder.Services.AddInfrastructureConfigurations(builder.Configuration);

builder.Services.AddScoped<AuthenticationMiddleware>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthenticationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();