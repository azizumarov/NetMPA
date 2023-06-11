using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using NetMPA.Catalog.Api.Configuration;
using NetMPA.Catalog.Api.Controllers.Mappers;
using NetMPA.Catalog.Bll.Configuration;
using NetMPA.Catalog.Dal.Configuration;
using NetMPA.Catalog.Dal.SqlContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
    setup.ApiVersionReader = ApiVersionReader.Combine(
       new UrlSegmentApiVersionReader(),
       new HeaderApiVersionReader("api-version"),
       new QueryStringApiVersionReader("api-version"),
       new MediaTypeApiVersionReader("version"));
});


builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var configuration = builder.Configuration;

builder.Services.ConfigureBll();
builder.Services.ConfigureDal(configuration);
builder.Services.ConfigureMassTransit(configuration);


var config = new MapperConfiguration(cfg =>
{
    CatalogMapperConfiguration.ConfigureMappings(cfg);
});

config.AssertConfigurationIsValid();
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();

app.UseSwaggerUI(options =>
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    if (provider == null) return;

    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseRouting(); 

app.UseAuthorization(); 

app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); 

app.UseHttpsRedirection();

app.MapControllers();

using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
using var context = serviceScope?.ServiceProvider.GetRequiredService<CatalogContext>();


app.Run();
