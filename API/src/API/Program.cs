using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Template.API.Configurations.Filters;
using Template.API.Configurations.Middlewares;
using Template.API.Configurations.Swagger;
using Template.Application.Configurations;
using Template.Infra.CrossCutting.IoC;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutomapperConfiguration));
builder.Services.SetIoCServices(builder.Configuration);
builder.Services.SetIoCRepositories(builder.Configuration);
builder.Services.AddMvc(option => option.Filters.Add<NotificationFilter>());
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGenConfigurationOptions>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"../swagger/{description.GroupName}/swagger.json", 
            description.GroupName.ToUpperInvariant());
    }
});

app.UserExceptions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
