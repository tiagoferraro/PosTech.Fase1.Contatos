using Microsoft.Extensions.Configuration;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PosTech.Fase1.Contatos.Infra.Messaging;

public class ContatoAddFila(
    IRabbitMqClient _rabbitMqClient,
    IConfiguration _configuration
    ) : IContatoAddFila
{

    private async Task EnviarMensagemAsync(Contato contato, string exchangeKey)
    {
        var rabbitMqConfig = _configuration.GetSection("RabbitMq");
        var mensagem = JsonSerializer.Serialize(contato, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var exchange = rabbitMqConfig[exchangeKey];
        await _rabbitMqClient.SendMessage(mensagem, exchange);
    }

    public async Task AdicionarAsync(Contato contato)
    {
        await EnviarMensagemAsync(contato, "ExchangeAdd");
    }

    public async Task AtualizarAsync(Contato contato)
    {
        await EnviarMensagemAsync(contato, "ExchangeUpdate");
    }

    public async Task ExcluirAsync(Contato contato)
    {
        await EnviarMensagemAsync(contato, "ExchangeDelete");
    }

}

