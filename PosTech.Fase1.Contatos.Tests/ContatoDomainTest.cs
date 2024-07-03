using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Tests
{
    public class ContatoDomainTest
    {
        [Fact]
        public void Contato_Excluir_VerificaContatoExcluido()
        {
            //Arrange
            var contato = new Contato(1, "tiago", "321321312", "tiago@gmail.com", 11);
            //Action
            contato.DesativarContato();
            //Assert
            Assert.False(contato.Ativo);
        }
    }
}
