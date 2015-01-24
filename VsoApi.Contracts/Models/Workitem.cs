
namespace VsoApi.Contracts.Models
{
    public class Workitem : VsoEntity
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public WorkitemFields Fields { get; set; }
        public string Url { get; set; }
    }
}
