using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Application.Interfaces
{
    public interface IContatoService
    {
        Task<ContatoDTO> Adicionar(ContatoDTO c);
        Task Atualizar(ContatoDTO c);
        Task Excluir(int ContatoId);
        Task<IEnumerable<ContatoDTO>> Listar();
        Task<IEnumerable<ContatoDTO>> ListarComDDD(int DDD);
        Task<ContatoDTO> Obter(int ContatoId);
    }
}
