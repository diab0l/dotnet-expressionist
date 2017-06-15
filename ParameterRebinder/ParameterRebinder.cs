namespace Expressionist.ParameterRebinder {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Replaces <see cref="ParameterExpression"/>s in the visited expression.
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor {
        private readonly Dictionary<ParameterExpression, ParameterExpression> replacements;

        /// <summary>
        ///     Initializes a new instance of <see cref="ParameterRebinder"/>. 
        /// </summary>
        /// <param name="replacements">A map of replacements to be made.</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> replacements) {
            if (replacements == null) {
                throw new ArgumentNullException(nameof(replacements));
            }

            if (replacements.Any(kvp => kvp.Value == null)) {
                throw new ArgumentException("None of the replacements may be null.", nameof(replacements));
            }

            this.replacements = replacements;
        }

        /// <summary>
        ///     Replaces a parameter if it is part of the replacements.
        /// </summary>
        /// <param name="node">The visitted node.</param>
        /// <returns>The parameter's replacement if it is part of the replacement list; the unchanged value otherwise.</returns>
        protected override Expression VisitParameter(ParameterExpression node) {
            if (replacements.TryGetValue(node, out var replacement)) {
                return replacement;
            }

            return base.VisitParameter(node);
        }

        /// <summary>
        ///     Replaces all occurences of each item in <paramref name="sources"/> with it's positional equivalent in <paramref name="targets"/> within <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The expression for which the replacements should be made.</param>
        /// <param name="sources">The sequence of parameters to be replaced.</param>
        /// <param name="targets">The sequence of replacement parameters.</param>
        /// <returns>An expression equivalent to the input expression, except that it's parameter references have been replaced.</returns>
        public static Expression Rebind(
            Expression expression,
            IEnumerable<ParameterExpression> sources,
            IEnumerable<ParameterExpression> targets) {
            if (expression == null) {
                throw new ArgumentNullException(nameof(expression));
            }
            if (sources == null) {
                throw new ArgumentNullException(nameof(sources));
            }
            if (targets == null) {
                throw new ArgumentNullException(nameof(targets));
            }

            var replacements = sources.Zip(targets, Tuple.Create).ToDictionary(x => x.Item1, x => x.Item2);

            var rebinder = new ParameterRebinder(replacements);

            return rebinder.Visit(expression);
        }
    }
}
