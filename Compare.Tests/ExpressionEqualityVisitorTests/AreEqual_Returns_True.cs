namespace Expressionist.Compare.Tests.ExpressionEqualityVisitorTests {
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionEqualityVisitorTests_AreEqual_Returns_True {
        [TestMethod]
        public void Binary() {
            var lhs = TestExpressions.Binary_Method1();
            var rhs = TestExpressions.Binary_Method1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void CatchBlock() {
            var lhs = TestExpressions.CatchBlock1();
            var rhs = TestExpressions.CatchBlock1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Conditional() {
            var lhs = TestExpressions.Conditional1();
            var rhs = TestExpressions.Conditional1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Constant() {
            var lhs = TestExpressions.Constant1();
            var rhs = TestExpressions.Constant1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void DebugInfo() {
            var lhs = TestExpressions.DebugInfo1();
            var rhs = TestExpressions.DebugInfo1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Default() {
            var lhs = TestExpressions.Default_Type1();
            var rhs = TestExpressions.Default_Type1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void ElementInit() {
            var lhs = TestExpressions.ElementInit1();
            var rhs = TestExpressions.ElementInit1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Extension_Reducible() {
            var lhs = TestExpressions.Extension_Reducible();
            var rhs = TestExpressions.Extension_Reducible();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Goto() {
            var lhs = TestExpressions.Goto1();
            var rhs = TestExpressions.Goto1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Index() {
            var lhs = TestExpressions.Index1();
            var rhs = TestExpressions.Index1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Invocation() {
            var lhs = TestExpressions.Invoke_Expression_LambdaType1();
            var rhs = TestExpressions.Invoke_Expression_LambdaType1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Label() {
            var lhs = TestExpressions.Label1();
            var rhs = TestExpressions.Label1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void LabelTarget() {
            var lhs = TestExpressions.LabelTarget1();
            var rhs = TestExpressions.LabelTarget1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Lambda() {
            var lhs = TestExpressions.Lambda_Action0_1();
            var rhs = TestExpressions.Lambda_Action0_1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void ListInit() {
            var lhs = TestExpressions.ListInit1();
            var rhs = TestExpressions.ListInit1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Loop() {
            var lhs = TestExpressions.Loop1();
            var rhs = TestExpressions.Loop1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Member() {
            var lhs = TestExpressions.Member1();
            var rhs = TestExpressions.Member1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberAssignment() {
            var lhs = TestExpressions.MemberAssignment1();
            var rhs = TestExpressions.MemberAssignment1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberInit() {
            var lhs = TestExpressions.MemberInit1();
            var rhs = TestExpressions.MemberInit1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberListBinding() {
            var lhs = TestExpressions.MemberListBinding1();
            var rhs = TestExpressions.MemberListBinding1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberMemberBinding() {
            var lhs = TestExpressions.MemberMemberBinding1();
            var rhs = TestExpressions.MemberMemberBinding1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void MethodCall() {
            var lhs = TestExpressions.MethodCall1();
            var rhs = TestExpressions.MethodCall1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void New() {
            var lhs = TestExpressions.New1_0();
            var rhs = TestExpressions.New1_0();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void NewArray() {
            var lhs = TestExpressions.NewArray1();
            var rhs = TestExpressions.NewArray1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Parameter() {
            var lhs = TestExpressions.Parameter1();
            var rhs = TestExpressions.Parameter1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void RuntimeVariables() {
            var lhs = TestExpressions.RuntimeVariables1();
            var rhs = TestExpressions.RuntimeVariables1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Switch() {
            var lhs = TestExpressions.Switch1();
            var rhs = TestExpressions.Switch1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void SwitchCase() {
            var lhs = TestExpressions.SwitchCase1();
            var rhs = TestExpressions.SwitchCase1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Try() {
            var lhs = TestExpressions.Try1();
            var rhs = TestExpressions.Try1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void TypeBinary() {
            var lhs = TestExpressions.TypeBinary1();
            var rhs = TestExpressions.TypeBinary1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        [TestMethod]
        public void Unary() {
            var lhs = TestExpressions.Unary1();
            var rhs = TestExpressions.Unary1();

            this.AreEqual_Returns_True_For(lhs, rhs);
        }

        private void AreEqual_Returns_True_For(Expression lhs, Expression rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

        private void AreEqual_Returns_True_For(CatchBlock lhs, CatchBlock rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

        private void AreEqual_Returns_True_For(ElementInit lhs, ElementInit rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

        private void AreEqual_Returns_True_For(LabelTarget lhs, LabelTarget rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

        private void AreEqual_Returns_True_For(MemberBinding lhs, MemberBinding rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

        private void AreEqual_Returns_True_For(SwitchCase lhs, SwitchCase rhs) {
            var result = ExpressionEqualityVisitor.AreEqual(lhs, rhs);

            var expected = true;
            var actual = result;
            Assert.AreEqual(expected, actual);
        }

    }
}
