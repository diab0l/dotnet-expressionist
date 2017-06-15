namespace Expressionist.Compare {
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implements a comparer for expression trees. Compares one expression tree to another.
    /// </summary>
    public class ExpressionEqualityComparer : IEqualityComparer<Expression> {
        /// <summary>
        ///     Returns the singleton instance of the comparer.
        /// </summary>
        public static ExpressionEqualityComparer Instance { get; } = new ExpressionEqualityComparer();

        private ExpressionEqualityComparer() { }

        /// <summary>
        ///     Determines whether the specified <see cref="Expression"/>s are equal.
        /// </summary>
        /// <param name="x">The first <see cref="Expression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public bool Equals(Expression x, Expression y) {
            if (ReferenceEquals(x, y)) {
                return true;
            }

            if (x == null || y == null) {
                return false;
            }

            return ExpressionEqualityVisitor.AreEqual(x, y);
        }

        /// <summary>
        ///     Returns a stable hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The <see cref="Expression"/> to be hashed.</param>
        /// <returns>A hash code for the specified <see cref="Expression"/>.</returns>
        public int GetHashCode(Expression expr) {
            if (expr == null) {
                return 0;
            }

            return ExpressionEqualityVisitor.GetHashCodeFor(expr);
        }
    }
}