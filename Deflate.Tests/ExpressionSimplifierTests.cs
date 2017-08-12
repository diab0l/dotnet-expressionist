namespace X {
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     An interface of common entity properties.
    /// </summary>
    public interface IEntityWithIdAndName {
        int Id { get; set; }
        string Name { get; set; }
    }

    /// <summary>
    ///     An entity implementing an interface.
    /// </summary>
    public class Person : IEntityWithIdAndName {
        public int Id { get; set; }

        public string Name { get; set; }

        string IEntityWithIdAndName.Name { get; set; }
    }

    /// <summary>
    ///     Another entity implementing the interface.
    /// </summary>
    public class Animal : IEntityWithIdAndName {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    /// <summary>
    ///     A base repository that works on objects of generic type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MockBaseRepository<T> where T : IEntityWithIdAndName {
        public static Expression<Func<T, string>> OrderByNameExpression() {
            return x => x.Name;
        }
    }

    public class PersonRepository : MockBaseRepository<Person> { }

    public class AnimalRepository : MockBaseRepository<Animal> { }
}

namespace Expressionist.Deflate.Tests {
    using System;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using X;
    [TestClass]
    public class ExpressionSimplifierTests {
        [TestMethod]
        public void GenerateExpression_Generates_Expected_Defect() {
            var input = GenerateExpressionWithCast();

            var hasConvert = NodeMatcher.NodeOrDescendantMatches(input, x => x.NodeType == ExpressionType.Convert);
            var expected = true;
            var actual = hasConvert;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reduce_Omits_Unneded_Cast() {
            var input = GenerateExpressionWithCast();
            var result = ExpressionSimplifier.Simplify(input, Simplification.Uncast);

            var hasConvert = NodeMatcher.NodeOrDescendantMatches(result, x => x.NodeType == ExpressionType.Convert);
            var expected = false;
            var actual = hasConvert;

            Assert.AreEqual(expected, actual);
        }

        private static Expression<Func<Person, string>> GenerateExpressionWithCast() {
            return PersonRepository.OrderByNameExpression();
        }
    }
}
