namespace VsoApi.Contracts.Responses
{
    using System.Collections.Generic;

    public class Transition
    {
        public string To { get; set; }
        public IEnumerable<string> Actions { get; set; }
    }
}