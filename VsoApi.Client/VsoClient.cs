
namespace VsoApi.Client
{
    using RestSharp;
    using VsoApi.Client.Resources;

    public class VsoClient
    {
        public VsoClient()
        {
            RestClient client = new RestClient("https://javierholguera.visualstudio.com/defaultCollection/");
            client.Authenticator = new HttpBasicAuthenticator("jholguerablanco@hotmail.com", "1Cat#nap1");
            WorkitemResources = new WorkitemResource(client);
        }

        public IWorkitemResource WorkitemResources { get; set; }
    }
}
