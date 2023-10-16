using Microsoft.EntityFrameworkCore;
using Proj.Manager.Application;
using Proj.Manager.Core;
using Proj.Manager.Infrastructure;
using Proj.Manager.Infrastructure.Persistence.SQLServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("SqlServerDBContext");

builder.Services.ApplicationServices();
builder.Services.CoreServices();
builder.Services.InfrastructureServices();

builder.Services.AddDbContext<SqlServerDBContext>(o => o.UseSqlServer(conn));

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
