using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        public static string ToLowerCaseCamel(this string str)
        {
            return !String.IsNullOrEmpty(str) ? $"{str[0].ToString().ToLower()}{str.Substring(1)}" : "";
        }

        public static string FromCamelCase(this string str)
        {
            return Regex.Replace(str, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }
    }
}
