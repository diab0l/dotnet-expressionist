namespace Expressionist.ParameterRebinder.Tests {
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParameterRebinderTests {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Throws_When_Replacements_IsNull() {
            var replacements = (Dictionary<ParameterExpression, ParameterExpression>)null;

            var unit = new ParameterRebinder(replacements);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Ctor_Throws_When_A_Replacement_IsNull() {
            var replacements = new Dictionary<ParameterExpression, ParameterExpression>();

            var key = Expression.Parameter(typeof(int));
            var value = (ParameterExpression)null;
            replacements[key] = value;

            var unit = new ParameterRebinder(replacements);
        }

        [TestMethod]
        public void Returns_Original_Expression_When_Replacements_IsEmpty() {
            var replacements = new Dictionary<ParameterExpression, ParameterExpression>();

            var unit = new ParameterRebinder(replacements);

            var expected = PredicateTestExpressions.StringNotNull();
            var actual = unit.Visit(expected);

            Assert.AreSame(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Rebind_Throws_When_Expressions_IsNull () {
            var expression = (Expression)null;
            var sources = new List<ParameterExpression>();
            var targets = new List<ParameterExpression>();

            ParameterRebinder.Rebind(expression, sources, targets);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Rebind_Throws_When_Sources_IsNull() {
            var expression = PredicateTestExpressions.StringNotNull();
            var sources = (IEnumerable<ParameterExpression>)null;
            var targets = new List<ParameterExpression>();

            ParameterRebinder.Rebind(expression, sources, targets);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Rebind_Throws_When_Targets_IsNull() {
            var expression = PredicateTestExpressions.StringNotNull();
            var sources = new List<ParameterExpression>();
            var targets = (IEnumerable<ParameterExpression>)null;

            ParameterRebinder.Rebind(expression, sources, targets);
        }
    }
}
