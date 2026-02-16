using ProStudy_NET.Component.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Security.Services;
using Microsoft.OpenApi;


DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddEnvironmentVariables();
string databaseType = builder.Configuration.GetValue<string>("DatabaseSettings:DatabaseType")!;

if (databaseType.Equals("MSSQL"))
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
        Title = "ProStudy API",
        Description = "An API designed to manage study skills and abilities for the tech world.",
        Version = "1.0.1"
    });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using Bearer scheme"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

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

app.MapGet("/", () => "API running");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
