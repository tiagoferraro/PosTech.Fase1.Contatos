using FluentValidation;
using PosTech.Fase1.Contatos.Application.DTO;

namespace PosTech.Fase1.Contatos.Application.Validators
{

    public class ContatoValidator  : AbstractValidator<ContatoDTO>
    {
        public ContatoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(150).WithMessage("Informe o nome do contato");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Informe o número do telegone de contato") 
                .Must(x => int.TryParse(x, out var val) && val > 0)
                .Length(8,9).WithMessage("O Telefone deverá ter entre 8 a 9 caracteres numéricos");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o e-mail do cliente")  
                                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Ativo).Must(x => x == false || x == true).WithMessage("O campo ativo deve ter o valor falso ou true") ;

            RuleFor(x => x.DddId).NotEmpty().WithMessage("o código de área deve ser um inteiro de 2 dígitos.")
                .InclusiveBetween(11,99)
                            ;
        }        

    }
}