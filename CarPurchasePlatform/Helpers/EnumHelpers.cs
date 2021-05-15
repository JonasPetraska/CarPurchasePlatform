using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Helpers
{
    /// <summary>
    /// Enum helpers
    /// </summary>
    public static class EnumHelpers
    {
        /// <summary>
        /// Gets enum display name from [Display] attribute
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(Enum enumValue)
        {
            if (enumValue == null)
                return "";

            var enumType = enumValue.GetType();
            var member = enumType.GetMember(enumValue.ToString()).FirstOrDefault();
            if (member == null)
                return enumValue.ToString();

            var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute == null)
                return enumValue.ToString();

            return displayAttribute.Name;
        }

    }
}
