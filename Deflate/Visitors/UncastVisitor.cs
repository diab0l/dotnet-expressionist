namespace Expressionist.Deflate {
    using System.Linq.Expressions;

    /// <summary>
    ///     Implements a visitor that removes an unneccessary cast to an implemented interface.
    /// </summary>
    public class UncastVisitor : ExpressionVisitor {
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
    }
}
