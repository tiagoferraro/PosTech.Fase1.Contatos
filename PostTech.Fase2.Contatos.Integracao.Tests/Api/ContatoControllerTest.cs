using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Infra.Context;
using PostTech.Fase2.Contatos.Integracao.Tests.Fixture;
using Xunit.Extensions.Ordering;

namespace PostTech.Fase2.Contatos.Integracao.Tests.Api;

[Order(4)]
public class ContatoControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>,
    IClassFixture<ContextDbFixture>
{
    private readonly HttpClient _client;
    private readonly ContextDbFixture _contextDbFixture;


    //public ContatoControllerTest(CustomWebApplicationFactory<Program> factory, ContextDbFixture contextDbFixture)
    //{
    //    factory.conectionString = contextDbFixture.sqlConection;
    //    _contextDbFixture = contextDbFixture;

    //    _client = factory.CreateClient(new WebApplicationFactoryClientOptions()
    //    {
    //        AllowAutoRedirect = true
    //    });


    //}

    //[Fact, Order(1)]
    //public async Task ContatoController_Adicionar_DeveAdicionarContato()
    //{
    //    // Arrange
    //    _contextDbFixture.IncializaDadosContatos();
    //    var response = await _client.PostAsJsonAsync("/api/Contatos", new ContatoDTO()
    //    {
    //        Nome = "João",
    //        Email = "Joao@gmail.com",
    //        DddId = 11,
    //        Telefone = "993993999",
    //        Ativo = true
            
    //    });
    //    response.EnsureSuccessStatusCode();
    //    // Act
    //    var responseString = await response.Content.ReadAsStringAsync();
    //    // Assert
    //    Assert.Contains("João", responseString);
    //}

    //[Fact, Order(2)]
    //public async Task ContatoController_ObterTodos_DeveRetornarListaDeContatos()
    //{
    //    // Arrange
    //    var response = await _client.GetAsync("/api/Contatos");
    //    response.EnsureSuccessStatusCode();
    //    var responseString = await response.Content.ReadAsStringAsync();
    //    // Assert
    //    Assert.Contains("João", responseString);
    //}

    //[Fact, Order(3)]
    //public async Task ContatoController_Obter_DeveRetornarContato()
    //{
    //    // Arrange
    //    var response = await _client.GetAsync("/api/Contatos/1");
    //    response.EnsureSuccessStatusCode();
    //    var responseString = await response.Content.ReadAsStringAsync();
    //    // Assert
    //    Assert.Contains("João", responseString);
    //}

    //[Fact, Order(4)]
    //public async Task ContatoController_Atualizar_DeveAtualizarContato()
    //{
    //    // Arrange  // Act
    //    var response = await _client.PutAsJsonAsync("/api/Contatos", new ContatoDTO()
    //    {
    //        ContatoId = 1,
    //        Nome = "João",
    //        Email = "Joao2@gmail.com",
    //        DddId = 11,
    //        Telefone = "993993999",
    //        Ativo = true
    //    });
    //    response.EnsureSuccessStatusCode();
       
    //    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    //}
    //[Fact, Order(5)]
    //public async Task ContatoController_Obter_DeveRetornarContatoInexistente()
    //{
    //    // Arrange
    //    var response = await _client.GetAsync("/api/Contatos/2");
    //    var responseString = await response.Content.ReadAsStringAsync();
    //    // Assert
    //    Assert.Contains("Contato não encontrado", responseString);
    //}
    //[Fact, Order(6)]
    //public async Task ContatoController_Deletar_DeveDeletarContato()
    //{
    //    // Arrange // Act
    //    var response = await _client.DeleteAsync("/api/Contatos/1");
    //    response.EnsureSuccessStatusCode();
    //    // Assert
    //    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    //}
}
