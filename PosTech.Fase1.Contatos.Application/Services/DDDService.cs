using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Mapping;
using PosTech.Fase1.Contatos.Application.Result;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Application.Services
{
    public class DDDService(IDDDRepository dddRepository) : IDDDService
    {
        public async Task<ServiceResult<DDDDto>> Adicionar(DDDDto c)
        {
            try
            {
                var ddd = DDDMapping.MapToEntity(c);
                var novoDdd = await dddRepository.Adicionar(ddd);
                var dddDto = DDDMapping.MapToDto(novoDdd);
                return new ServiceResult<DDDDto>(dddDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<DDDDto>(ex);
            }
        }

        public async Task<ServiceResult> Atualizar(DDDDto c)
        {
            try
            {
                var ddd = DDDMapping.MapToEntity(c);
                await dddRepository.Atualizar(ddd);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public async Task<ServiceResult<IEnumerable<DDDDto>>> Listar()
        {
            try
            {
                var ddds = await dddRepository.Listar();
                var dddsDto = ddds.Select(DDDMapping.MapToDto).ToList();
                return new ServiceResult<IEnumerable<DDDDto>>(dddsDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<IEnumerable<DDDDto>>(ex);
            }
        }

        public async Task<ServiceResult<DDDDto>> Obter(int dddId)
        {
            try
            {
                var ddd = await dddRepository.Obter(dddId);
                var dddDto = DDDMapping.MapToDto(ddd);
                return new ServiceResult<DDDDto>(dddDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<DDDDto>(ex);
            }
        }
    }
}
