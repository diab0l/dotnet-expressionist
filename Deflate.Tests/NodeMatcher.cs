namespace Expressionist.Deflate.Tests {
    using System;
    using System.Linq.Expressions;

    public class NodeMatcher : ExpressionVisitor {
        private bool matchesPredicate = false;
        private readonly Func<Expression, bool> predicate;

        private NodeMatcher(Func<Expression, bool> predicate) {
            this.predicate = predicate;
        }

        public override Expression Visit(Expression node) {
            if (this.predicate(node)) {
                this.matchesPredicate = true;
            }

            return base.Visit(node);
        }

        public static bool NodeOrDescendantMatches(Expression expr, Func<Expression, bool> predicate) {
            var finder = new NodeMatcher(predicate);

            finder.Visit(expr);

            return finder.matchesPredicate;
        }
    }
}
