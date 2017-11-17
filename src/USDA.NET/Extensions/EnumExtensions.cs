using System;
using System.Linq;
using System.Reflection;

namespace USDA.NET.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the DescriptionAttribute value from an enum value.
        /// </summary>
        /// <param name="value">The enum value</param>
        /// <returns>The DescriptionAttribute value or if not defined, value.ToString()</returns>
        public static string ToDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetRuntimeFields()
                    .FirstOrDefault(x => x.Name == value.ToString())
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description ?? value.ToString();
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public static readonly DescriptionAttribute Default;

        public DescriptionAttribute()
        {
        }

        public DescriptionAttribute(string description)
        {
        }

        public virtual string Description { get; }

        protected string DescriptionValue { get; set; }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
