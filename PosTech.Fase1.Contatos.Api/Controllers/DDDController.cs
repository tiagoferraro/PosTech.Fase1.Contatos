using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosTech.Fase1.Contatos.Api.Extension;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;

namespace PosTech.Fase1.Contatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        //private readonly IDDDService _dddservice;
        //public DDDController(IDDDService dddservice)
        //{
        //    _dddservice = dddservice;
        //}

        [HttpPost]
        public async Task<ActionResult> Adicionar(DDDDto dddDTO)
        {
            // var resultado = await _dddservice.Adicionar(dddDTO);
            // return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
            Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState = ModelState;
            return Ok(dddDTO);
        }
    }
}
