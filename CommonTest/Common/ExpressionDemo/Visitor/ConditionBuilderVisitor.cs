﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Common.ExpressionDemo.DBExtend;
//Common.ExpressionDemo.DBExtend
namespace Common.ExpressionDemo.Visitor
{
    /// <summary>
    /// 用于动态拼接sql
    /// </summary>
   public  class ConditionBuilderVisitor:ExpressionVisitor
    {
        private Stack<string> _StringStack = new Stack<string>();
        public string Condition() {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }
        /// <summary>
        /// 如果是二元表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node) {
            if (node == null) throw new ArgumentNullException("BinaryExpression");
            this._StringStack.Push(")");
            base.Visit(node.Right);
            this._StringStack.Push($" {node.NodeType.ToSqlOperator()} ");
            base.Visit(node.Left);
            this._StringStack.Push("(");
            return node;
        }
        /// <summary>
        /// MemberExpression 字段或属性
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitMember(MemberExpression node) {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push($" [{node.Member.Name}] ");
            base.VisitMember(node);
            return node;
        }
        /// <summary>
        /// ConstantExpression 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node) {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push($" '{node.Value}' ");
            return node;
        }
        /// <summary>
        /// 静态方法或实例方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression m) {
            if (m == null) throw new ArgumentNullException("VisitMethodCall");
            string format;
            switch (m.Method.Name) {
                case "StartsWith":
                    format = "({0} LIKE {1}+'%')";
                    break;
                case "Contains":
                    format = "({0} LIKE '%'+{1}+'%')";
                    break;
                case "EndsWith":
                    format = "({} LIKE '%'+'%'+{1})";
                    break;
                default:
                    throw new NotSupportedException(m.NodeType+" is not supporde!");
            }
            this.Visit(m.Object );
            this.Visit(m.Arguments[0]);
            string right = this._StringStack.Pop();
            string left = this._StringStack.Pop();
            this._StringStack.Push(String.Format(format,left,right));
            return m;
        }
    }
}
