using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace LinuxParking.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dict)
        {
            return dict.SelectMany(m => m.Value.Errors)
                        .Select(m => m.ErrorMessage)
                        .ToList();
        }
    }
}