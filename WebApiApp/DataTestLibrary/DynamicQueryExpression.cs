using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataTestLibrary
{
    public class DynamicQueryExpression
    {
        public static Expression QueryExpression<T>(IQueryable<T> source, string targetParamName, string targetParamValue, string expressionType, ParameterExpression parameter)
        {
            var type = typeof(T);

            MemberExpression left = Expression.Property(parameter, targetParamName);
            Expression right = Expression.Constant(int.Parse(targetParamValue), typeof(int));

            switch (expressionType)
            {
                case ">": return Expression.GreaterThan(left, right); 
                case "<": return Expression.LessThan(left, right); 
                default:
                case "=": return Expression.Equal(left, right); 
                    //case "%like": return Expression.Equal(left, right); //тут долна быть обработа строк
            }
        }

        public static IQueryable<T> QueryExpression<T>(IQueryable<T> source)
        {
            var parameter = Expression.Parameter(typeof(T), "p");

            var e1 = DynamicQueryExpression.QueryExpression<T>(source, "Count", "3", ">", parameter);
            var e2 = DynamicQueryExpression.QueryExpression<T>(source, "Count", "10", "<", parameter);

            Expression res = Expression.And(e1, e2);

            MethodCallExpression resultExp = Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { source.ElementType },
                    source.Expression,
                    Expression.Lambda<Func<T, bool>>(res, new ParameterExpression[] { parameter }));

            IQueryable<T> results = source.Provider.CreateQuery<T>(resultExp);

            return results;
        }
    }
}