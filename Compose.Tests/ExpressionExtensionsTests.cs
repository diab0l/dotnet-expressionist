namespace Expressionist.Compose.Tests {
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Linq.Expressions;

    [TestClass]
    public class ExpressionExtensionTests {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Combine_When_Lhs_IsNull_Throws() {
            var lhs = (LambdaExpression)null;
            var combine = new Func<Expression, Expression, Expression>(Expression.AndAlso);
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, combine, rhs);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Combine_When_Combine_IsNull_Throws() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var combine = (Func<Expression, Expression, Expression>)null;
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, combine, rhs);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Combine_When_Rhs_IsNull_Throws() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var combine = new Func<Expression, Expression, Expression>(Expression.AndAlso);
            var rhs = (LambdaExpression)null;

            var result = ExpressionExtensions.Combine(lhs, combine, rhs);
        }

        #region Rank 0 {ConstantTrue, ConstantFalse} And {ConstantTrue, ConstantFalse}
        [TestMethod]
        public void ConstantTrue0_And_ConstantTrue0_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue0();
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue0_And_ConstantFalse0_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantTrue0();
            var rhs = PredicateTestExpressions.ConstantFalse0();

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse0_And_ConstantTrue0_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse0_And_ConstantFalse0_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var rhs = PredicateTestExpressions.ConstantFalse0();

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 {ConstantTrue, ConstantFalse} And {ConstantTrue, ConstantFalse} With Parameter {True, False}
        [TestMethod]
        public void ConstantTrue1_And_ConstantTrue1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue1_And_ConstantTrue1_With_False_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ConstantTrue1_And_ConstantFalse1_With_True_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue1_And_ConstantFalse1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_And_ConstantTrue1_With_True_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_And_ConstantTrue1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_And_ConstantFalse1_With_True_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_And_ConstantFalse1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 Id And {ConstantTrue, ConstantFalse} With Parameter {True, False}
        [TestMethod]
        public void Id_And_ConstantTrue1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_And_ConstantTrue1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_And_ConstantFalse1_With_True_Returns_False() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_And_ConstantFalse1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 {StringNotNull, StringNotEmpty} And {StringNotEmpty, StringNotNull} With Parameter {null, string.Empty, "foo"}
        [TestMethod]
        public void StringNotNull_And_StringNotEmpty_With_Null_Returns_False() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = (string)null;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringNotNull_And_StringNotEmpty_With_StringEmpty_Returns_False() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = string.Empty;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringNotNull_And_StringNotEmpty_With_Foo_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = "foo";

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void StringNotEmpty_And_StringNotNull_With_Null_Throws_NullReferenceException() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = (string)null;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);
            var actual = result.Compile()(argument);
        }

        [TestMethod]
        public void StringNotEmpty_And_StringNotNull_With_StringEmpty_Returns_False() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = string.Empty;

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringNotEmpty_And_StringNotNull_With_Foo_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = "foo";

            var result = ExpressionExtensions.Combine(lhs, Expression.AndAlso, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Rank 0 {ConstantTrue, ConstantFalse} Or {ConstantTrue, ConstantFalse}
        [TestMethod]
        public void ConstantTrue0_Or_ConstantTrue0_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue0();
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue0_Or_ConstantFalse0_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue0();
            var rhs = PredicateTestExpressions.ConstantFalse0();

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse0_Or_ConstantTrue0_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var rhs = PredicateTestExpressions.ConstantTrue0();

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse0_Or_ConstantFalse0_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse0();
            var rhs = PredicateTestExpressions.ConstantFalse0();

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = false;
            var actual = result.Compile()();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 {ConstantTrue, ConstantFalse} Or {ConstantTrue, ConstantFalse} With Parameter {True, False}
        [TestMethod]
        public void ConstantTrue1_Or_ConstantTrue1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue1_Or_ConstantTrue1_With_False_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue1_Or_ConstantFalse1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantTrue1_Or_ConstantFalse1_With_False_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_Or_ConstantTrue1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_Or_ConstantTrue1_With_False_Returns_True() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_Or_ConstantFalse1_With_True_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstantFalse1_Or_ConstantFalse1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 Id Or {ConstantTrue, ConstantFalse} With Parameter {True, False}
        [TestMethod]
        public void Id_Or_ConstantTrue1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_Or_ConstantTrue1_With_False_Returns_True() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantTrue1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_Or_ConstantFalse1_With_True_Returns_True() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = true;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Id_Or_ConstantFalse1_With_False_Returns_False() {
            var lhs = PredicateTestExpressions.Id();
            var rhs = PredicateTestExpressions.ConstantFalse1<bool>();
            var argument = false;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = false;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Rank 1 {StringNotNull, StringNotEmpty} Or {StringNotEmpty, StringNotNull} With Parameter {null, string.Empty, "foo"}
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void StringNotNull_Or_StringNotEmpty_With_Null_Throws_NullReferenceException() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = (string)null;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);
            var actual = result.Compile()(argument);
        }

        [TestMethod]
        public void StringNotNull_Or_StringNotEmpty_With_StringEmpty_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = string.Empty;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringNotNull_Or_StringNotEmpty_With_Foo_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotNull();
            var rhs = PredicateTestExpressions.StringNotEmpty();
            var argument = "foo";

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void StringNotEmpty_Or_StringNotNull_With_Null_Throws_NullReferenceException() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = (string)null;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);
            var actual = result.Compile()(argument);
        }

        [TestMethod]
        public void StringNotEmpty_Or_StringNotNull_With_StringEmpty_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = string.Empty;

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringNotEmpty_Or_StringNotNull_With_Foo_Returns_True() {
            var lhs = PredicateTestExpressions.StringNotEmpty();
            var rhs = PredicateTestExpressions.StringNotNull();
            var argument = "foo";

            var result = ExpressionExtensions.Combine(lhs, Expression.OrElse, rhs);

            var expected = true;
            var actual = result.Compile()(argument);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
