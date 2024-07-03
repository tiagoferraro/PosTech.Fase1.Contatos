using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PosTech.Fase1.Contatos.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {
            return services;
        }
    }
}
