using BaseUserManagement.Application;
using BaseUserManagement.Domain;
using BaseUserManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add containers.
builder.Services.AddControllers();
builder.Services.AddApplicationConfigurations(builder.Configuration);
builder.Services.AddDomainConfigurations(builder.Configuration);
builder.Services.AddInfrastructureConfigurations(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();