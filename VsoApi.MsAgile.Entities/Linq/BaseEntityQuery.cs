namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using IQToolkit;

    public class BaseEntityQuery<T> : Query<T> where T : BaseEntity
    {
        public BaseEntityQuery(IQueryProvider provider) : base(provider)
        {
        }

        public BaseEntityQuery(IQueryProvider provider, Type staticType) : base(provider, staticType)
        {
        }

        public BaseEntityQuery(QueryProvider provider, Expression expression) : base(provider, expression)
        {
        }
    }
    
    public static class BaseEntityQueryExtensions
    {
        public static IQueryable<TSource> AsOf<TSource>(this IQueryable<TSource> source, DateTime date) where TSource : BaseEntity
        {
            if (source == null)
                throw new ArgumentNullException("source");
            return source.Provider.CreateQuery<TSource>(
                Expression.Call(
                    null,
                    ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TSource)),
                    new[] { source.Expression, Expression.Constant(date) }
                    ));
        }
    }
}