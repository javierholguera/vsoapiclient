namespace VsoApi.Contracts.Responses
{
    public class NotFoundErrorResponse
    {
        public int ErrorCode { get; set; }
        public int EventId { get; set; }
        public string InnerException { get; set; }
        public string Message { get; set; }
        public string TypeKey { get; set; }
        public string TypeName { get; set; }
    }
}