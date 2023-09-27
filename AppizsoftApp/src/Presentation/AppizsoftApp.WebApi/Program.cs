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
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using AppizsoftApp.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



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
        Description = "Appizsoft Yazýlým v1 Backend Web API arayüzüdür.",
        Contact = new OpenApiContact()
        {
            Name = "Appizsoft Yazýlým",
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
        Description = "Appizsoft Yazýlým v2 Backend Web API arayüzüdür.",
        Contact = new OpenApiContact()
        {
            Name = "Appizsoft Yazýlým",
            Email = "info@appizsoft.com",
            Url = new Uri("https://appizsoft.com")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Bearer token kullanýmýný etkinleþtir
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
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

#region Rate Limiter  Services Register

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Basic", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(5);
        _options.PermitLimit = 4;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});


#endregion

#region Jwt Ayarý servise eklenmesi

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = issuer, // JWT'nin geçerli olduðu yayýncý (issuer)
    ValidAudience = audience, // JWT'nin geçerli olduðu hedef kitle (audience)
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // JWT'nin doðrulanmasý için kullanýlan anahtar
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = tokenValidationParameters;
        });

// TokenValidationParameters'ý servis olarak kaydet
builder.Services.AddSingleton(tokenValidationParameters);

#endregion

#region Katmanlarýn servis kayýtlarý

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

#region #region Rate Limiter middleware

app.UseRateLimiter();

#endregion


app.UseHttpsRedirection();

app.UseMiddleware<AuthorizationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

#region Cors middleware
app.UseCors("AllowLocalhost3000");
#endregion


app.MapControllers();
app.Run();
