using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Application.DTO
{

    public class ContatoDTO
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }

    public class ContatoRequestDTO : ContatoDTO
    {
        public int DddId { get; set; }
    }


    public class ContatoRequestResponseDto : ContatoDTO
    {
        public DDDDto Ddd { get; set; }

    }
}
