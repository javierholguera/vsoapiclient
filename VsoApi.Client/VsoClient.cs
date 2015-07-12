
namespace VsoApi.Client
{
    using System;
    using RestSharp;
    using VsoApi.Client.Resources.Git;
    using VsoApi.Client.Resources.Teams;
    using VsoApi.Client.Resources.WIT;

    public class VsoClient
    {
        public VsoClient() : this(
            new Uri("https://javierholguera.visualstudio.com/defaultCollection"),
            "javierh", "1Vso#client1",
            "javierh", "1Vso#client1")
        {
        }

        public VsoClient(Uri url, string user, string password)
            : this(url, user, password, user, password)
        {
        }

        public VsoClient(Uri url, string user, string password, string capacityUser, string capacityPassword)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (user == null)
                throw new ArgumentNullException("user");
            if (password == null)
                throw new ArgumentNullException("password");

            var client = new RestClient(url) {
                Authenticator = new HttpBasicAuthenticator(user, password)
            };

            WorkItemResources = new WorkItemResource(client);
            WorkItemTypeResources = new WorkItemTypeResource(client);
            WiqlResources = new WiqlResource(client);
            FieldResources = new FieldResource(client);
            ClassificationNodeResources = new ClassificationNodeResource(client);

            PullRequestResources = new PullRequestResource(client);
            RepositoryResources = new RepositoryResource(client);

            TeamResources = new TeamResource(client);
            MemberResources = new MemberResource(client);

            // TODO: Exception until Microsoft implements its own REST API endpoint for team capacity
            var alternativeClient = new RestClient(new Uri("http://vsoclient.azurewebsites.net")) {
                Authenticator = new HttpBasicAuthenticator(capacityUser, capacityPassword)
            };
            CapacityResources = new CapacityResource(alternativeClient);
        }

        public IWorkItemResource WorkItemResources { get; private set; }
        public IWorkItemTypeResource WorkItemTypeResources { get; private set; }
        public IWiqlResource WiqlResources { get; private set; }
        public IFieldResource FieldResources { get; private set; }
        public IClassificationNodeResource ClassificationNodeResources { get; private set; }
        public ICapacityResource CapacityResources { get; private set; }

        public IPullRequestResource PullRequestResources { get; private set; }
        public IRepositoryResource RepositoryResources { get; private set; }

        public ITeamResource TeamResources { get; private set; }
        public IMemberResource MemberResources { get; private set; }
    }
}
