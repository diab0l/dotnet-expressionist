namespace Expressionist {
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     A collection of predicate expression production functions.
    /// </summary>
    public static class PredicateTestExpressions {
        /// <summary>
        ///     Constant true expression.
        /// </summary>
        /// <returns>An expression of a function that returns true.</returns>
        public static Expression<Func<bool>> ConstantTrue0() {
            return () => true;
        }

        /// <summary>
        ///     Constant false expression.
        /// </summary>
        /// <returns>An expression of a function that returns false.</returns>
        public static Expression<Func<bool>> ConstantFalse0() {
            return () => false;
        }

        /// <summary>
        ///     Constant true expression. (Unary function)
        /// </summary>
        /// <typeparam name="T">The type of the (discarded) parameter.</typeparam>
        /// <returns>An expression of a function that takes a parameter and returns true.</returns>
        public static Expression<Func<T, bool>> ConstantTrue1<T>() {
            return x => true;
        }

        /// <summary>
        ///     Constant false expression. (Unary function)
        /// </summary>
        /// <typeparam name="T">The type of the (discarded) parameter.</typeparam>
        /// <returns>An expression of a function that takes a parameter and returns false.</returns>
        public static Expression<Func<T, bool>> ConstantFalse1<T>() {
            return x => false;
        }

        /// <summary>
        ///     A unary function returning it's parameter.
        /// </summary>
        /// <returns>An expression of a function that takes a parameter and returns it.</returns>
        public static Expression<Func<bool, bool>> Id() {
            return x => x;
        }

        /// <summary>
        ///     A unary function that checks a string for null. 
        /// </summary>
        /// <returns>An expression of a function that takes a string and returns whether it is not null.</returns>
        public static Expression<Func<string, bool>> StringNotNull() {
            return x => x != null;
        }

        /// <summary>
        ///     A unary function that checks a string for emptiness.
        /// </summary>
        /// <returns>En expression of a function that takes a string and returns whether it is not empty.</returns>
        public static Expression<Func<string, bool>> StringNotEmpty() {
            return x => x.Length > 0;
        }
    }
}
