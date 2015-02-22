namespace VsoApi.Contracts.Models
{
    using Newtonsoft.Json;

    public class Address
    {
        [JsonProperty]
        public string Href { get; private set; }
    }
}