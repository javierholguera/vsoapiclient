using System;

namespace VsoApi.MsAgile.Entities
{
    using System.Collections.Generic;

    public class Iteration : BaseEntity
    {
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }

        public IEnumerable<Iteration> Children { get; set; } 
    }
}
