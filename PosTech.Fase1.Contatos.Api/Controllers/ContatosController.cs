using Microsoft.AspNetCore.Mvc;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;

namespace PosTech.Fase1.Contatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController(IContatoService contatoService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] ContatoDTO contatoRequestRequestDto)
        {
            var resultado = await contatoService.Adicionar(contatoRequestRequestDto);
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] ContatoDTO contatoRequestRequestDto)
        {
            var resultado = await contatoService.Atualizar(contatoRequestRequestDto);
            return resultado.IsSuccess ? NoContent() : BadRequest(resultado.Error?.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var resultado = await contatoService.Excluir(id);
            return resultado.IsSuccess ? NoContent() : BadRequest(resultado.Error?.Message);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> Listar()
        {
            var resultado = await contatoService.Listar();
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoDTO>> Obter(int id)
        {
            var resultado = await contatoService.Obter(id);
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message);
        }

        [HttpGet("listarComDDD/{ddd}")]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> ListarComDDD(int ddd)
        {
            var resultado = await contatoService.ListarComDDD(ddd);
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message);
        }
    }
}
