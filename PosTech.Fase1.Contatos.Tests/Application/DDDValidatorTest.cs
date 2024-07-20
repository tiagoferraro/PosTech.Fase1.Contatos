using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Validators;

namespace PosTech.Fase1.Contatos.Tests.Application
{
    public class DDDValidatorTest
    {
        [Fact]
        public void DDDValidator_UfSiglaInformada_DeveRetornarSucesso()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo",
                UfNome = "São Paulo",
                UfSigla = "SP"
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void DDDValidator_UfSiglaNaoInformada_DeveRetornarErro()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo",
                UfNome = "São Paulo",
                UfSigla = ""
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.False(result.IsValid);
            Assert.Equal("UfSigla precisa ser informada e conter exatamente 2 caracteres ex:SP", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void DDDValidator_UfSiglaComMenosDeDoisCaracteres_DeveRetornarErro()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo",
                UfNome = "São Paulo",
                UfSigla = "S"
            };
            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.False(result.IsValid);
            Assert.Equal("UfSigla precisa ser informada e conter exatamente 2 caracteres ex:SP", result.Errors[0].ErrorMessage);


        }

        [Fact]
        public void DDDValidator_UfSiglaComMaisDeDoisCaracteres_DeveRetornarErro()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo",
                UfNome = "São Paulo",
                UfSigla = "SP1"
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.False(result.IsValid);
            Assert.Equal("UfSigla precisa ser informada e conter exatamente 2 caracteres ex:SP", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void DDDValidator_UfRegiaoInformada_DeveRetornarSucesso()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo",
                UfNome = "São Paulo",
                UfSigla = "SP"
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void DDDValidator_UfRegiaoNaoInformada_DeveRetornarErro()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "",
                UfNome = "São Paulo",
                UfSigla = "SP"
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.False(result.IsValid);
            Assert.Equal("UfRegiao é a principal cidade da área de abrangência, precisa ser informada, e conter no máximo 100 caracteres", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void DDDValidator_UfRegiaoComMaisDeCemCaracteres_DeveRetornarErro()
        {
            //arrange
            var dddDto = new DDDDto()
            {
                DddId = 11,
                Regiao = "São Paulo, Campinas, Jundiaí, São José dos Campos, Guarulhos, Osasco, Santo André, São Bernardo do Campo",
                UfNome = "São Paulo",
                UfSigla = "SP"
            };

            //act
            var dddValidator = new DDDValidator();
            var result = dddValidator.Validate(dddDto);

            //assert
            Assert.False(result.IsValid);
            Assert.Equal("UfRegiao é a principal cidade da área de abrangência, precisa ser informada, e conter no máximo 100 caracteres", result.Errors[0].ErrorMessage);
        }
    }
}
