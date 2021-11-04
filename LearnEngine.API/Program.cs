using AutoMapper;
using FluentValidation.AspNetCore;
using LearnEngine.API.Attributes;
using LearnEngine.API.Filters;
using LearnEngine.API.Installers;
using LearnEngine.API.Ioc;
using LearnEngine.Application.Exceptions;
using LearnEngine.Application.Mappers.AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    //c.SchemaFilter<EnumSchemaFilter>();
});

var assembly = AppDomain.CurrentDomain.Load("LearnEngine.Application");
builder.Services.AddMediatR(assembly);

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ValidatorModelFilterAttribute));
}).AddFluentValidation(fv =>
{
    fv.DisableDataAnnotationsValidation = true;
    fv.RegisterValidatorsFromAssembly(assembly);
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddSingleton<HttpExceptionHelper>();

#region automapper

builder.Services.AddAutoMapper(assembly);
MapperConfiguration mapperConfig = new(mc =>
{
    mc.AddProfile(new MaterialProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

builder.Services.AddRepositories();
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



