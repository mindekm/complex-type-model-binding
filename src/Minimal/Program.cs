using System.Reflection;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using Shared;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(o =>
{
    o.MapType<ResourceUrl>(() => new OpenApiSchema {Type = "string"});
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
services.Configure<JsonOptions>(o =>
{
    o.SerializerOptions.Converters.Add(new ResourceUrlJsonConverter());
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app
    .MapGet("/from-query", (ResourceUrl resource) =>
    {
        return new ResponseDto
        {
            Resource = resource,
            Server = resource.Server,
            Tenant = resource.Tenant,
            Identifier = resource.Identifier
        };
    })
    .WithDescription("https://service.company.com/tenant1/resource/_PzMFA-0euRFGdaqlbGTDxT")
    .WithOpenApi();
app
    .MapPost("/from-json", (JsonRequestDto dto) =>
    {
        return new ResponseDto
        {
            Resource = dto.Resource,
            Server = dto.Resource.Server,
            Tenant = dto.Resource.Tenant,
            Identifier = dto.Resource.Identifier
        };
    });
app.Run();