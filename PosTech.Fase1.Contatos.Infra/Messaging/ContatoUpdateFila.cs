
using Microsoft.Extensions.Configuration;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PosTech.Fase1.Contatos.Infra.Messaging;

public class ContatoUpdateFila(
      IRabbitMqClient _rabbitMqClient,
    IConfiguration _configuration
    ) : IContatoUpdateFila
{
    public async Task AtualizarAsync(Contato contato)
    {

        var rabbitMqConfig = _configuration.GetSection("RabbitMq");
        var mensagem = JsonSerializer.Serialize(contato, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        await _rabbitMqClient.SendMessage(mensagem, rabbitMqConfig["ExchangeUpdate"]);
    }
}

