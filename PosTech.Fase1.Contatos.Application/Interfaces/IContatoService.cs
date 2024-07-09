using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Result;

namespace PosTech.Fase1.Contatos.Application.Interfaces
{
    public interface IContatoService
    {
        Task<ServiceResult<ContatoRequestResponseDto>> Adicionar(ContatoRequestDTO c);
        Task<ServiceResult> Atualizar(ContatoRequestDTO c);
        Task<ServiceResult> Excluir(int contatoId);
        Task<ServiceResult<IEnumerable<ContatoRequestResponseDto>>> Listar();
        Task<ServiceResult<IEnumerable<ContatoRequestResponseDto>>> ListarComDDD(int ddd);
        Task<ServiceResult<ContatoRequestResponseDto>> Obter(int contatoId);
    }
}
