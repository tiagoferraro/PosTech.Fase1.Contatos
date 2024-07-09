using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Result;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }


        public Task<ServiceResult<ContatoDTO>> Adicionar(ContatoDTO c)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Atualizar(ContatoDTO c)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Excluir(int ContatoId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<ContatoDTO>>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<ContatoDTO>>> ListarComDDD(int DDD)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ContatoDTO>> Obter(int ContatoId)
        {
            throw new NotImplementedException();
        }
    }
}
