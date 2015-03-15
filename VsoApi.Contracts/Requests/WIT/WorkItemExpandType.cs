namespace VsoApi.Contracts.Requests.WIT
{
    public enum WorkItemExpandType
    {
        /// <summary>
        /// Gets no info about relations
        /// </summary>
        None,

        /// <summary>
        /// Gets information about work item links only.
        /// </summary>
        Relations,

        /// <summary>
        /// Gets work item relationships (work item links, hyperlinks, file attachements, etc.).
        /// </summary>
        All,
    }
}