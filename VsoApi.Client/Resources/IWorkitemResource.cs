using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoApi.Client.Resources
{
    using VsoApi.Contracts;
    using VsoApi.Contracts.Requests;
    using VsoApi.Contracts.Responses;

    public interface IWorkitemResource
    {
        VsoResponse<Workitem> GetAll(VsoRequest request);
    }
}
