using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoApi.Contracts.Requests
{
    public class GetListOfWorkitems : VsoRequest
    {
        public string[] ids { get; set; }
        public string[] fields { get; set; }
        public DateTime asOf { get; set; }
        
    }
}
