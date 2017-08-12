namespace Expressionist.Compare.Tests.ExpressionEqualityVisitorTests {
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ExpressionEqualityVisitor_GetHashCode_Is_Stable_For_Tests {
        [TestMethod]
        public void Binary1() {
            var lhs = TestExpressions.Binary_Method1();
            var rhs = TestExpressions.Binary_Method1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Binary2() {
            var lhs = TestExpressions.Binary_Method2();
            var rhs = TestExpressions.Binary_Method2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Binary1_Lifted() {
            var lhs = TestExpressions.Binary_Method1_Lifted();
            var rhs = TestExpressions.Binary_Method1_Lifted();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Block1() {
            var lhs = TestExpressions.Block1();
            var rhs = TestExpressions.Block1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Block2() {
            var lhs = TestExpressions.Block2();
            var rhs = TestExpressions.Block2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void CatchBlock1() {
            var lhs = TestExpressions.CatchBlock1();
            var rhs = TestExpressions.CatchBlock1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void CatchBlock2() {
            var lhs = TestExpressions.CatchBlock2();
            var rhs = TestExpressions.CatchBlock2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Conditional1() {
            var lhs = TestExpressions.Conditional1();
            var rhs = TestExpressions.Conditional1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Conditional2() {
            var lhs = TestExpressions.Conditional2();
            var rhs = TestExpressions.Conditional2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Constant1() {
            var lhs = TestExpressions.Constant1();
            var rhs = TestExpressions.Constant1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Constant2() {
            var lhs = TestExpressions.Constant2();
            var rhs = TestExpressions.Constant2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void DebugInfo1() {
            var lhs = TestExpressions.DebugInfo1();
            var rhs = TestExpressions.DebugInfo1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void DebugInfo2() {
            var lhs = TestExpressions.DebugInfo2();
            var rhs = TestExpressions.DebugInfo2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Default1() {
            var lhs = TestExpressions.Default_Type1();
            var rhs = TestExpressions.Default_Type1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Default2() {
            var lhs = TestExpressions.Default_Type2();
            var rhs = TestExpressions.Default_Type2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }
        
        [TestMethod]
        public void ElementInit1() {
            var lhs = TestExpressions.ElementInit1();
            var rhs = TestExpressions.ElementInit1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void ElementInit2() {
            var lhs = TestExpressions.ElementInit2();
            var rhs = TestExpressions.ElementInit2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Extension_Reducible() {
            var lhs = TestExpressions.Extension_Reducible();
            var rhs = TestExpressions.Extension_Reducible();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Goto1() {
            var lhs = TestExpressions.Goto1();
            var rhs = TestExpressions.Goto1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Goto2() {
            var lhs = TestExpressions.Goto2();
            var rhs = TestExpressions.Goto2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Index1() {
            var lhs = TestExpressions.Index1();
            var rhs = TestExpressions.Index1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }


        [TestMethod]
        public void Index2() {
            var lhs = TestExpressions.Index2();
            var rhs = TestExpressions.Index2();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Invocation1() {
            var lhs = TestExpressions.Invoke_Expression_LambdaType1();
            var rhs = TestExpressions.Invoke_Expression_LambdaType1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Label1() {
            var lhs = TestExpressions.Label1();
            var rhs = TestExpressions.Label1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void LabelTarget1() {
            var lhs = TestExpressions.LabelTarget1();
            var rhs = TestExpressions.LabelTarget1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Lambda1() {
            var lhs = TestExpressions.Lambda_Action0_1();
            var rhs = TestExpressions.Lambda_Action0_1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void ListInit1() {
            var lhs = TestExpressions.ListInit1();
            var rhs = TestExpressions.ListInit1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Loop1() {
            var lhs = TestExpressions.Loop1();
            var rhs = TestExpressions.Loop1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Member1() {
            var lhs = TestExpressions.Member1();
            var rhs = TestExpressions.Member1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberAssignment1() {
            var lhs = TestExpressions.MemberAssignment1();
            var rhs = TestExpressions.MemberAssignment1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberInit1() {
            var lhs = TestExpressions.MemberInit1();
            var rhs = TestExpressions.MemberInit1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberListBinding1() {
            var lhs = TestExpressions.MemberListBinding1();
            var rhs = TestExpressions.MemberListBinding1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void MemberMemberBinding1() {
            var lhs = TestExpressions.MemberMemberBinding1();
            var rhs = TestExpressions.MemberMemberBinding1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void MethodCall1() {
            var lhs = TestExpressions.MethodCall1();
            var rhs = TestExpressions.MethodCall1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void New1() {
            var lhs = TestExpressions.New1_0();
            var rhs = TestExpressions.New1_0();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void NewArray1() {
            var lhs = TestExpressions.NewArray1();
            var rhs = TestExpressions.NewArray1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Parameter1() {
            var lhs = TestExpressions.Parameter1();
            var rhs = TestExpressions.Parameter1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void RuntimeVariables1() {
            var lhs = TestExpressions.RuntimeVariables1();
            var rhs = TestExpressions.RuntimeVariables1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Switch1() {
            var lhs = TestExpressions.Switch1();
            var rhs = TestExpressions.Switch1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void SwitchCase1() {
            var lhs = TestExpressions.SwitchCase1();
            var rhs = TestExpressions.SwitchCase1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Try1() {
            var lhs = TestExpressions.Try1();
            var rhs = TestExpressions.Try1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void TypeBinary1() {
            var lhs = TestExpressions.TypeBinary1();
            var rhs = TestExpressions.TypeBinary1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        [TestMethod]
        public void Unary1() {
            var lhs = TestExpressions.Unary1();
            var rhs = TestExpressions.Unary1();

            this.HashCodes_AreEqual_For(lhs, rhs);
        }

        private void HashCodes_AreEqual_For(Expression lhs, Expression rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }

        private void HashCodes_AreEqual_For(CatchBlock lhs, CatchBlock rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }

        private void HashCodes_AreEqual_For(ElementInit lhs, ElementInit rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }

        private void HashCodes_AreEqual_For(LabelTarget lhs, LabelTarget rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }

        private void HashCodes_AreEqual_For(MemberBinding lhs, MemberBinding rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }

        private void HashCodes_AreEqual_For(SwitchCase lhs, SwitchCase rhs) {
            var expected = ExpressionEqualityVisitor.GetHashCodeFor(lhs);
            var actual = ExpressionEqualityVisitor.GetHashCodeFor(rhs);

            Assert.AreEqual(expected, actual);
        }
    }
}
