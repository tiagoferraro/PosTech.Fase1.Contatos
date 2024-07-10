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
        public UnidadeFederativa Uf { get; private set; }
        public string Regiao { get; private set; }

    


        public DDD(int dddId, UnidadeFederativa uf, string regiao)
        {
            DddId = dddId;
            Uf = uf;
            Regiao = regiao;
        }
    }
}