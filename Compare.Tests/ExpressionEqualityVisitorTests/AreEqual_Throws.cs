namespace Expressionist.Compare.Tests.ExpressionEqualityVisitorTests {
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionEqualityVisitorTests_AreEqual_Throws {
        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void Dynamic() {
            var lhs = TestExpressions.Dynamic();
            var rhs = TestExpressions.Dynamic();

            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void Extension_NonReducible() {
            var lhs = TestExpressions.Extension_Reducible();
            var rhs = TestExpressions.Extension_NonReducible();

            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);
        }
    }
}
