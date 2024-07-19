using Microsoft.AspNetCore.Mvc;
using Moq;
using PosTech.Fase1.Contatos.Api.Controllers;
using PosTech.Fase1.Contatos.Api.Model;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Result;

namespace PosTech.Fase1.Contatos.Tests.Presentation;

public class ContatosControllerTest
{
    
    private readonly ContatoDTO _contatoDTO;
    private const string MensagemErro = "Mensagem Erro";

    public ContatosControllerTest()
    {
        _contatoDTO = new ContatoDTO(){Ativo = true,ContatoId = 1,DddId = 11,Email = "teste@teste@gmail.com",Nome = "Tiago",Telefone = "62138587"};
        
    }
    [Fact] 
    public async Task ContatosController_AdiconarComSucesso()
    {

        //arrange
        var contatoService = new Mock<IContatoService>();
        contatoService.Setup(c => c.Adicionar(_contatoDTO)).ReturnsAsync(new ServiceResult<ContatoDTO>(_contatoDTO));
        var contatoController = new ContatosController(contatoService.Object);
        //act
        var result = (OkObjectResult)(await  contatoController.Adicionar(_contatoDTO));
        
        //assert
        Assert.True(result.Value is ContatoDTO);
    }
    [Fact]
    public async Task ContatosController_AdiconarComErro()
    {

        //arrange
        var contatoService = new Mock<IContatoService>();
        contatoService.Setup(c => c.Adicionar(_contatoDTO)).ReturnsAsync(new ServiceResult<ContatoDTO>(new Exception(MensagemErro)));
        var contatoController = new ContatosController(contatoService.Object);
        //act
        var result = (BadRequestObjectResult)(await contatoController.Adicionar(_contatoDTO));

        //assert
        
        Assert.True( ((MensagemErro)result.Value!).mensagemErro.First() == MensagemErro);
    }
    [Fact]
    public async Task ContatosController_AtualizarComSucesso()
    {

        //arrange
        var contatoService = new Mock<IContatoService>();
        contatoService.Setup(c => c.Atualizar(_contatoDTO)).ReturnsAsync(new ServiceResult<bool>(true));
        var contatoController = new ContatosController(contatoService.Object);
        //act
        var result = (NoContentResult)(await contatoController.Atualizar(_contatoDTO));

        //assert
        Assert.True(result.StatusCode == 204);
    }
    [Fact]
    public async Task ContatosController_AtualizarComErro()
    {

        //arrange
        var contatoService = new Mock<IContatoService>();
        
        contatoService.Setup(c => c.Atualizar(_contatoDTO)).ReturnsAsync(new ServiceResult<bool>(new Exception(MensagemErro)));
        var contatoController = new ContatosController(contatoService.Object);
        //act
        var result = (BadRequestObjectResult)(await contatoController.Atualizar(_contatoDTO));

        //assert

        Assert.True(((MensagemErro)result.Value!).mensagemErro.First() == MensagemErro);
    }
}

