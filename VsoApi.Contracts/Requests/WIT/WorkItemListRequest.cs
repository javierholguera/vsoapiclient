namespace VsoApi.Contracts.Requests.WIT
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using RestSharp;

    public class WorkItemListRequest : VsoRequest
    {
        // Query string: [&ids={string}&Fields={string}&asof={datetime}&$expand={enum{relations}]

        public WorkItemListRequest(ICollection<string> ids) :
            this(ids, null, Enumerable.Empty<string>().ToArray())
        {
        }

        public WorkItemListRequest(
            ICollection<string> ids,
            DateTime? asOf,
            ICollection<string> fields,
            WorkItemExpandType expand = WorkItemExpandType.None)
            : base(string.Empty)
        {
            if (ids == null)
                throw new ArgumentNullException("ids");

            if (ids.Any() == false)
                throw new ArgumentException("A List of work items cannot be requested without ids", "ids");

            if (asOf != null && fields.Any() == false)
                throw new ArgumentException("A list of work items cannot be request with As Of date and without fields", "asOf");

            Ids = ids;
            AsOf = asOf;
            Fields = fields;
            Expand = expand;
        }

        private IEnumerable<string> Ids { get; set; }

        private IEnumerable<string> Fields { get; set; }
        private DateTime? AsOf { get; set; }
        private WorkItemExpandType Expand { get; set; }

        protected override Method Method
        {
            get { return Method.GET; }
        }

        protected override void CompleteRequest(IRestRequest restRequest)
        {
            if (restRequest == null)
                throw new ArgumentNullException("restRequest");

            if (Ids.Any())
                restRequest.AddQueryParameter("ids", string.Join(",", Ids));
            if (Fields.Any())
                restRequest.AddQueryParameter("Fields", string.Join(",", Fields));
            if (AsOf != null)
                restRequest.AddQueryParameter("asof", AsOf.Value.ToString(CultureInfo.InvariantCulture));

            restRequest.AddQueryParameter("$expand", Expand.ToString());
        }
    }
}