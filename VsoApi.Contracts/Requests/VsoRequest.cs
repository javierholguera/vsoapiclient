namespace VsoApi.Contracts.Requests
{
    using System;

    public abstract class VsoRequest
    {
        // Paramater "api-version"
        public string ApiVersion { get { return "1.0"; }}
    }
}