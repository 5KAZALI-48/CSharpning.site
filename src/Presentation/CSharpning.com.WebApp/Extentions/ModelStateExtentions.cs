using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CSharpning.com.WebApp.Extentions;

public static class ModelStateExtentions
{
    public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
    {
        errors.ForEach(x =>
        {
            modelState.AddModelError(string.Empty, x);
        });

    }
}
