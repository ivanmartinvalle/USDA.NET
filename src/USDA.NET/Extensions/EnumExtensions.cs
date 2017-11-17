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
            return value.GetType()
                .GetRuntimeFields()
                .FirstOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description ?? value.ToString();
        }
    }

    //polyfil for System.ComponentModel.DescriptionAttribute to keep dependencies down
    public sealed class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// <para>Specifies the default value for the <see cref='System.ComponentModel.DescriptionAttribute'/> , which is an
        ///    empty string (""). This <see langword='static'/> field is read-only.</para>
        /// </summary>
        public static readonly DescriptionAttribute Default = new DescriptionAttribute();

        public DescriptionAttribute() : this(string.Empty)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///    <para>Initializes a new instance of the <see cref="T:System.ComponentModel.DescriptionAttribute" /> class.</para>
        /// </summary>
        public DescriptionAttribute(string description) => DescriptionValue = description;

        /// <summary>
        ///    <para>Gets the description stored in this attribute.</para>
        /// </summary>
        public string Description => DescriptionValue;

        /// <summary>
        ///     Read/Write property that directly modifies the string stored
        ///     in the description attribute. The default implementation
        ///     of the Description property simply returns this value.
        /// </summary>
        private string DescriptionValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            return obj is DescriptionAttribute other && other.Description == Description;
        }

        public override int GetHashCode() => Description.GetHashCode();
    }
}
