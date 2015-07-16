using System;
using System.Globalization;

namespace VsoApi.MsAgile.Entities
{
    using System.Collections.Generic;

    public class Iteration : BaseEntity
    {
        public Iteration()
        {
        }

        public Iteration(uint id)
        {
            Id = id.ToString(CultureInfo.InvariantCulture);
        }

        public string Name { get; set; }

        public string FullName
        {
            get
            {
                if (Parent == null)
                    return Name;

                return Parent.FullName + "\\" + Name;
            }
        }

        public int Depth { get; set; }

        // Root iterations don't have specific dates
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }

        public Iteration Parent { get; set; }
        public IEnumerable<Iteration> Children { get; set; } 
    }
}
