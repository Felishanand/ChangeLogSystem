using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;

namespace ChangeLogSystem.Shared
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllUnmapped<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            Type sourceType = typeof(TSource);
            PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (PropertyInfo property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, o => o.Ignore());
                }
            }

            return expression;
        }
    }
}