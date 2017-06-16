namespace Expressionist.Compose {
    using System;
    using System.Linq.Expressions;

    using Expressionist.ParameterRebinder;

    public static class ExpressionExtensions {
        public static T Combine<T>(this T lhs, Func<Expression, Expression, Expression> combinator, T rhs) where T: LambdaExpression {
            if (lhs == null) {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (combinator == null) {
                throw new ArgumentNullException(nameof(combinator));
            }
            if (rhs == null) {
                throw new ArgumentNullException(nameof(rhs));
            }
            
            return (T)Combine((LambdaExpression)lhs, combinator, rhs);
        }

        private static LambdaExpression Combine(LambdaExpression lhs, Func<Expression, Expression, Expression> combinator, LambdaExpression rhs) {
            var lhsBody = lhs.Body;
            var rhsBody = ParameterRebinder.Rebind(rhs.Body, rhs.Parameters, lhs.Parameters);

            var combinedBody = combinator(lhsBody, rhsBody);

            return Expression.Lambda(combinedBody, lhs.Parameters);
        }
    }
}
