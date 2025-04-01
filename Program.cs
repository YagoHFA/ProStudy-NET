﻿using ProStudy_NET.Component.DB;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Repository.Classes;
using ProStudy_NET.Repository.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Isso é necessário para Swagger

builder.Services.AddDbContext<ProStudyDB>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
)); 
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "ProStudy-NET API Documentation",
        Version = "1.0.0"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
        Type         = SecuritySchemeType.Http,
        Scheme       = "bearer",
        BearerFormat = "JWT",
        Description  = "Enter JWT token in the format: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation v1");
        c.RoutePrefix = "swagger"; // Acessível em /swagger
    });

}


app.MapControllers();
app.Run();
