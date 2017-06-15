namespace Expressionist.Compare.Tests.ExpressionEqualityComparerTests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetHashCode {
        [TestMethod]
        public void Null_Returns_0() {
            var unit = ExpressionEqualityComparer.Instance;

            var result = unit.GetHashCode(null);

            var expected = 0;
            var actual = result;

            Assert.AreEqual(expected, actual);
        }
    }
}
