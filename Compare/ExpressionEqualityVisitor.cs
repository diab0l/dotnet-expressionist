namespace Expressionist.Compare {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     Compares the structure of one expression tree to the structure of another.
    /// </summary>
    public class ExpressionEqualityVisitor : ExpressionVisitor {
        private readonly Queue<object> items;

        private ExpressionEqualityVisitorMode mode;

        private bool equalsResult = true;
        private int hashCodeResult = 0;

        private ExpressionEqualityVisitor() {
            this.mode = ExpressionEqualityVisitorMode.LoadRhs;
            this.items = new Queue<object>();
        }

        private T VisitEx<T>(T node) {
            if (typeof(T) == typeof(Expression)) {
                return (T)(object)Visit((Expression)(object)node);
            }

            if (typeof(T) == typeof(CatchBlock)) {
                return (T)(object)VisitCatchBlock((CatchBlock)(object)node);
            }

            if (typeof(T) == typeof(ElementInit)) {
                return (T)(object)VisitElementInit((ElementInit)(object)node);
            }

            if (typeof(T) == typeof(MemberBinding)) {
                return (T)(object)VisitMemberBinding((MemberBinding)(object)node);
            }

            if (typeof(T) == typeof(SwitchCase)) {
                return (T)(object)VisitSwitchCase((SwitchCase)(object)node);
            }

            if (typeof(T) == typeof(LabelTarget)) {
                return (T)(object)VisitLabelTarget((LabelTarget)(object)node);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        ///     Implements processing of an <see cref="Expression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="Expression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="Expression.Type"/> and</description></item>
        ///         <item><description><see cref="Expression.NodeType"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        public override Expression Visit(Expression node) {
            if (node == null) {
                this.Process(node, "");

                if (!this.equalsResult) {
                    return node;
                }
                return base.Visit(node);
            }

            this.Process(node.Type, nameof(node.Type));
            this.Process(node.NodeType, nameof(node.NodeType));

            if (!this.equalsResult) {
                return node;
            }
            return base.Visit(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="BinaryExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="BinaryExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="BinaryExpression.IsLifted"/>,</description></item>
        ///         <item><description><see cref="BinaryExpression.IsLiftedToNull"/>,</description></item>
        ///         <item><description><see cref="BinaryExpression.Method"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitBinary(BinaryExpression node) {
            this.Process(node.IsLifted, nameof(node.IsLifted));
            this.Process(node.IsLiftedToNull, nameof(node.IsLiftedToNull));
            this.Process(node.Method, nameof(node.Method));

            return !this.equalsResult ? node : base.VisitBinary(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="BlockExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="BlockExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitBlock(BlockExpression node) {
            return base.VisitBlock(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="CatchBlock"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="CatchBlock"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="CatchBlock.Test"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override CatchBlock VisitCatchBlock(CatchBlock node) {
            this.Process(node.Test, nameof(node.Test));

            return !this.equalsResult ? node : base.VisitCatchBlock(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="ConditionalExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="ConditionalExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitConditional(ConditionalExpression node) {
            return base.VisitConditional(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="ConstantExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="ConstantExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="ConstantExpression.Value"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitConstant(ConstantExpression node) {
            this.Process(node.Value, nameof(node.Value));

            return !this.equalsResult ? node : base.VisitConstant(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="DebugInfoExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="DebugInfoExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="DebugInfoExpression.Document"/>,</description></item>
        ///         <item><description><see cref="DebugInfoExpression.EndColumn"/>,</description></item>
        ///         <item><description><see cref="DebugInfoExpression.EndLine"/>,</description></item>
        ///         <item><description><see cref="DebugInfoExpression.IsClear"/>,</description></item>
        ///         <item><description><see cref="DebugInfoExpression.StartColumn"/> and</description></item>
        ///         <item><description><see cref="DebugInfoExpression.StartLine"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitDebugInfo(DebugInfoExpression node) {
            this.Process(node.Document, nameof(node.Document));
            this.Process(node.EndColumn, nameof(node.EndColumn));
            this.Process(node.EndLine, nameof(node.EndLine));
            this.Process(node.IsClear, nameof(node.IsClear));
            this.Process(node.StartColumn, nameof(node.StartColumn));
            this.Process(node.StartLine, nameof(node.StartLine));

            return !this.equalsResult ? node : base.VisitDebugInfo(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="DefaultExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="DefaultExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitDefault(DefaultExpression node) {
            return base.VisitDefault(node);
        }

        /// <summary>
        ///     Throws a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="node">Not used.</param>
        /// <returns>Always throws.</returns>
        protected override Expression VisitDynamic(DynamicExpression node) {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Implements processing of a <see cref="ElementInit"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="ElementInit"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="ElementInit.AddMethod"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override ElementInit VisitElementInit(ElementInit node) {
            this.Process(node.AddMethod, nameof(node.AddMethod));

            return !this.equalsResult ? node : base.VisitElementInit(node);
        }

        /// <summary>
        ///     Implements processing of an Extension<see cref="Expression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     Throws if <paramref name="node"/> is not reducible, otherwise continues analysis with it's reduced form.
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitExtension(Expression node) {
            if (!node.CanReduce) {
                throw new NotSupportedException();
            }

            return !this.equalsResult ? node : base.VisitExtension(node);
        }

        /// <summary>
        ///     Implements processing of an <see cref="IndexExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="IndexExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="IndexExpression.Indexer"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitIndex(IndexExpression node) {
            this.Process(node.Indexer, nameof(node.Indexer));

            return !this.equalsResult ? node : base.VisitIndex(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="GotoExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="GotoExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="GotoExpression.Kind"/>.</description></item>
        ///         <item><description><see cref="GotoExpression.Target"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitGoto(GotoExpression node) {
            this.Process(node.Kind, nameof(node.Kind));
            this.Process(node.Target, nameof(node.Target));

            return !this.equalsResult ? node : base.VisitGoto(node);
        }

        /// <summary>
        ///     Implements processing of an <see cref="InvocationExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="InvocationExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitInvocation(InvocationExpression node) {
            return base.VisitInvocation(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="LabelExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="LabelExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="LabelExpression.Target"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitLabel(LabelExpression node) {
            this.Process(node.Target, nameof(node.Target));

            return !this.equalsResult ? node : base.VisitLabel(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="LabelTarget"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="LabelTarget"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="LabelTarget.Name"/> and</description></item>
        ///         <item><description><see cref="LabelTarget.Type"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override LabelTarget VisitLabelTarget(LabelTarget node) {
            if (node == null) {
                return base.VisitLabelTarget(node);
            }

            this.Process(node.Name, nameof(node.Name));
            this.Process(node.Type, nameof(node.Type));

            return !this.equalsResult ? node : base.VisitLabelTarget(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="Expression{TDelegate}"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="Expression{TDelegate}"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="LambdaExpression.Name"/>,</description></item>
        ///         <item><description><see cref="LambdaExpression.ReturnType"/> and</description></item>
        ///         <item><description><see cref="LambdaExpression.TailCall"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitLambda<T>(Expression<T> node) {
            this.Process(node.Name, nameof(node.Name));
            this.Process(node.ReturnType, nameof(node.ReturnType));
            this.Process(node.TailCall, nameof(node.TailCall));

            return !this.equalsResult ? node : base.VisitLambda(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="ListInitExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="ListInitExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitListInit(ListInitExpression node) {
            return base.VisitListInit(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="LoopExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="LoopExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="LoopExpression.BreakLabel"/> and</description></item>
        ///         <item><description><see cref="LoopExpression.ContinueLabel"/>.</description></item>
        ///     </list>
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitLoop(LoopExpression node) {
            this.Process(node.BreakLabel, nameof(node.BreakLabel));
            this.Process(node.ContinueLabel, nameof(node.ContinueLabel));

            return !this.equalsResult ? node : base.VisitLoop(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="MemberExpression.Member"/>.</description></item>
        ///     </list>
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitMember(MemberExpression node) {
            this.Process(node.Member, nameof(node.Member));

            return !this.equalsResult ? node : base.VisitMember(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberAssignment"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberAssignment"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node) {
            return base.VisitMemberAssignment(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberBinding"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberBinding"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="MemberBinding.BindingType"/>.</description></item>
        ///         <item><description><see cref="MemberBinding.Member"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override MemberBinding VisitMemberBinding(MemberBinding node) {
            this.Process(node.BindingType, nameof(node.BindingType));
            this.Process(node.Member, nameof(node.Member));

            return !this.equalsResult ? node : base.VisitMemberBinding(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberInitExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberInitExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitMemberInit(MemberInitExpression node) {
            return base.VisitMemberInit(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberListBinding"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberListBinding"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node) {
            return base.VisitMemberListBinding(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MemberMemberBinding"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MemberMemberBinding"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node) {
            return base.VisitMemberMemberBinding(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="MethodCallExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="MethodCallExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="MethodCallExpression.Method"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node) {
            this.Process(node.Method, nameof(node.Method));

            return !this.equalsResult ? node : base.VisitMethodCall(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="NewExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="NewExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="NewExpression.Constructor"/> and</description></item>
        ///         <item><description><see cref="NewExpression.Members"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitNew(NewExpression node) {
            this.Process(node.Constructor, nameof(node.Constructor));
            this.Process(node.Members, nameof(node.Members));

            return !this.equalsResult ? node : base.VisitNew(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="NewArrayExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="NewArrayExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitNewArray(NewArrayExpression node) {
            return base.VisitNewArray(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="ParameterExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="ParameterExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="ParameterExpression.IsByRef"/>.</description></item>
        ///         <item><description><see cref="ParameterExpression.Name"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitParameter(ParameterExpression node) {
            this.Process(node.IsByRef, nameof(node.IsByRef));
            this.Process(node.Name, nameof(node.Name));

            return !this.equalsResult ? node : base.VisitParameter(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="RuntimeVariablesExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="RuntimeVariablesExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node) {
            return base.VisitRuntimeVariables(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="SwitchExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="SwitchExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="SwitchExpression.Comparison"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitSwitch(SwitchExpression node) {
            this.Process(node.Comparison, nameof(node.Comparison));

            return !this.equalsResult ? node : base.VisitSwitch(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="SwitchCase"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="SwitchCase"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override SwitchCase VisitSwitchCase(SwitchCase node) {
            return base.VisitSwitchCase(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="TryExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="TryExpression"/>'s processed members are:
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitTry(TryExpression node) {
            return base.VisitTry(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="TypeBinaryExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="TypeBinaryExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="TypeBinaryExpression.TypeOperand"/>.</description></item>
        ///     </list>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitTypeBinary(TypeBinaryExpression node) {
            this.Process(node.TypeOperand, nameof(node.TypeOperand));

            return !this.equalsResult ? node : base.VisitTypeBinary(node);
        }

        /// <summary>
        ///     Implements processing of a <see cref="UnaryExpression"/>'s members.
        /// </summary>
        /// <remarks>
        ///     <see cref="UnaryExpression"/>'s processed members are:
        ///     <list type="bullet">
        ///         <item><description><see cref="UnaryExpression.IsLifted"/>,</description></item>
        ///         <item><description><see cref="UnaryExpression.IsLiftedToNull"/> and</description></item>
        ///         <item><description><see cref="UnaryExpression.Method"/>.</description></item>
        ///     </list>
        ///     <para>none.</para>
        /// </remarks>
        /// <param name="node">The node to process.</param>
        /// <returns>The unchanged <paramref name="node"/>.</returns>
        protected override Expression VisitUnary(UnaryExpression node) {
            this.Process(node.IsLifted, nameof(node.IsLifted));
            this.Process(node.IsLiftedToNull, nameof(node.IsLiftedToNull));
            this.Process(node.Method, nameof(node.Method));

            return !this.equalsResult ? node : base.VisitUnary(node);
        }

        private void Process(SymbolDocumentInfo node, string name) {
            this.Process(node.DocumentType, nameof(node.DocumentType));
            this.Process(node.FileName, nameof(node.FileName));
            this.Process(node.Language, nameof(node.Language));
            this.Process(node.LanguageVendor, nameof(node.LanguageVendor));
        }

        private void Process(LabelTarget node, string name) {
            if (node == null) {
                this.Process<LabelTarget>(node, name);
                return;
            }

            this.Process(node.Name, nameof(node.Name));
            this.Process(node.Type, nameof(node.Type));
        }

        private void Process(ReadOnlyCollection<MemberInfo> node, string name) {
            if (node == null) {
                this.Process<ReadOnlyCollection<MemberInfo>>(node, name);
                return;
            }

            if (this.mode == ExpressionEqualityVisitorMode.LoadRhs) {
                this.Process<ReadOnlyCollection<MemberInfo>>(node, name);
                return;
            }

            if (this.mode == ExpressionEqualityVisitorMode.Equals) {
                this.Process<ReadOnlyCollection<MemberInfo>>(node, name);
                return;
            }

            if (this.mode == ExpressionEqualityVisitorMode.GetHashCode) {
                var hashCode = GetHashCodeForValue(node);
                this.hashCodeResult = (this.hashCodeResult * 397) ^ hashCode;
                return;
            }

            throw new NotSupportedException();
        }

        private void Process<T>(T value, string name) {
            if (this.mode == ExpressionEqualityVisitorMode.LoadRhs) {
                this.Collect(value, name);
                return;
            }

            if (this.mode == ExpressionEqualityVisitorMode.Equals) {
                this.equalsResult &= this.EqualToNext(value, name);
                return;
            }

            if (this.mode == ExpressionEqualityVisitorMode.GetHashCode) {
                var hashCode = GetHashCodeForValue(value);
                this.hashCodeResult = (this.hashCodeResult * 397) ^ hashCode;
                return;
            }

            throw new NotSupportedException();
        }

        private void Collect<T>(T value, string name) {
            this.items.Enqueue(value);
        }

        private Tuple<object, T> ExpectNext<T>(string name = null) {
            if (this.items.Count == 0) {
                return Tuple.Create((object)null, default(T));
            }

            var actual = this.items.Dequeue();
            var cast = (actual is T) ? (T)actual : default(T);

            return Tuple.Create(actual, cast);
        }

        private bool EqualToNext<T>(T value, string name = null) {
            var next = ExpectNext<T>(name);

            return AreComponentsEqual<T>(value, next.Item2);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="Expression"/>.</param>
        /// <param name="rhs">Another <see cref="Expression"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(Expression lhs, Expression rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="CatchBlock"/>.</param>
        /// <param name="rhs">Another <see cref="CatchBlock"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(CatchBlock lhs, CatchBlock rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="ElementInit"/>.</param>
        /// <param name="rhs">Another <see cref="ElementInit"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(ElementInit lhs, ElementInit rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="SwitchCase"/>.</param>
        /// <param name="rhs">Another <see cref="SwitchCase"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(SwitchCase lhs, SwitchCase rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="MemberBinding"/>.</param>
        /// <param name="rhs">Another <see cref="MemberBinding"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(MemberBinding lhs, MemberBinding rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        /// <summary>
        ///     Compares <paramref name="lhs"/> against <paramref name="rhs"/> for equality.
        /// </summary>
        /// <param name="lhs">Some <see cref="LabelTarget"/>.</param>
        /// <param name="rhs">Another <see cref="LabelTarget"/>.</param>
        /// <returns>True if <paramref name="lhs"/> is structually equal to <paramref name="rhs"/>.</returns>
        public static bool AreEqual(LabelTarget lhs, LabelTarget rhs) {
            return AreExpressionsEqual(lhs, rhs);
        }

        private static bool AreComponentsEqual<T>(T lhs, T rhs) {
            if (typeof(T) == typeof(ReadOnlyCollection<MemberInfo>)) {
                return AreEqual((ReadOnlyCollection<MemberInfo>)(object)lhs, (ReadOnlyCollection<MemberInfo>)(object)rhs);
            }

            return object.Equals(lhs, rhs);
        }

        private static bool AreExpressionsEqual<T>(T lhs, T rhs) {
            var visitor = new ExpressionEqualityVisitor { };

            visitor.mode = ExpressionEqualityVisitorMode.LoadRhs;
            visitor.VisitEx(rhs);

            visitor.mode = ExpressionEqualityVisitorMode.Equals;
            visitor.VisitEx(lhs);
            return visitor.equalsResult;
        }

        private static bool AreEqual(ReadOnlyCollection<MemberInfo> lhs, ReadOnlyCollection<MemberInfo> rhs) {
            if (lhs == null && rhs == null) {
                return true;
            }

            if (lhs == null || rhs == null) {
                return false;
            }

            if (!lhs.SequenceEqual(rhs)) {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(Expression expr) {
            return GetHashCodeFor<Expression>(expr);
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(CatchBlock expr) {
            return GetHashCodeFor<CatchBlock>(expr);
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(ElementInit expr) {
            return GetHashCodeFor<ElementInit>(expr);
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(SwitchCase expr) {
            return GetHashCodeFor<SwitchCase>(expr);
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(MemberBinding expr) {
            return GetHashCodeFor<MemberBinding>(expr);
        }

        /// <summary>
        ///     Calculates stable a hashcode for <paramref name="expr"/>.
        /// </summary>
        /// <param name="expr">The input expression.</param>
        /// <returns>A stable hashcode for <paramref name="expr"/>.</returns>
        public static int GetHashCodeFor(LabelTarget expr) {
            return GetHashCodeFor<LabelTarget>(expr);
        }

        private static int GetHashCodeFor<T>(T expr) {
            var visitor = new ExpressionEqualityVisitor { };

            visitor.mode = ExpressionEqualityVisitorMode.GetHashCode;
            visitor.VisitEx(expr);

            return visitor.hashCodeResult;
        }

        private static int GetHashCodeForValue<T>(T value) {
            if (value == null) {
                return 0;
            }

            return value.GetHashCode();
        }

        private static int GetHashCodeForValue(ReadOnlyCollection<MemberInfo> value) {
            if (value == null) {
                return 0;
            }

            var aggregate = 0;

            foreach (var member in value) {
                var hashCode = member.GetHashCode();
                aggregate = (aggregate * 397) ^ hashCode;
            }

            return aggregate;
        }

        /// <summary>
        ///     The mode in which the visitor's Process method operates.
        /// </summary>
        private enum ExpressionEqualityVisitorMode {
            /// <summary>
            ///     Save all the processed parts into a processing queue
            /// </summary>
            LoadRhs,

            /// <summary>
            ///     Compare the processed part to the next element in the processing queue
            /// </summary>
            Equals,

            /// <summary>
            ///     Calculates the hashcode for the processed part
            /// </summary>
            GetHashCode
        }
    }
}