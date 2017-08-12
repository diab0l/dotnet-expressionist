namespace Expressionist.Deflate {
    using System.Linq.Expressions;

    /// <summary>
    ///     Simplifies an <see cref="Expression"/>.
    /// </summary>
    public class ExpressionSimplifier {
        /// <summary>
        ///     Simplify <paramref name="expr"/> with the selected simplicifaction <paramref name="kinds"/>.
        /// </summary>
        /// <typeparam name="T">The type of the expression.</typeparam>
        /// <param name="expr">The source expression.</param>
        /// <param name="kinds">The kinds of simplification to apply.</param>
        /// <returns>The resulting expression after applying the selected simpliciation kinds.</returns>
        public static T Simplify<T>(T expr, Simplification kinds) where T : Expression {
            var acc = expr;

            if (kinds.HasFlag(Simplification.Uncast)) {
                acc = (T)new UncastVisitor().Visit(acc);
            }

            return acc;
        }
    }
}
