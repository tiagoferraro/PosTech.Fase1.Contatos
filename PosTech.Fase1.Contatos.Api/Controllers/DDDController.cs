﻿using Microsoft.AspNetCore.Mvc;
using PosTech.Fase1.Contatos.Api.Extension;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;

namespace PosTech.Fase1.Contatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController(IDDDService dddservice) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Adicionar(DDDDto dddDto)
        {
            var resultado = await dddservice.Adicionar(dddDto);
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(DDDDto dddDto)
        {
            var resultado = await dddservice.Atualizar(dddDto);
            return resultado.IsSuccess ? Ok() : BadRequest(resultado.Error?.Message.ConverteParaErro());
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var resultado = await dddservice.Listar();
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
        }

        [HttpGet("{dddId}")]
        public async Task<ActionResult> Obter(int dddId)
        {
            var resultado = await dddservice.Obter(dddId);
            return resultado.IsSuccess ? Ok(resultado.Data) : BadRequest(resultado.Error?.Message.ConverteParaErro());
        }
    }
}
