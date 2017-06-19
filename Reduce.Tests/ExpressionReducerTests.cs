namespace X {
    public interface IFoo {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Poco : IFoo {
        public int Id { get; set; }

        public string Name { get; set; }

        string IFoo.Name { get; set; }
    }
}

namespace Reduce.Tests {
    using System;
    using System.Linq.Expressions;
    using Expressionist.Reduce;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using X;
    [TestClass]
    public class ExpressionReducerTests {
        [TestMethod]
        public void Reduce_Omits_Unneded_Cast() {
            var input = Expr2<Poco>();
            var result = ExpressionReducer.Reduce(input, ReductionKind.RemoveUnneededCast);
            
            var hasConvert = NodeMatcher.Matches(result, x => x.NodeType == ExpressionType.Convert);
            var expected = false;
            var actual = hasConvert;

            Assert.AreEqual(expected, actual);
        }

        private static Expression<Func<T, int>> Expr1<T>() where T : IFoo {
            return x => x.Id;
        }

        private static Expression<Func<T, string>> Expr2<T>() where T : IFoo {
            return x => x.Name;
        }

        private class NodeMatcher : ExpressionVisitor {
            private bool matchesPredicate = false;
            private readonly Func<Expression, bool> predicate;

            private NodeMatcher(Func<Expression, bool> predicate) {
                this.predicate = predicate;
            }

            public override Expression Visit(Expression node) {
                if (this.predicate(node)) {
                    this.matchesPredicate = true;
                }

                return base.Visit(node);
            }

            public static bool Matches(Expression expr, Func<Expression, bool> predicate) {
                var finder = new NodeMatcher(predicate);

                finder.Visit(expr);

                return finder.matchesPredicate;
            }
        }
    }
}
