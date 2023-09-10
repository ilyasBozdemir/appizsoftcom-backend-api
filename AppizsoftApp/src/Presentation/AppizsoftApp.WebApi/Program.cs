using AppizsoftApp.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppizsoftApp.WebApi  V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "AppizsoftApp.WebApi V2", Version = "v2" });

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


builder.Services.AddApplicationRegistration();


builder.Services.
AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

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

app.MapControllers();

app.Run();
