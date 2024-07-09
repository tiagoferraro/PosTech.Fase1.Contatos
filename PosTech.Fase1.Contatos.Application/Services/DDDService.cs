using AutoMapper;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Result;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Application.Services
{
    public class DDDService(IDDDRepository _dddRepository, IMapper _mapper) : IDDDService
    {
        public Task<ServiceResult<DDDDto>> Adicionar(DDDDto c)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Atualizar(DDDDto c)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<DDDDto>>> Listar()
        {
            try
            {
                var listaDDD = await _dddRepository.Listar();
                return new ServiceResult<IEnumerable<DDDDto>>(_mapper.Map<IEnumerable<DDDDto>>(listaDDD));
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<DDDDto>>(e);
            }
        }

        public Task<ServiceResult<DDDDto>> Obter(int DDDId)
        {
            throw new NotImplementedException();
        }
    }
}
