using System.ComponentModel;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Shared;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddControllers(o =>
    {
        // can be replaced (entirely? / NET7+) with duck-typed TryParse method
        o.ModelBinderProviders.Insert(0, new BinderProvider());
        TypeDescriptor.AddAttributes(typeof(ResourceUrl), new TypeConverterAttribute(typeof(ResourceUrlTypeConverter)));
    })
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new ResourceUrlJsonConverter());
    });
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(o =>
{
    o.MapType<ResourceUrl>(() => new OpenApiSchema {Type = "string"});
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
