
namespace Prism.Ex.App.Common
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class ExpressionSupport
    {
        [ExcludeFromCodeCoverage]
        private static PropertyInfo ExtractProperty<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException($"{nameof(propertyExpression)} is null.");
            }

            if (!(propertyExpression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException($"the Body({nameof(MemberExpression)}) of {nameof(propertyExpression)} is null.");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException($"the Member({nameof(PropertyInfo)}) of {nameof(propertyExpression)} is null.");
            }

            return property;
        }

        // the method is from prism source code
        //public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        //{
        //    if (propertyExpression == null)
        //    {
        //        throw new ArgumentNullException($"{nameof(propertyExpression)} is null.");
        //    }

        //    var memberExpression = propertyExpression.Body as MemberExpression;
        //    if (memberExpression == null)
        //    {
        //        throw new ArgumentException($"the Body({nameof(MemberExpression)}) of {nameof(propertyExpression)} is null.");
        //    }

        //    var property = memberExpression.Member as PropertyInfo;
        //    if (property == null)
        //    {
        //        throw new ArgumentException($"the Member({nameof(PropertyInfo)}) of {nameof(propertyExpression)} is null.");
        //    }

        //    // TODO: 这里的判断不是必须的，需要确认在什么场景下必须判断是否静态类型
        //    var getMethod = property.GetGetMethod(true);
        //    if (getMethod.IsStatic)
        //    {
        //        throw new ArgumentException($"{nameof(propertyExpression)} is static.");
        //    }

        //    return memberExpression.Member.Name;
        //}

        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression) => ExtractProperty(propertyExpression).Name;

        public static string ExtractPropertyDescription<T>(Expression<Func<T>> propertyExpression) =>
            (ExtractProperty(propertyExpression).GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute)?.Description;
    }
}
