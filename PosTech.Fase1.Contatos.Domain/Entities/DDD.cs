using PosTech.Fase1.Contatos.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Domain.Entities
{
    public class DDD
    {
        public int DddId { get; private set; }
        public string UfSigla { get; private set; }
        public string UfNome { get; private set; }
        public string Regiao { get; private set; }

    


        public DDD(int dddId, string ufSigla, string ufNome, string regiao)
        {
            DddId   = dddId;
            UfSigla = ufSigla;
            UfNome  = ufNome;
            Regiao  = regiao;
        }
    }
}