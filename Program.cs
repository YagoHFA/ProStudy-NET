using ProStudy_NET.Component.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Security.Services;


DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddEnvironmentVariables();
string databaseType = builder.Configuration.GetValue<string>("DatabaseSettings:DatabaseType")!;

if (databaseType.Equals("MySQL"))
{
    builder.Services.AddDbContext<ProStudyDB>(options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
         ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))),
         ServiceLifetime.Scoped);
}
else if (databaseType.Equals("MSSQL"))
{
    builder.Services.AddDbContext<ProStudyDB>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")),
        ServiceLifetime.Scoped);
}
else
{
    Console.WriteLine("Invalid database type specified in appsettings.json");
}

builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
    .AddClasses(classes => classes.Where(r => r.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
    .AddClasses(classes => classes.Where(s => s.Name.EndsWith("Service")))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
);

builder.Services.AddScoped<UnitWork>();

builder.Services.AddScoped<JwtServices>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "ProStudy-NET API",
        Description = "API for leaning technology skills",
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

    c.EnableAnnotations();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtConfig = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!))
        };
    });

    builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
});

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
