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
        public string UF { get; private set; }
        public string Regiao { get; private set; }

        public DDD(int dddId, string uf, string regiao)
        {
            DddId = dddId;
            UF = uf;
            Regiao = regiao;
        }

    }
}
