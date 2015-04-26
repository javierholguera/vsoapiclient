namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using AutoMapper;
    using AutoMapper.Impl;
    using Newtonsoft.Json;

    public static class AutoMapperHelper
    {
        public static string GetRemoteFieldName(Type fromType, MemberExpression m)
        {
            TypeMap typeMapping = FindTypeMapping(fromType, m.Expression.Type);
            PropertyMap propertyMapping = typeMapping.GetExistingPropertyMapFor(new PropertyAccessor((PropertyInfo)m.Member));
            return GetPropertyRemoteFieldName(propertyMapping);
        }

        public static IEnumerable<string> GetAllRemoteFields(Type fromType, Type toType)
        {
            TypeMap typeMapping = FindTypeMapping(fromType, toType);
            return typeMapping.GetPropertyMaps()
                .Select(GetPropertyRemoteFieldName)
                .Where(f => string.IsNullOrEmpty(f) == false) // we dont want empty remote field names
                .ToList();
        }

        private static TypeMap FindTypeMapping(Type fromType ,Type toType)
        {
            TypeMap typeMapping = Mapper.FindTypeMapFor(fromType, toType);
            if (typeMapping == null)
                throw new NotSupportedException(string.Format(
                    "Unable to find a mapping from {0} to {1}",
                    fromType.FullName,
                    toType.FullName));

            return typeMapping;
        }

        private static string GetPropertyRemoteFieldName(PropertyMap propertyMapping)
        {
            var memberInfo = ((MemberExpression) propertyMapping.CustomExpression.Body).Member;
            var attribute = (JsonPropertyAttribute) memberInfo.GetCustomAttributes(typeof (JsonPropertyAttribute), true).Single();
            return attribute.PropertyName;
        }
    }
}