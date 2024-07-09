using Microsoft.AspNetCore.Mvc;
using PosTech.Fase1.Contatos.Api.Extension;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;

namespace PosTech.Fase1.Contatos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DDDController(IDDDService dddService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var resultado = await dddService.Listar();
        return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
    }
    [HttpPost]
    public async Task<ActionResult> Adicionar(DDDDto dddDTO)
    {
        var resultado = await dddService.Adicionar(dddDTO);
        return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
    }
}

