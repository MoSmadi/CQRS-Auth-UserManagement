using BaseUserManagement.Api.Middlewares;
using BaseUserManagement.Application;
using BaseUserManagement.Domain;
using BaseUserManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

const string database = "BusinessBoost";
const string server = "MOHAMMAD-SMADI\\SQLEXPRESS";

var builder = WebApplication.CreateBuilder(args);
var connectionString = $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True;";

// Add containers.
builder.Services.AddControllers();
builder.Services.AddApplicationConfigurations(builder.Configuration);
builder.Services.AddDomainConfigurations(builder.Configuration);
builder.Services.AddInfrastructureConfigurations(builder.Configuration);
builder.Services.AddDbContext<BaseDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    }
);
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