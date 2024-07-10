using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Mapping;
using PosTech.Fase1.Contatos.Application.Result;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Application.Services
{
    public class ContatoService(IContatoRepository contatoRepository) : IContatoService
    {
        public async Task<ServiceResult<ContatoRequestResponseDto>> Adicionar(ContatoRequestDTO c)
        {
            try
            {
                var contato = ContatoMapping.MapToEntity(c);
                var novoContato = await contatoRepository.Adicionar(contato);
                var contatoDto = ContatoMapping.MapToDto(novoContato);

                return new ServiceResult<ContatoRequestResponseDto>(contatoDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<ContatoRequestResponseDto>(ex);
            }
        }

        public async Task<ServiceResult> Atualizar(ContatoRequestDTO c)
        {
            try
            {
                var contato = Mapping.ContatoMapping.MapToEntity(c);
                await contatoRepository.Atualizar(contato);

                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public Task<ServiceResult<bool>> Atualizar(ContatoDTO c)
        {
            try
            {
                var contato = await contatoRepository.Obter(contatoId);
                contato.DesativarContato();
                await contatoRepository.Atualizar(contato);

                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public async Task<ServiceResult<IEnumerable<ContatoRequestResponseDto>>> Listar()
        {
            try
            {
                var contatos = await contatoRepository.Listar();
                var contatosDto = new List<ContatoRequestResponseDto>();
                foreach (var contato in contatos)
                {
                    contatosDto.Add(Mapping.ContatoMapping.MapToDto(contato));
                }
                return new ServiceResult<IEnumerable<ContatoRequestResponseDto>>(contatosDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<IEnumerable<ContatoRequestResponseDto>>(ex);
            }
        }

        public async Task<ServiceResult<IEnumerable<ContatoRequestResponseDto>>> ListarComDDD(int ddd)
        {
            try
            {
                var contatos = await contatoRepository.ListarComDDD(ddd);
                var contatosDto = contatos.Select(ContatoMapping.MapToDto).ToList();
                return new ServiceResult<IEnumerable<ContatoRequestResponseDto>>(contatosDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<IEnumerable<ContatoRequestResponseDto>>(ex);
            }
        }

        public async Task<ServiceResult<ContatoRequestResponseDto>> Obter(int contatoId)
        {
            try
            {
                var contato = await contatoRepository.Obter(contatoId);

                var contatoDto = ContatoMapping.MapToDto(contato);
                return new ServiceResult<ContatoRequestResponseDto>(contatoDto);
            }
            catch (Exception ex)
            {
                return new ServiceResult<ContatoRequestResponseDto>(ex);
            }
        }
    }
}
