﻿using System.Linq.Expressions;

namespace DiyarTask.Application.Queries
{
    public class BaseQuery<T> where T : class
    {
        protected Expression<Func<T, bool>> CombineExpressions(
       Expression<Func<T, bool>> expr1,
       Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.Invoke(expr1, parameter),
                    Expression.Invoke(expr2, parameter)
                ),
                parameter
            );

            return combined;
        }
    }
}
