
namespace VsoApi.Client
{
    using RestSharp;
    using VsoApi.Client.Resources;

    public class VsoClient
    {
        public VsoClient()
        {
            IRestClient client = new RestClient("https://javierholguera.visualstudio.com/defaultCollection/_apis");
            client.Authenticator = new HttpBasicAuthenticator("jholguerablanco@hotmail.com", "1Cat#nap1");
            WorkitemResources = new WorkitemResource(client);
        }

        public IWorkitemResource WorkitemResources { get; set; }
    }
}
