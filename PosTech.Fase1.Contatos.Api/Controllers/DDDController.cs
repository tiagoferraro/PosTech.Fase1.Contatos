using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;

namespace PosTech.Fase1.Contatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        private readonly IDDDService _dddservice;
        public DDDController(IDDDService dddservice)
        {
            _dddservice = dddservice;
        }

        public async Task<ActionResult> Adicionar(DDDDto dddDTO)
        {
            var dddCriado = await _dddservice.Adicionar(dddDTO);
            return Ok(dddCriado);
        }
    }
}
