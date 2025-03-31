using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProStudy_NET.Component.DB;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Repository.Classes;
using ProStudy_NET.Repository.Interfaces;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddDbContext<ProStudyDB>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
)); 
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello, World!");
app.MapControllers();

app.Run();