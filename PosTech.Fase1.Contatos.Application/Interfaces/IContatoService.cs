using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Application.Result;

namespace PosTech.Fase1.Contatos.Application.Interfaces
{
    public interface IContatoService
    {
        Task<ServiceResult<ContatoDTO>> Adicionar(ContatoDTO c);
        Task<ServiceResult> Atualizar(ContatoDTO c);
        Task<ServiceResult> Excluir(int ContatoId);
        Task<ServiceResult<IEnumerable<ContatoDTO>>> Listar();
        Task<ServiceResult<IEnumerable<ContatoDTO>>> ListarComDDD(int DDD);
        Task<ServiceResult<ContatoDTO>> Obter(int ContatoId);


    }
}
