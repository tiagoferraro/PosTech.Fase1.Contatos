using FluentValidation;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Application.Validators;

public class DDDValidator : AbstractValidator<DDDDto>
{
    public DDDValidator()
    {
        RuleFor(x => x.UfSigla).NotEmpty().Length(2).WithMessage("UfSigla precisa ser informada e conter extamente 2 caracteres ex:SP") 
                            //    .Must(x => UnidadeFederativa.ufs.Contains(x))  // está dando erro pois nao reconhece a classe estática UnidadeFederativa
                               ; // validar UF informada 

        RuleFor(x => x.Regiao).NotEmpty().MaximumLength(100).WithMessage("UfRegiao é a principal cidade da área de abrangencia, precisa ser informada, e conter no máximo 100 caracteres") ;

    }
}

