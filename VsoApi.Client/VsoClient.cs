
namespace VsoApi.Client
{
    using System;
    using RestSharp;
    using VsoApi.Client.Resources;

    public class VsoClient
    {
        public VsoClient()
        {
            RestClient client = new RestClient(new Uri("https://javierholguera.visualstudio.com/defaultCollection/"));
            client.Authenticator = new HttpBasicAuthenticator("javierh", "1Vso#client1");
            WorkItemResources = new WorkItemResource(client);
            WorkItemTypeResources = new WorkItemTypeResource(client);
            WiqlResources = new WiqlResource(client);
            FieldResources = new FieldResource(client);
        }

        public IWorkItemResource WorkItemResources { get; set; }
        public IWorkItemTypeResource WorkItemTypeResources { get; set; }
        public IWiqlResource WiqlResources { get; set; }
        public IFieldResource FieldResources { get; set; }
    }
}
