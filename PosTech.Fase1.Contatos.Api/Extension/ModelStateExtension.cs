using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PosTech.Fase1.Contatos.Api.Extension
{
    public static class ModelStateExtension
    {
        public static List<string> RetornaErrosMessages(this ModelStateDictionary modelstate)
        {
            return modelstate
                .SelectMany(ms => ms.Value!.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}
