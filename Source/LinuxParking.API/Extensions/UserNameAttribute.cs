using System;
using System.ComponentModel.DataAnnotations;
using LinuxParking.API.External.Swapi;

namespace LinuxParking.API.Extensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    sealed public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var input = value as string;
            var res = Swapi.FetchCharacterByName(input).Result;
            return res != null;
        }
    }
}