using FluentValidation;
using PosTech.Fase1.Contatos.Application.DTO;

namespace PosTech.Fase1.Contatos.Application.Validators;

public class DDDValidator : AbstractValidator<DDDDto>
{
    private const string _MensagemDDD = "O Campo Uf precisa ter extamente 2 caracteres ex:SP";
    public DDDValidator()
    {
        RuleFor(x => x.UF).NotEmpty().Length(2).WithMessage(_MensagemDDD) ;


    }
}

