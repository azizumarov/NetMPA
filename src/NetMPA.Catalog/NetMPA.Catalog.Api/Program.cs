using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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

app.Run();
