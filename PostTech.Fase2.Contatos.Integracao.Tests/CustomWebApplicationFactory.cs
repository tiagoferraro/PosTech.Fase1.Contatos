

using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.IoC;
using PostTech.Fase2.Contatos.Integracao.Tests.Fixture;
using Xunit.Extensions.Ordering;

namespace PostTech.Fase2.Contatos.Integracao.Tests;

[Collection(nameof(ContextDbCollection))]
public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly string _conectionString;
    public CustomWebApplicationFactory(string conectionString)
    {
        _conectionString = conectionString;
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AdicionarDependencias();
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(_conectionString);
            });
        });

        builder.UseEnvironment("Development"); 
    }
}

