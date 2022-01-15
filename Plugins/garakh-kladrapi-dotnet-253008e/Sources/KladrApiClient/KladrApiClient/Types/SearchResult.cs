namespace KladrApiClient.Types
{
    /// <summary>
    /// Result of the search.
    /// </summary>
    public sealed class SearchResult : SearchParent
    {
        /// <summary>
        /// Gets or sets the parents of result.
        /// </summary>
        /// <value>
        /// The parents.
        /// </value>
        public SearchParent[] parents { get; set; }
    }
}
