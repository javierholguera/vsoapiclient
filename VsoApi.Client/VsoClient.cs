
namespace VsoApi.Client
{
    using System;
    using RestSharp;
    using VsoApi.Client.Resources;

    public class VsoClient
    {
        public VsoClient()
        {
            var client = new RestClient(new Uri("https://javierholguera.visualstudio.com/defaultCollection")) {
                Authenticator = new HttpBasicAuthenticator("javierh", "1Vso#client1")
            };
            WorkItemResources = new WorkItemResource(client);
            WorkItemTypeResources = new WorkItemTypeResource(client);
            WiqlResources = new WiqlResource(client);
            FieldResources = new FieldResource(client);
        }

        public IWorkItemResource WorkItemResources { get; private set; }
        public IWorkItemTypeResource WorkItemTypeResources { get; private set; }
        public IWiqlResource WiqlResources { get; private set; }
        public IFieldResource FieldResources { get; private set; }
    }
}
