
namespace VsoApi.Client
{
    using RestSharp;
    using VsoApi.Client.Resources;

    public class VsoClient
    {
        public VsoClient()
        {
            RestClient client = new RestClient("https://javierholguera.visualstudio.com/defaultCollection/");
            client.Authenticator = new HttpBasicAuthenticator("javierh", "1Vso#client1");
            WorkItemResources = new WorkItemResource(client);
            WorkItemTypeResources = new WorkItemTypeResource(client);
            WqilResources = new WqilResource(client);
        }

        public IWorkItemResource WorkItemResources { get; set; }
        public IWorkItemTypeResource WorkItemTypeResources { get; set; }
        public IWqilResource WqilResources { get; set; }
    }
}
