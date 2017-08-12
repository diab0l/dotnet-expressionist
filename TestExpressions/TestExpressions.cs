namespace Expressionist {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     A collection of expression production functions.
    ///     The produced expressions are all different to each other.
    /// </summary>
    public static class TestExpressions {
        /// <summary>
        ///     Creates a <see cref="BinaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         (int)0 - (int)1
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="BinaryExpression" />.</returns>
        public static BinaryExpression Binary_Method1() {
            var lhs = Expression.Constant(0);
            var rhs = Expression.Constant(1);

            return Expression.Subtract(lhs, rhs);
        }

        /// <summary>
        ///     Creates a <see cref="BinaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         (int)0 + (int)1
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="BinaryExpression" />.</returns>
        public static BinaryExpression Binary_Method2() {
            var lhs = Expression.Constant(0);
            var rhs = Expression.Constant(1);

            return Expression.Add(lhs, rhs);
        }

        /// <summary>
        ///     Creates a lifted <see cref="BinaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         (int?)0 - (int?)1
        ///     ]]></code>
        /// </remarks>
        /// <returns>A lifted <see cref="BinaryExpression" />.</returns>
        public static BinaryExpression Binary_Method1_Lifted() {
            var lhs = Expression.Constant(0, typeof(int?));
            var rhs = Expression.Constant(1, typeof(int?));

            return Expression.Subtract(lhs, rhs);
        }

        /// <summary>
        ///     Creates a <see cref="BlockExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         ... { }
        ///     ]]></code>
        /// </remarks>
        /// <returns>An <see cref="BlockExpression" />.</returns>
        public static BlockExpression Block1() {
            var body = Expression.Empty();
            return Expression.Block(body);
        }

        /// <summary>
        ///     Creates a <see cref="BlockExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         ... { throw new System.NotImplementedException(); }
        ///     ]]></code>
        /// </remarks>
        /// <returns>An <see cref="BlockExpression" />.</returns>
        public static BlockExpression Block2() {
            var body = Throw_NotImplementedException();
            return Block(body);
        }

        /// <summary>
        ///     Creates a <see cref="BlockExpression" />.
        /// </summary>
        /// <param name="body">The body of the expression.</param>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         ... => body
        ///     ]]></code>
        /// </remarks>
        /// <returns>An <see cref="BlockExpression" />.</returns>
        public static BlockExpression Block(Expression body) {
            return Expression.Block(body);
        }

        /// <summary>
        ///     Creates a <see cref="CatchBlock" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         catch(Exception ex) {};
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="CatchBlock" />.</returns>
        public static CatchBlock CatchBlock1() {
            var variable = Expression.Variable(typeof(Exception));
            var body = Expression.Empty();

            return Expression.Catch(variable, body);
        }

        /// <summary>
        ///     Creates a <see cref="CatchBlock" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         catch (System.NotImplementedException ex) {};
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="CatchBlock" />.</returns>
        public static CatchBlock CatchBlock2() {
            var variable = Expression.Variable(typeof(NotImplementedException));
            var body = Expression.Empty();

            return Expression.Catch(variable, body);
        }

        /// <summary>
        ///     Creates a <see cref="ConditionalExpression"/>.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         a == b ? c : d
        ///     ]]]></code>
        /// </remarks>
        /// <returns>A <see cref="ConditionalExpression"/>.</returns>
        public static ConditionalExpression Conditional1() {
            var test = Expression.Constant(true);
            var ifTrue = Constant1();
            var ifFalse = Constant2();

            return Expression.Condition(test, ifTrue, ifFalse);
        }

        /// <summary>
        ///     Creates a <see cref="ConditionalExpression"/>.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         a == b ? c : d
        ///     ]]]></code>
        /// </remarks>
        /// <returns>A <see cref="ConditionalExpression"/>.</returns>
        public static ConditionalExpression Conditional2() {
            var test = Expression.Constant(false);
            var ifTrue = Constant1();
            var ifFalse = Constant2();

            return Expression.Condition(test, ifTrue, ifFalse);
        }

        /// <summary>
        ///     Creates a <see cref="ConstantExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         1
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ConstantExpression" />.</returns>
        public static ConstantExpression Constant1() {
            return Expression.Constant(1);
        }

        /// <summary>
        ///     Creates a <see cref="ConstantExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         2
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ConstantExpression" />.</returns>
        public static ConstantExpression Constant2() {
            return Expression.Constant(2);
        }

        /// <summary>
        ///     Creates a <see cref="DebugInfoExpression" />.
        /// </summary>
        /// <returns>A <see cref="DebugInfoExpression" /> expression.</returns>
        public static DebugInfoExpression DebugInfo1() {
            var path = "Foo";
            var doc = Expression.SymbolDocument(path);

            return Expression.DebugInfo(doc, 1, 1, 1, 1);
        }

        /// <summary>
        ///     Creates a <see cref="DebugInfoExpression" />.
        /// </summary>
        /// <returns>A <see cref="DebugInfoExpression" /> expression.</returns>
        public static DebugInfoExpression DebugInfo2() {
            var path = "Bar";
            var doc = Expression.SymbolDocument(path);

            return Expression.DebugInfo(doc, 1, 1, 1, 1);
        }

        /// <summary>
        ///     Creates a <see cref="DefaultExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         default(string)
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="DefaultExpression" />.</returns>
        public static DefaultExpression Default_Type1() {
            return Expression.Default(typeof(string));
        }

        /// <summary>
        ///     Creates a <see cref="DefaultExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         default(int)
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="DefaultExpression" />.</returns>
        public static DefaultExpression Default_Type2() {
            return Expression.Default(typeof(int));
        }

        /// <summary>
        ///     Creates a <see cref="DynamicExpression" />.
        /// </summary>
        /// <returns>A <see cref="DynamicExpression" />.</returns>
        public static DynamicExpression Dynamic() {
            var delegateType = typeof(Action<CallSite>);
            var binder = new TestBinder();

            return Expression.MakeDynamic(delegateType, binder);
        }

        /// <summary>
        ///     Creates a <see cref="ElementInit" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new List<string> { 
        ///             "Foo" // ElementInit
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ElementInit" />.</returns>
        public static ElementInit ElementInit1() {
            var type = typeof(List<string>);

            var addMethod = type.GetMethod(nameof(List<string>.Add));
            var arg0 = Expression.Constant("Foo");

            return Expression.ElementInit(addMethod, arg0);
        }

        /// <summary>
        ///     Creates a <see cref="ElementInit" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new List<int>
        ///         { // start of ElementInit
        ///             0
        ///         } // end of ElementInit
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ElementInit" />.</returns>
        public static ElementInit ElementInit2() {
            var type = typeof(List<int>);

            var addMethod = type.GetMethod(nameof(List<int>.Add));
            var arg0 = Expression.Constant(0);

            return Expression.ElementInit(addMethod, arg0);
        }

        /// <summary>
        ///     Creates a <see cref="Expression" />.
        /// </summary>
        /// <returns>A <see cref="Expression" />.</returns>
        public static Expression Extension_NonReducible() {
            return new ExtensionExpression(false);
        }

        /// <summary>
        ///     Creates a <see cref="Expression" />.
        /// </summary>
        /// <returns>A <see cref="Expression" />.</returns>
        public static Expression Extension_Reducible() {
            return new ExtensionExpression(true);
        }

        /// <summary>
        ///     Creates a <see cref="GotoExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         goto label1; // GotoExpression
        ///         
        ///         label1: ...
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="GotoExpression" />.</returns>
        public static GotoExpression Goto1() {
            var label = LabelTarget1();
            return Expression.Goto(label);
        }

        /// <summary>
        ///     Creates a <see cref="GotoExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         goto label2; // GotoExpression
        ///         
        ///         label2: ...
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="GotoExpression" />.</returns>
        public static GotoExpression Goto2() {
            var label = LabelTarget2();
            return Expression.Goto(label);
        }

        /// <summary>
        ///     Creates a <see cref="IndexExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         TestIndexerType1 instance = null;
        ///         ... instance[0] ... // IndexExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="IndexExpression" />.</returns>
        public static IndexExpression Index1() {
            var instance = Expression.Constant(null, typeof(TestIndexerType1));
            var indexer = typeof(TestIndexerType1).GetProperty(TestIndexerType1.IndexerName1);
            var arguments = new[] { Expression.Constant(0) };

            return Expression.MakeIndex(instance, indexer, arguments);
        }

        /// <summary>
        ///     Creates a <see cref="IndexExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         TestIndexerType2 instance = null;
        ///         ... instance[0] ... // IndexExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="IndexExpression" />.</returns>
        public static IndexExpression Index2() {
            var instance = Expression.Constant(null, typeof(TestIndexerType2));
            var indexer = typeof(TestIndexerType2).GetProperty(TestIndexerType2.IndexerName2);
            var arguments = new[] { Expression.Constant(1) };

            return Expression.MakeIndex(instance, indexer, arguments);
        }

        /// <summary>
        ///     Creates a <see cref="InvocationExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         var expr = new System.Action(() => {});
        ///         
        ///         expr(); // InvocationExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="InvocationExpression" />.</returns>
        public static InvocationExpression Invoke_Expression_LambdaType1() {
            var expr = Lambda_Action0_1();

            return Expression.Invoke(expr);
        }

        /// <summary>
        ///     Creates a <see cref="InvocationExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         delegate void MyAction();
        ///         var expr = new MyAction(() => {});
        ///         
        ///         expr(); // InvocationExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="InvocationExpression" />.</returns>
        public static InvocationExpression Invoke_Expression_LambdaType2() {
            var expr = Lambda_MyAction0_1();

            return Expression.Invoke(expr);
        }

        /// <summary>
        ///     Creates a <see cref="LabelExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         label1:
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LabelExpression" />.</returns>
        public static LabelExpression Label1() {
            var label = LabelTarget1();

            return Expression.Label(label);
        }

        /// <summary>
        ///     Creates a <see cref="LabelExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         label2:
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LabelExpression" />.</returns>
        public static LabelExpression Label2() {
            var label = LabelTarget2();

            return Expression.Label(label);
        }

        /// <summary>
        ///     Creates a <see cref="LabelTarget" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         label1:
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LabelTarget" />.</returns>
        public static LabelTarget LabelTarget1() {
            return Expression.Label("label1");
        }

        /// <summary>
        ///     Creates a <see cref="LabelTarget" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         label2:
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LabelTarget" />.</returns>
        public static LabelTarget LabelTarget2() {
            return Expression.Label("label2");
        }

        /// <summary>
        ///     Creates a <see cref="LambdaExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new System.Action(() => {})
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LambdaExpression" />.</returns>
        public static LambdaExpression Lambda_Action0_1() {
            var body = Expression.Empty();

            return Expression.Lambda<Action>(body);
        }

        /// <summary>
        ///     Creates a <see cref="LambdaExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new System.Action(() => { throw new System.NotImplementedException(); })
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LambdaExpression" />.</returns>
        public static LambdaExpression Lambda_Action0_2() {
            var body = Block2();

            return Expression.Lambda<Action>(body);
        }

        /// <summary>
        ///     Creates a <see cref="LambdaExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         delegate void MyAction();
        ///         
        ///         new MyAction(() => {}) // LambdaExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LambdaExpression" />.</returns>
        public static LambdaExpression Lambda_MyAction0_1() {
            var body = Expression.Empty();

            return Expression.Lambda<MyAction>(body);
        }

        /// <summary>
        ///     Creates a <see cref="ListInitExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         // start of ListInitExpression
        ///         new List<string> {
        ///             "Foo"
        ///         }
        ///         // end of ListInitExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ListInitExpression" />.</returns>
        public static ListInitExpression ListInit1() {
            var type = typeof(List<string>);
            var ctor = type.GetConstructor(Type.EmptyTypes);
            var newExpr = Expression.New(ctor);

            var elemInit = ElementInit1();

            return Expression.ListInit(newExpr, elemInit);
        }

        /// <summary>
        ///     Creates a <see cref="ListInitExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         // start of ListInitExpression
        ///         new List<int> {
        ///             0
        ///         }
        ///         // end of ListInitExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ListInitExpression" />.</returns>
        public static ListInitExpression ListInit2() {
            var type = typeof(List<int>);
            var ctor = type.GetConstructor(Type.EmptyTypes);
            var newExpr = Expression.New(ctor);

            var elemInit = ElementInit2();

            return Expression.ListInit(newExpr, elemInit);
        }

        /// <summary>
        ///     Creates a <see cref="LoopExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         for {;;};
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LoopExpression" />.</returns>
        public static LoopExpression Loop1() {
            var body = Block1();

            return Expression.Loop(body);
        }

        /// <summary>
        ///     Creates a <see cref="LoopExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         for {;;} { throw new System.NotImplementedException(); }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="LoopExpression" />.</returns>
        public static LoopExpression Loop2() {
            var body = Block2();

            return Expression.Loop(body);
        }

        /// <summary>
        ///     Creates a <see cref="MemberExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { int Key1; int Key2 }
        ///         
        ///         ((TestType1)null).Key1 // MemberExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberExpression" />.</returns>
        public static MemberExpression Member1() {
            var expr = Expression.Constant(null, typeof(TestType1));
            var memInfo = typeof(TestType1).GetProperty(nameof(TestType1.Key1));

            return Expression.MakeMemberAccess(expr, memInfo);
        }

        /// <summary>
        ///     Creates a <see cref="MemberExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { int Key1; int Key2 }
        ///         
        ///         ((TestType1)null).Key2 // MemberExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberExpression" />.</returns>
        public static MemberExpression Member2() {
            var expr = Expression.Constant(null, typeof(TestType1));
            var memInfo = typeof(TestType1).GetProperty(nameof(TestType1.Key2));

            return Expression.MakeMemberAccess(expr, memInfo);
        }

        /// <summary>
        ///     Creates a <see cref="MemberAssignment" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { int Key1; int Key2 }
        ///         
        ///         ((TestType1)null).Key1 = 1 // MemberAssignment
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberAssignment" />.</returns>
        public static MemberAssignment MemberAssignment1() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Key1));
            var expr = Expression.Constant(1);

            return Expression.Bind(mem, expr);
        }

        /// <summary>
        ///     Creates a <see cref="MemberAssignment" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { int Key1; int Key2 }
        ///         
        ///         ((TestType1)null).Key2 = 1 // MemberAssignment
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberAssignment" />.</returns>
        public static MemberAssignment MemberAssignment2() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Key2));
            var expr = Expression.Constant(1);

            return Expression.Bind(mem, expr);
        }

        /// <summary>
        ///     Creates a <see cref="MemberInitExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { int Key1; int Key2 }
        ///
        ///         new TestType1 
        ///         { } // MemberInitExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberInitExpression" />.</returns>
        public static MemberInitExpression MemberInit1() {
            Expression<Func<TestType1>> expr = () => new TestType1 { };

            return (MemberInitExpression)expr.Body;
        }

        /// <summary>
        ///     Creates a <see cref="MemberInitExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType2 { int Key1; int Key2 }
        ///         
        ///         new TestType2
        ///         { } // MemberInitExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberInitExpression" />.</returns>
        public static MemberInitExpression MemberInit2() {
            Expression<Func<TestType2>> expr = () => new TestType2 { };

            return (MemberInitExpression)expr.Body;
        }

        /// <summary>
        ///     Creates a <see cref="MemberListBinding" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { List<string> Children1; }
        ///
        ///         new TestType1  { 
        ///             Children1 = { "Foo" } // MemberListBinding
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberListBinding" />.</returns>
        public static MemberListBinding MemberListBinding1() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Children1));
            var init = ElementInit1();

            return Expression.ListBind(mem, init);
        }

        /// <summary>
        ///     Creates a <see cref="MemberListBinding" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { List<int> Children2; }
        ///
        ///         new TestType1  { 
        ///             Children2 = { 0 } // MemberListBinding
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberListBinding" />.</returns>
        public static MemberListBinding MemberListBinding2() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Children2));
            var init = ElementInit2();

            return Expression.ListBind(mem, init);
        }

        /// <summary>
        ///     Creates a <see cref="MemberMemberBinding" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { 
        ///             TestType1 Root { get; set; }; 
        ///             int Key1 { get; set; } 
        ///         }
        ///         
        ///         new TestType1 {
        ///             Root = new TestType1 {
        ///                 Key1 = 1 // MemberMemberBinding
        ///             }
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberMemberBinding" />.</returns>
        public static MemberMemberBinding MemberMemberBinding1() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Root));
            var binding = MemberAssignment1();

            return Expression.MemberBind(mem, binding);
        }

        /// <summary>
        ///     Creates a <see cref="MemberMemberBinding" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class TestType1 { 
        ///             TestType1 Root { get; set; }; 
        ///             int Key2 { get; set; } 
        ///         }
        ///         
        ///         new TestType1 {
        ///             Root = new TestType1 {
        ///                 Key2 = 1 // MemberMemberBinding
        ///             }
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MemberMemberBinding" />.</returns>
        public static MemberMemberBinding MemberMemberBinding2() {
            var type = typeof(TestType1);
            var mem = type.GetProperty(nameof(TestType1.Root));
            var binding = MemberAssignment2();

            return Expression.MemberBind(mem, binding);
        }

        /// <summary>
        ///     Creates a <see cref="MethodCallExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         "Foo".ToString()
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MethodCallExpression" />.</returns>
        public static MethodCallExpression MethodCall1() {
            var instance = "Foo";
            var instanceExpr = Expression.Constant(instance);
            var type = typeof(string);
            var method = type.GetMethod(nameof(string.ToString), Type.EmptyTypes);

            return Expression.Call(instanceExpr, method);
        }

        /// <summary>
        ///     Creates a <see cref="MethodCallExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         "Bar".GetHashCode()
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="MethodCallExpression" />.</returns>
        public static MethodCallExpression MethodCall2() {
            var instance = "Bar";
            var instanceExpr = Expression.Constant(instance);
            var type = typeof(string);
            var method = type.GetMethod(nameof(string.GetHashCode));

            return Expression.Call(instanceExpr, method);
        }

        /// <summary>
        ///     Creates a <see cref="NewExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class CtorTestType {
        ///             public CtorTestType(int x) {}
        ///         }
        ///         
        ///         new CtorTestType(Key1 = default(int)) // NewExpression with Key1 pseudo-initialized by ctor
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="NewExpression" />.</returns>
        public static NewExpression New1_0() {
            var type = typeof(CtorTestType);
            var argType = typeof(int);
            var ctor = type.GetConstructor(new Type[] { argType });
            var arg = Expression.Default(argType);
            var mem0 = type.GetProperty(nameof(CtorTestType.Key1));

            return Expression.New(ctor, new[] { arg }, mem0);
        }

        /// <summary>
        ///     Creates a <see cref="NewExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class CtorTestType {
        ///             public CtorTestType(int x) {}
        ///         }
        ///         
        ///         new CtorTestType(Key2 = default(int)) // NewExpression with Key2 pseudo-initialized by ctor
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="NewExpression" />.</returns>
        public static NewExpression New1_1() {
            var type = typeof(CtorTestType);
            var argType = typeof(int);
            var ctor = type.GetConstructor(new Type[] { argType });
            var arg = Expression.Default(argType);
            var mem1 = type.GetProperty(nameof(CtorTestType.Key2));

            return Expression.New(ctor, new[] { arg }, mem1);
        }

        /// <summary>
        ///     Creates a <see cref="NewExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         class CtorTestType {
        ///             public CtorTestType(string x) {}
        ///         }
        ///         
        ///         new CtorTestType(default(string)) // NewExpression
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="NewExpression" />.</returns>
        public static NewExpression New2() {
            var type = typeof(CtorTestType);
            var argType = typeof(string);
            var ctor = type.GetConstructor(new Type[] { argType });
            var arg = Expression.Default(argType);

            return Expression.New(ctor, arg);
        }

        /// <summary>
        ///     Creates a <see cref="NewArrayExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new string[] {}
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="NewArrayExpression" />.</returns>
        public static NewArrayExpression NewArray1() {
            var type = typeof(string[]);

            return Expression.NewArrayInit(type);
        }

        /// <summary>
        ///     Creates a <see cref="NewArrayExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new int[] {}
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="NewArrayExpression" />.</returns>
        public static NewArrayExpression NewArray2() {
            var type = typeof(int[]);

            return Expression.NewArrayInit(type);
        }

        /// <summary>
        ///     Creates a <see cref="ParameterExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new Action<string>(
        ///             (string x) // ParameterExpression
        ///             => {})
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ParameterExpression" />.</returns>
        public static ParameterExpression Parameter1() {
            return Parameter<string>();
        }

        /// <summary>
        ///     Creates a <see cref="ParameterExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new Action<string>(
        ///             (int x) // ParameterExpression
        ///             => {})
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ParameterExpression" />.</returns>
        public static ParameterExpression Parameter2() {
            return Parameter<int>();
        }

        /// <summary>
        ///     Creates a <see cref="ParameterExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         new Action<T>(
        ///             (T x) // ParameterExpression
        ///             => {})
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="ParameterExpression" />.</returns>
        private static ParameterExpression Parameter<T>() {
            return Expression.Variable(typeof(T), "x");
        }

        /// <summary>
        ///     Creates a <see cref="RuntimeVariablesExpression" />.
        /// </summary>
        /// <returns>A <see cref="RuntimeVariablesExpression" />.</returns>
        public static RuntimeVariablesExpression RuntimeVariables1() {
            var p = Parameter1();

            return Expression.RuntimeVariables(p);
        }

        /// <summary>
        ///     Creates a <see cref="RuntimeVariablesExpression" />.
        /// </summary>
        /// <returns>A <see cref="RuntimeVariablesExpression" />.</returns>
        public static RuntimeVariablesExpression RuntimeVariables2() {
            var p = Parameter2();

            return Expression.RuntimeVariables(p);
        }

        /// <summary>
        ///     Creates a <see cref="SwitchExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         switch(true) {
        ///             case true: {}
        ///             default: {}
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="SwitchExpression" />.</returns>
        public static SwitchExpression Switch1() {
            var condition = Expression.Constant(true);
            var defaultBody = Block1();
            var @case = SwitchCase1();
            
            return Expression.Switch(condition, defaultBody, @case);
        }

        /// <summary>
        ///     Creates a <see cref="SwitchExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         switch(false) {
        ///             case true: {}
        ///             default: {}
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="SwitchExpression" />.</returns>
        public static SwitchExpression Switch2() {
            var condition = Expression.Constant(false);
            var defaultBody = Block1();
            var @case = SwitchCase1();

            return Expression.Switch(condition, defaultBody, @case);
        }

        /// <summary>
        ///     Creates a <see cref="SwitchCase" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         case true: {}
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="SwitchCase" />.</returns>
        public static SwitchCase SwitchCase1() {
            var body = Block1();
            var testValues = Expression.Constant(true);

            return Expression.SwitchCase(body, testValues);
        }

        /// <summary>
        ///     Creates a <see cref="SwitchCase" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         case false: {}
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="SwitchCase" />.</returns>
        public static SwitchCase SwitchCase2() {
            var body = Block2();
            var testValues = Expression.Constant(false);

            return Expression.SwitchCase(body, testValues);
        }

        /// <summary>
        ///     Creates a <see cref="TryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         try { 
        ///         } finally { 
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="TryExpression" />.</returns>
        public static TryExpression Try1() {
            var tryBlock = Block1();
            var finallyBlock = Block1();

            return Expression.TryFinally(tryBlock, finallyBlock);
        }

        /// <summary>
        ///     Creates a <see cref="TryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         try { 
        ///             throw new System.NotImplementedException(); 
        ///         } finally {
        ///         }
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="TryExpression" />.</returns>
        public static TryExpression Try2() {
            var tryBlock = Block2();
            var finallyBlock = Block1();

            return Expression.TryFinally(tryBlock, finallyBlock);
        }

        /// <summary>
        ///     Creates a <see cref="TypeBinaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         1 is int
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="TypeBinaryExpression" />.</returns>
        public static TypeBinaryExpression TypeBinary1() {
            var expr = Constant1();
            var type = typeof(int);

            return Expression.TypeIs(expr, type);
        }

        /// <summary>
        ///     Creates a <see cref="TypeBinaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         1 is string
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="TypeBinaryExpression" />.</returns>
        public static TypeBinaryExpression TypeBinary2() {
            var expr = Constant1();
            var type = typeof(string);

            return Expression.TypeIs(expr, type);
        }

        /// <summary>
        ///     Creates a <see cref="UnaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         ~0
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="UnaryExpression" />.</returns>
        public static UnaryExpression Unary1() {
            var expr = Expression.Constant(0);

            return Expression.Not(expr);
        }

        /// <summary>
        ///     Creates a <see cref="UnaryExpression" />.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         ++0
        ///     ]]></code>
        /// </remarks>
        /// <returns>A <see cref="UnaryExpression" />.</returns>
        public static UnaryExpression Unary2() {
            var expr = Expression.Constant(0);

            return Expression.UnaryPlus(expr);
        }

        /// <summary>
        ///     Creates an expression that throws a <see cref="NotImplementedException"/>.
        /// </summary>
        /// <remarks>
        ///     <code lang="C#"><![CDATA[
        ///         throw new System.NotImplementedException()
        ///     ]]></code>
        /// </remarks>
        /// <returns>An expression that throws a <see cref="NotImplementedException"/>.</returns>
        private static UnaryExpression Throw_NotImplementedException() {
            var type = typeof(NotImplementedException);
            var instance = Expression.New(type);
            return Expression.Throw(instance);
        }

        /// <summary>
        ///     A delegate with the same signature as <see cref="System.Action"/>.
        /// </summary>
        public delegate void MyAction();

        /// <summary>
        ///     A simple type containing constructors and members.
        /// </summary>
        public class CtorTestType {
            /// <summary>
            ///     Constructor taking an int parameter.
            /// </summary>
            /// <param name="x">Some int parameter.</param>
            public CtorTestType(int x) { }

            /// <summary>
            ///     Constructor taking a string parameter.
            /// </summary>
            /// <param name="x">Some string parameter.</param>
            public CtorTestType(string x) { }

            /// <summary>
            ///     A property.
            /// </summary>
            public int Key1 { get; set; }

            /// <summary>
            ///     Another property.
            /// </summary>
            public int Key2 { get; set; }
        }

        /// <summary>
        ///     Some type.
        /// </summary>
        public class TestType1 {
            /// <summary>
            ///     Some property.
            /// </summary>
            public int Key1 { get; set; }

            /// <summary>
            ///     Another property.
            /// </summary>
            public int Key2 { get; set; }

            /// <summary>
            ///     A member that has initializable members.
            /// </summary>
            public TestType1 Root { get; }

            /// <summary>
            ///     A member that is list-initializable.
            /// </summary>
            public List<string> Children1 { get; }

            /// <summary>
            ///     Another member that is list-initializable.
            /// </summary>
            public List<int> Children2 { get; }
        }

        /// <summary>
        ///     Some other type.
        /// </summary>
        public class TestType2 {
            /// <summary>
            ///     A property.
            /// </summary>
            public int Key1 { get; set; }

            /// <summary>
            ///     Another property.
            /// </summary>
            public int Key2 { get; set; }

            /// <summary>
            ///     A member that has initializable members.
            /// </summary>
            public TestType2 Root { get; }

            /// <summary>
            ///     A member that is list-initializable.
            /// </summary>
            public List<string> Children1 { get; }
            /// <summary>
            ///     Another member that is list-initializable.
            /// </summary>
            public List<int> Children2 { get; }
        }

        /// <summary>
        ///     Some type with an indexer.
        /// </summary>
        public class TestIndexerType1 {
            /// <summary>
            ///     Discoverable name of the indexer.
            /// </summary>
            public const string IndexerName1 = "Item1";

            /// <summary>
            ///     Some indexer.
            /// </summary>
            /// <param name="x">Some parameter.</param>
            /// <returns><paramref name="x"/>.</returns>
            [IndexerName(IndexerName1)]
            public int this[int x] {
                get { return x; }
            }
        }

        /// <summary>
        ///     Another type with an indexer.
        /// </summary>
        public class TestIndexerType2 : TestIndexerType1 {
            /// <summary>
            ///     Discoverable name of the indexer.
            /// </summary>
            public const string IndexerName2 = "Item2";

            /// <summary>
            ///     Some indexer.
            /// </summary>
            /// <param name="x">Some parameter.</param>
            /// <returns><paramref name="x"/>.</returns>
            [IndexerName(IndexerName2)]
            public new int this[int x] {
                get { return x; }
            }
        }

        /// <summary>
        ///     Some <see cref="CallSiteBinder"/> for use with dynamic Expressions.
        /// </summary>
        public class TestBinder : CallSiteBinder {
            /// <summary>
            ///     Not implemented.
            /// </summary>
            /// <param name="args">Not used.</param>
            /// <param name="parameters">Not used.</param>
            /// <param name="returnLabel">Not used.</param>
            /// <returns>Always throws.</returns>
            public override Expression Bind(object[] args, ReadOnlyCollection<ParameterExpression> parameters, LabelTarget returnLabel) {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Some extension expression.
        /// </summary>
        public class ExtensionExpression : Expression {
            /// <summary>
            ///     Constructs a new instance of <see cref="ExtensionExpression"/>.
            /// </summary>
            /// <param name="canReduce">Whether this object is reducible or not.</param>
            public ExtensionExpression(bool canReduce) {
                this.CanReduce = canReduce;
            }
            
            /// <summary>
            ///     Gets the node type: <see cref="ExpressionType.Extension"/>.
            /// </summary>
            public override ExpressionType NodeType {
                get {
                    return ExpressionType.Extension;
                }
            }

            /// <summary>
            ///     Gets the static type of the represented expression: <see cref="object"/>.
            /// </summary>
            public override Type Type {
                get {
                    return typeof(object);
                }
            }

            /// <summary>
            ///     Gets whether the node can be reduced to a simpler form: true.
            /// </summary>
            public override bool CanReduce { get; }

            /// <summary>
            ///     Gets whether the 
            /// </summary>
            /// <returns></returns>
            public override Expression Reduce() {
                return Expression.Constant(null, typeof(object));
            }
        }
    }
}
