using AutoMapper;
using FluentValidation.AspNetCore;
using LearnEngine.API.Attributes;
using LearnEngine.API.Installers;
using LearnEngine.API.Ioc;
using LearnEngine.Application.Commands.Material.Helper;
using LearnEngine.Application.Helpers;
using LearnEngine.Application.Mappers.AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
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

builder.Services.AddApiVersioning(opt =>
{
    opt.ReportApiVersions = true;
    
    opt.AssumeDefaultVersionWhenUnspecified = true;

    opt.DefaultApiVersion = ApiVersion.Default; // new ApiVersion(1, 0);

    opt.ApiVersionReader = ApiVersionReader.Combine(
            new MediaTypeApiVersionReader("x-api-version"),
            new HeaderApiVersionReader("x-api-version")
);
});

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
builder.Services.AddControllers();

#region automapper

builder.Services.AddAutoMapper(assembly);

MapperConfiguration mapperConfig = new(mc =>
{
    mc.AddProfile(new MaterialProfile());
    mc.AddProfile(new MaterialGroupProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

builder.Services.AddSingleton<IMaterialHelper, MaterialHelper>();

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



