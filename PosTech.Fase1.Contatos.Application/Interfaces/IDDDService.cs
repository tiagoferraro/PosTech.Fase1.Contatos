using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Application.DTO;

namespace PosTech.Fase1.Contatos.Application.Interfaces
{
    public interface IDDDService
    {
        Task<DDDDto> Adicionar(DDDDto c);
        Task Atualizar(DDDDto c);
        Task<IEnumerable<DDDDto>> Listar();
        Task<DDDDto> Obter(int DDDId);
    }
}
