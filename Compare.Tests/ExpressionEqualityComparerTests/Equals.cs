namespace Expressionist.Compare.Tests.ExpressionEqualityComparerTests {
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Equals {
        [TestMethod]
        public void Equals_Null_Null_IsTrue() {
            var lhs = (Expression)null;
            var rhs = (Expression)null;

            Equals_Test_Expect_True(lhs, rhs);
        }

        [TestMethod]
        public void Equals_Null_Constant1_IsFalse() {
            var lhs = (Expression)null;
            var rhs = TestExpressions.Constant1();

            Equals_Test_Expect_False(lhs, rhs);
        }

        [TestMethod]
        public void Equals_Constant1_Null_IsTrue() {
            var lhs = TestExpressions.Constant1();
            var rhs = (Expression)null;

            Equals_Test_Expect_False(lhs, rhs);
        }

        [TestMethod]
        public void Equals_Same_IsTrue() {
            var expr = TestExpressions.Constant1();

            Equals_Test_Expect_True(expr, expr);
        }

        [TestMethod]
        public void Adding_Equal_Expression_To_Set_Does_Not_Increase_Count() {
            var unit = ExpressionEqualityComparer.Instance;

            var set = new HashSet<Expression>(unit);

            var expr1 = TestExpressions.New1_0();
            var expr2 = TestExpressions.New1_0();

            set.Add(expr1);
            var expected = set.Count;
            set.Add(expr2);
            var actual = set.Count;

            Assert.AreEqual(expected, actual);
        }

        private static void Equals_Test_Expect_True(Expression lhs, Expression rhs) {
            var expected = true;

            Equals_Test(lhs, rhs, expected);
        }

        private static void Equals_Test_Expect_False(Expression lhs, Expression rhs) {
            var expected = false;

            Equals_Test(lhs, rhs, expected);
        }

        private static void Equals_Test(Expression lhs, Expression rhs, bool expected) {
            var unit = ExpressionEqualityComparer.Instance;

            var result = unit.Equals(lhs, rhs);

            var actual = result;

            Assert.AreEqual(expected, actual);
        }


    }
}
