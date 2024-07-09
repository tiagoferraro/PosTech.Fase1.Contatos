using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Services;
using PosTech.Fase1.Contatos.Application.Validators;
using PosTech.Fase1.Contatos.Infra.Interfaces;
using PosTech.Fase1.Contatos.Infra.Repository;

namespace PosTech.Fase1.Contatos.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {

            services.AddScoped<IDDDRepository, DDDRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();

            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IDDDService, DDDService>();

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<DDDDto>, DDDValidator>();

            return services;
        }
    }
}
