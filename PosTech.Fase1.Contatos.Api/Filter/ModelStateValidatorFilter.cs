using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PosTech.Fase1.Contatos.Api.Extension;

namespace PosTech.Fase1.Contatos.Api.Filter;

public class ModelStateValidatorFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
      
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if(!context.ModelState.IsValid)
        {
            var erros = context.ModelState.RetornaErrosMessages();
            context.Result = new BadRequestObjectResult(erros);
        }
    }
}


