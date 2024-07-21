using FluentValidation;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Validators;


namespace PosTech.Fase1.Contatos.Tests.Application
{
    public class ContatoValidatorTest
    {
        [Fact]  
        public void ContatoValidator_Contato_OK()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                Email = "Joao.Barro@acme.com",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.True(result.IsValid);
        }
        [Fact]  
        public void ContatoValidator_NomeVazio_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "",
                Telefone = "988808182",
                Email = "Joao.Barro@acme.com",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("'Nome' must not be empty.", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_NomeInformed_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Telefone = "988808182",
                Email = "Joao.Barro@acme.com",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("'Nome' must not be empty.", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_TelefoneEmpty_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "",
                Email = "Joao.Barro@acme.com",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("Informe o número do telegone de contato", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_TelefoneNotInformed_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Email = "Joao.Barro@acme.com",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("Informe o número do telegone de contato", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_EmailEmpty_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                Email = "",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            // Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("Informe o e-mail do cliente", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_EmailNotInformed_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            // Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("Informe o e-mail do cliente", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_EmailInvalid_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                Email = "Joao.Barro",
                DddId = 27
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            // Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("E-mail inválido", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_DDDId_Invalid_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                Email = "Joao.Barro@acme.com",
                DddId = 127
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            // Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("o código de área deve ser um inteiro de 2 dígitos.", result.Errors[0].ErrorMessage);        
        }
        [Fact]  
        public void ContatoValidator_DDDId_NotInformed_Error()
        {
            //arrange
            ContatoDTO contatoDto = new ContatoDTO()
            {
                Nome = "Joao de Barro",
                Telefone = "988808182",
                Email = "Joao.Barro@acme.com",
            };
            //act
            var contatoValidator = new ContatoValidator();
            var result = contatoValidator.Validate(contatoDto);
            //assert
            Assert.False(result.IsValid);
            // Assert.Equal("NotEmptyValidator", result.Errors[0].ErrorCode);        
            Assert.Equal("o código de área deve ser um inteiro de 2 dígitos.", result.Errors[0].ErrorMessage);        
        }
    }
}