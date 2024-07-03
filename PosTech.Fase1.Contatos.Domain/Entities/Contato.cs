using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Domain.Entities
{
    public class Contato
    {
        public int ContatoId { get; private set; }
        public string Nome { get;private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public int DddId { get; private set; }
        public DDD Ddd { get; private set; }
        public bool Ativo { get; private set; }

        public Contato( int contatoId, string nome, string telefone, string email, int dddId)
        {

            ContatoId = contatoId;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            DddId = dddId;
            Ativo = true;
        }


        public void DesativarContato()
        {
            Ativo = false;
        }

    }
}
