namespace VsoApi.MsAgile.Entities
{
    using System.Collections.Generic;

    public class Query
    {
        public IEnumerable<QueryPredicate> Where { get; set; }
    }

    public class QueryPredicate
    {
        public QueryConjuction Conjuction { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public QueryOperator Operator { get; set; }
    }

    public enum QueryConjuction
    {
        And,
        Or
    }

    public enum QueryOperator
    {
        Equals,
        Under,
        Distinct,
        Contains
    }
}