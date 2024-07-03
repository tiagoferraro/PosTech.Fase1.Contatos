using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Infra.Interfaces
{
    public interface IDDDRepository
    {
        Task<DDD> Adicionar(DDD c);
        Task Atualizar(DDD c);
        Task<IEnumerable<DDD>> Listar();
        Task<DDD> Obter(int DDDId);
    }
}
