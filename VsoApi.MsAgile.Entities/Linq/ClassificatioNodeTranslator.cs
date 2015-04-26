namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using VsoApi.Contracts.Requests.WIT;
    using ExpressionVisitor = IQToolkit.ExpressionVisitor;

    public class ClassificatioNodeTranslator : ExpressionVisitor
    {
        private class ParamValuePair
        {
            public string Param { get; set; }
            public string Value { get; set; }
        }

        private Stack<ParamValuePair> _paramValueQueue; 

        public IterationRequest Translate(Expression expression)
        {
            _paramValueQueue = new Stack<ParamValuePair>();

            Visit(expression);

            ParamValuePair[] paramValues = _paramValueQueue.ToArray();
            string name = paramValues.Single(p => p.Param == "Name").Value;
            string project = paramValues.Single(p => p.Param == "Project").Value;
            return new IterationRequest(project, name);
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c.Type == typeof (string)) {
                _paramValueQueue.Peek().Value = (string)c.Value;
            }

            return c;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType != typeof (Queryable))
                throw new NotSupportedException(
                    string.Format("The method '{0}' is part of an unexpected type and is not supported", m.Method.Name));

            if (m.Method.Name != "Where")
                throw new NotSupportedException(string.Format("The method '{0}' is not recognized", m.Method.Name));

            Visit(m.Arguments[0]);
            Visit(m.Arguments[1]);

            return m;
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression == null || m.Expression.NodeType != ExpressionType.Parameter)
                throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));

            if (m.Member.Name != "Name" && m.Member.Name != "Project")
                throw new NotSupportedException(string.Format("The member '{0}' is not supported. Iterations can be queried only by Name and Project", m.Member.Name));

            _paramValueQueue.Push(new ParamValuePair { Param = m.Member.Name });

            return m;
        }
    }
}