using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Domain.Entities;
using System;

namespace PosTech.Fase1.Contatos.Application.Mapping
{
    public static class ContatoMapping
    {
        public static ContatoRequestResponseDto MapToDto(Contato entity)
        {
            return new ContatoRequestResponseDto
            {
                ContatoId = entity.ContatoId,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Ddd = DDDMapping.MapToDto(entity.Ddd),
                Ativo = entity.Ativo
            };
        }

        public static Contato MapToEntity(ContatoRequestDTO requestDto)
        {
            return new Contato(requestDto.ContatoId, requestDto.Nome, requestDto.Telefone, requestDto.Email, requestDto.DddId);
        }
    }

    public static class DDDMapping
    {
        public static DDDDto MapToDto(DDD entity)
        {
            return new DDDDto
            {
                DddId = entity.DddId,
                UF = entity.UF,
                Regiao = entity.Regiao
            };
        }

        public static DDD MapToEntity(DDDDto dto)
        {
            return new DDD(dto.DddId, dto.UF, dto.Regiao);
        }
    }
}