
namespace Prism.Ex.App.Common
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum e)
        {
            if (e == null)
            {
                throw new ArgumentNullException($"{nameof(e)} is null.");
            }

            var eType = e.GetType();
            if (!eType.IsEnum)
            {
                throw new ArgumentException($"{nameof(e)} is not a valid enum type.");
            }

            return (e.GetType().GetField(e.ToString()).GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute)?.Description;
        }
    }
}
