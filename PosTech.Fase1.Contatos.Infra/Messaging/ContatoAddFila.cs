using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Infra.Messaging;

public class ContatoAddFila(
    IRabbitMqClient _rabbitMqClient,
    IConfiguration _configuration
    ) : IContatoAddFila
{
    public async Task AdicionarAsync(Contato contato)
    {
        var rabbitMqConfig = _configuration.GetSection("RabbitMq");
        var mensagem = JsonSerializer.Serialize(contato, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        await _rabbitMqClient.SendMessage(mensagem, rabbitMqConfig["ExchangeAdd"]);
    }
}

