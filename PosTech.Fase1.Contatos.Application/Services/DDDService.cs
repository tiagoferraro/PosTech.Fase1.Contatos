using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Result;

namespace PosTech.Fase1.Contatos.Application.Services
{
    public class DDDService : IDDDService
    {
        public Task<ServiceResult<DDDDto>> Adicionar(DDDDto c)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Atualizar(DDDDto c)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<DDDDto>>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<DDDDto>> Obter(int DDDId)
        {
            throw new NotImplementedException();
        }
    }
}
