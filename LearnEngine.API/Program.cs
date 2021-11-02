using LearnEngine.API.Filters;
using LearnEngine.API.Ioc;
using LearnEngine.Infrastucture.Ioc;
using LearnEngine.Infrastucture.Ioc.Filters;
using MediatR;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.SchemaFilter<EnumSchemaFilter>();
});

var assembly = AppDomain.CurrentDomain.Load("LearnEngine.Application");
builder.Services.AddMediatR(assembly);


builder.Services.AddMongoConfigurationSettings(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



