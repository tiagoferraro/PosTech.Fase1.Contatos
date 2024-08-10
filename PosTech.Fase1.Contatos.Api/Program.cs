using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Api.Filter;
using PosTech.Fase1.Contatos.Application.Validators;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.IoC;
using System.Reflection;
#pragma warning disable S1118

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.
    AddControllers(options => options.Filters
    .Add(typeof(ModelStateValidatorFilter)))
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddDbContext<AppDBContext>();

builder.Services.AdicionarDependencias();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public partial class Program { }
