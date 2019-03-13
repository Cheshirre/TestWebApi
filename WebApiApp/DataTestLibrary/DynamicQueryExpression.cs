using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DataTestLibrary
{
    public class DynamicQueryExpression
    {
        private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod("Contains");
        private static readonly MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private static readonly MethodInfo EndsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        //public static Expression<Func<TSource, bool>> LikeExpression<TSource, TMember>(Expression<Func<TSource, TMember>> property, string value)
        //{
        //    var param = Expression.Parameter(typeof(TSource), "t");
        //    var propertyInfo = GetPropertyInfo(property);
        //    var member = Expression.Property(param, propertyInfo.Name);

        //    var startWith = value.StartsWith("%");
        //    var endsWith = value.EndsWith("%");

        //    if (startWith)
        //        value = value.Remove(0, 1);

        //    if (endsWith)
        //        value = value.Remove(value.Length - 1, 1);

        //    var constant = Expression.Constant(value);
        //    Expression exp;

        //    if (endsWith && startWith)
        //    {
        //        exp = Expression.Call(member, ContainsMethod, constant);
        //    }
        //    else if (startWith)
        //    {
        //        exp = Expression.Call(member, EndsWithMethod, constant);
        //    }
        //    else if (endsWith)
        //    {
        //        exp = Expression.Call(member, StartsWithMethod, constant);
        //    }
        //    else
        //    {
        //        exp = Expression.Equal(member, constant);
        //    }

        //    return Expression.Lambda<Func<TSource, bool>>(exp, param);
        //}

        //private static PropertyInfo GetPropertyInfo(Expression expression)
        //{
        //    var lambda = expression as LambdaExpression;
        //    if (lambda == null)
        //        throw new ArgumentNullException("expression");

        //    MemberExpression memberExpr = null;

        //    switch (lambda.Body.NodeType)
        //    {
        //        case ExpressionType.Convert:
        //            memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
        //            break;
        //        case ExpressionType.MemberAccess:
        //            memberExpr = lambda.Body as MemberExpression;
        //            break;
        //    }

        //    if (memberExpr == null)
        //        throw new InvalidOperationException("Specified expression is invalid. Unable to determine property info from expression.");


        //    var output = memberExpr.Member as PropertyInfo;

        //    if (output == null)
        //        throw new InvalidOperationException("Specified expression is invalid. Unable to determine property info from expression.");

        //    return output;
        //}

        public static Expression QueryExpression<T>(IQueryable<T> source, string targetParamName, string targetParamValue, string expressionType, ParameterExpression parameter)
        {
            var type = typeof(T);

            MemberExpression left = Expression.Property(parameter, targetParamName);
            Expression right;

            //to-do: тут, конечно,по-другому сделать надо было, но пока так
            switch (expressionType)
            {
                case ">": right = Expression.Constant(int.Parse(targetParamValue), typeof(int)); return Expression.GreaterThan(left, right); 
                case "<": right = Expression.Constant(int.Parse(targetParamValue), typeof(int)); return Expression.LessThan(left, right); 
                default:
                case "=": right = Expression.Constant(bool.Parse(targetParamValue), typeof(bool)); return Expression.Equal(left, right); 
                case "%like%":
                    right = Expression.Constant(targetParamValue, typeof(string));
                    return Expression.Call(left, ContainsMethod, right); 
            }
        }

        public static IQueryable<T> QueryExpression<T>(IQueryable<T> source, IFilter filter)
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            List<Expression> expressions = new List<Expression>();

            foreach (var filterElem in filter.filterParams)
            {
                expressions.Add(DynamicQueryExpression.QueryExpression<T>(source, filterElem.PropertyName, filterElem.ParamValue, filterElem.ExpressionType, parameter));
            }

            //var e1 = DynamicQueryExpression.QueryExpression<T>(source, "Count", "3", ">", parameter);
            //var e2 = DynamicQueryExpression.QueryExpression<T>(source, "Count", "10", "<", parameter);

            Expression res = Expression.Constant(true, typeof(bool));

            if (expressions.Count > 0)
            {
                res = expressions.FirstOrDefault();

                foreach (var expr in expressions)
                {
                    res = Expression.And(res, expr);
                }
            }

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