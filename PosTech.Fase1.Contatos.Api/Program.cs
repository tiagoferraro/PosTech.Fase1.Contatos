
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using PosTech.Fase1.Contatos.Api.Filter;
using PosTech.Fase1.Contatos.Application.Validators;
using PosTech.Fase1.Contatos.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers(options => options.Filters
  .Add(typeof(ModelStateValidatorFilter)));
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<DDDValidator>();



builder.Services.AdicionarDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
