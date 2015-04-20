namespace VsoApi.MsAgile.Entities.Linq
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using ExpressionVisitor = IQToolkit.ExpressionVisitor;

    public class QueryTranslator : ExpressionVisitor
    {
        private StringBuilder _builder;

        public string Translate(Expression expression)
        {
            _builder = new StringBuilder();
            Visit(expression);
            return _builder.ToString();
        }

        private static Expression StripQuotes(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote) {
                e = ((UnaryExpression) e).Operand;
            }
            return e;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType != typeof(Queryable) && m.Method.DeclaringType != typeof(BaseEntityQueryExtensions))
                throw new NotSupportedException(string.Format("The method '{0}' is part of an unexpected type and is not supported", m.Method.Name));
            
            if (m.Method.Name != "Where" && m.Method.Name != "AsOf")
                throw new NotSupportedException(string.Format("The method '{0}' is not recognized", m.Method.Name));

            if (m.Method.Name == "Where") {
                _builder.Append("SELECT * ");
                Visit(m.Arguments[0]);
                var lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
                Visit(lambda.Body);
            }

            if (m.Method.Name == "AsOf") {
                VisitMethodCall((MethodCallExpression)m.Arguments[0]);

                var dateParameter = (ConstantExpression)m.Arguments[1];
                _builder.AppendFormat(
                    CultureInfo.InvariantCulture,
                    " ASOF '{0}'",
                    ((DateTime)dateParameter.Value).ToString("MM/dd/yy HH:mm", CultureInfo.InvariantCulture));
            }
            
            return m;
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType) {
                case ExpressionType.Not:
                    _builder.Append(" NOT ");
                    Visit(u.Operand);
                    break;

                case ExpressionType.Convert:
                    if (u.Type == typeof (string)) {
                        _builder.Append("'");
                        Visit(u.Operand);
                        _builder.Append("'");
                    } else {
                        Visit(u.Operand);
                    }

                    break;

                default:
                    throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
            }

            return u;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            Visit(b.Left);

            switch (b.NodeType) {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    _builder.Append(" AND ");
                    break;
                case ExpressionType.Or:
                    _builder.Append(" OR");
                    break;
                case ExpressionType.Equal:
                    _builder.Append(" = ");
                    break;
                case ExpressionType.NotEqual:
                    _builder.Append(" <> ");
                    break;
                case ExpressionType.LessThan:
                    _builder.Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    _builder.Append(" <= ");
                    break;
                case ExpressionType.GreaterThan:
                    _builder.Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    _builder.Append(" >= ");
                    break;
                default:
                    throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
            }

            Visit(b.Right);
            return b;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            var q = c.Value as IQueryable;
            if (q != null) {
                // assume constant nodes w/ IQueryables are workitem type references
                Type workItemType = q.ElementType;
                if (typeof(BaseEntity).IsAssignableFrom(workItemType) == false)
                    throw new NotSupportedException("Unable to execute a query over type: " + workItemType.FullName);

                // todo: use an attribute?
                BaseEntity workItem = (BaseEntity)Activator.CreateInstance(
                    workItemType, 
                    BindingFlags.Public | BindingFlags.Instance, 
                    null,
                    new object[] {}, 
                    null);

                _builder.AppendFormat("From WorkItems Where [System.WorkItemType] = '{0}' AND ", workItem.WorkItemType.DisplayName());
                return c;
            }

            if (c.Value == null) {
                _builder.Append("NULL");
                return c;
            }

            switch (Type.GetTypeCode(c.Value.GetType())) {
                case TypeCode.Boolean:
                    _builder.Append(((bool) c.Value) ? 1 : 0);
                    break;
                case TypeCode.DateTime:
                case TypeCode.String:
                    _builder.Append("'");
                    _builder.Append(c.Value);
                    _builder.Append("'");
                    break;
                case TypeCode.Object:
                    throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
                default:
                    _builder.Append(c.Value);
                    break;
            }

            return c;
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression == null || m.Expression.NodeType != ExpressionType.Parameter)
                throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));

            // Translation of the BaseEntity class (or subclass) property to a WorkItem property 
            // (which is corresponding JsonProperty attribute which will contain the actual name of the field in VSO API)


            string fieldName = AutoMapperHelper.GetRemoteFieldName(m);
            _builder.Append(fieldName);
            return m;
        }
    }
}