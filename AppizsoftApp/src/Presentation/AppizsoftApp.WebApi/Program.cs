using AppizsoftApp.Application;
using AppizsoftApp.Persistence;
using AppizsoftApp.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region MediatR servise eklenmesi
//builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
#endregion

#region Swagger servise eklenmesi
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "AppizsoftApp.WebApi V1",
        Version = "v1",
        Description = "Appizsoft Yaz�l�m v1 Backend Web API aray�z�d�r.",
        Contact = new OpenApiContact()
        {
            Name = "Appizsoft Yaz�l�m",
            Email = "info@appizsoft.com",
            Url = new Uri("https://appizsoft.com")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    c.SwaggerDoc("v2", new OpenApiInfo()
    {
        Title = "AppizsoftApp.WebApi V2",
        Version = "v2",
        Description = "Appizsoft Yaz�l�m v2 Backend Web API aray�z�d�r.",
        Contact = new OpenApiContact()
        {
            Name = "Appizsoft Yaz�l�m",
            Email = "info@appizsoft.com",
            Url = new Uri("https://appizsoft.com")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });




    // API versiyonlama eklemeleri
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;

        var versions = methodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(methodInfo.GetCustomAttributes(true))
            .OfType<ApiVersionAttribute>()
            .SelectMany(attr => attr.Versions);


        return versions.Any(v => $"v{v}" == docName);
    });

});

#endregion

#region Cors servise eklenmesi

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

#endregion

#region Jwt Ayar� servise eklenmesi
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });

#endregion


#region Katmanlar�n servis kay�tlar�

builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration();
builder.Services.AddInfrastructureRegistration();

#endregion

#region ApiVersioning servise eklenmesi 

builder.Services.
AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

#endregion

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appizsoft Software API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Appizsoft Software API V2");
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowLocalhost3000");
app.MapControllers();
app.Run();
