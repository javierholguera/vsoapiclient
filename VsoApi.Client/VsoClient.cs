
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
            WorkitemResources = new WorkitemResource(client);
            WqilResources = new WqilResource(client);
        }

        public IWorkitemResource WorkitemResources { get; set; }
        public IWqilResource WqilResources { get; set; }
    }
}
