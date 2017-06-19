namespace Expressionist.Reduce {
    using System.Linq.Expressions;

    public class ExpressionReducer : ExpressionVisitor {
        private readonly ReductionKind kinds;

        private ExpressionReducer(ReductionKind kinds) {
            this.kinds = kinds;
        }

        protected override Expression VisitMember(MemberExpression node) {
            var body = node.Expression;
            var member = node.Member;

            if (!(body is UnaryExpression)) {
                return base.VisitMember(node);
            }

            if (body.NodeType != ExpressionType.Convert) {
                return base.VisitMember(node);
            }

            var convExpr = body as UnaryExpression;
            var baseType = convExpr.Type;
            var type = convExpr.Operand.Type;

            if (baseType.IsAssignableFrom(type)) {
                var operand = base.Visit(convExpr.Operand);

                return Expression.MakeMemberAccess(operand, member);
            }

            body = base.Visit(body);
            return Expression.MakeMemberAccess(body, member);
        }

        public static T Reduce<T>(T expr, ReductionKind kinds) where T : Expression {
            var visitor = new ExpressionReducer(kinds);

            return (T)visitor.Visit(expr);
        }
    }
}
