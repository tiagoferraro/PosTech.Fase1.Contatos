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
        Task<DDD> Adicionar(DDD d);
        Task Atualizar(DDD d);
        Task<IEnumerable<DDD>> Listar();
        Task<DDD> Obter(int DDDId);
    }
}
