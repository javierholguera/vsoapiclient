using System;

namespace VsoApi.Contracts.Requests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class GetListOfWorkitems : VsoRequest
    {
        public GetListOfWorkitems()
        {
            Ids = new Collection<string>();
            Fields = new Collection<string>();
        }

        // [&ids={string}&fields={string}&asof={datetime}&$expand={enum{relations}]

        public ICollection<string> Ids { get; private set; }
        public ICollection<string> Fields { get; private set; }
        public DateTime? AsOf { get; private set; }
        // todo: expand

    }
}
