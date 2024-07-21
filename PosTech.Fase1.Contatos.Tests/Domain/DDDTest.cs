using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Domain.ObjectValue;

namespace PosTech.Fase1.Contatos.Tests.Domain
{
    public class DDDTest
    {
        [Fact]
        public void DDDContruir()
        {
            //Arrange
            //Action
            var ddd = new DDD(25,"ES","Linhares");
            //Assert
            Assert.Equal(ddd.DddId, 25);
            Assert.Equal(ddd.Regiao,"Linhares"); 
            Assert.Equal(ddd.UnidadeFederativa.Sigla,"ES");           
            Assert.Equal(ddd.UnidadeFederativa.Nome,"Espírito Santo");     

            



        }
    }
}