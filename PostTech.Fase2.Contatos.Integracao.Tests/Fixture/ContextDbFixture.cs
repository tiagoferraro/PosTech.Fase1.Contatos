﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PosTech.Fase1.Contatos.Infra.Context;
using Testcontainers.MsSql;

namespace PostTech.Fase2.Contatos.Integracao.Tests.Fixture;

public class ContextDbFixture : IAsyncLifetime
{

    public AppDBContext Context { get; private set; }
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
        .Build();
    public async Task InitializeAsync()
    {
        await _msSqlContainer.StartAsync();
        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseSqlServer(_msSqlContainer.GetConnectionString())
            .Options;
        var mockConfiguration = new Mock<IConfiguration>();

        Context = new AppDBContext(options, mockConfiguration.Object);
        Context.Database.Migrate();

    }
    public async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync();
    }

  

}

