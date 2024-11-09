using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Result;

namespace PosTech.Fase1.Contatos.Application.Interfaces
{
    public interface IContatoService
    {
        Task<ServiceResult<ContatoDTO>> Adicionar(ContatoDTO c);
        Task<ServiceResult<bool>> Atualizar(ContatoDTO c);
        Task<ServiceResult<bool>> Excluir(Guid ContatoId);
        Task<ServiceResult<IEnumerable<ContatoDTO>>> Listar();
        Task<ServiceResult<IEnumerable<ContatoDTO>>> ListarComDDD(int DDD);
        Task<ServiceResult<ContatoDTO>> Obter(Guid ContatoId);


    }
}
