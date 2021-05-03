using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace LinuxParking.API.Extentions
{
    public static class ModelStateExtentions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dict)
        {
            return dict.SelectMany(m => m.Value.Errors)
                        .Select(m => m.ErrorMessage)
                        .ToList();
        }
    }
}