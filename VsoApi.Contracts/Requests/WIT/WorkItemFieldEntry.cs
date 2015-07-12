namespace VsoApi.Contracts.Requests.WIT
{
    using VsoApi.Contracts.Models;

    public class FieldEntry
    {
        /// <summary>
        /// For serialization, etc.
        /// </summary>
        public FieldEntry() { }

        public FieldEntry(string op, string path, string value)
        {
            Op = op;
            Path = path;
            Value = value;
        }

        public FieldEntry(string op, string path, WorkItemRelation relation)
        {
            Op = op;
            Path = path;
            Value = relation;
        }

        public string Op { get; set; }
        public string Path { get; set; }
        public object Value { get; set; }
    }

}