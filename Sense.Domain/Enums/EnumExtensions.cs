using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var displayAttribute = value.GetType()
           .GetField(value.ToString())
           ?.GetCustomAttributes(typeof(DisplayAttribute), false)
           .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
