namespace KladrApiClient.Types
{
    /// <summary>
    /// Search Context of the query.
    /// </summary>
    public sealed class SearchContext
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public string query { get; set; }

        /// <summary>
        /// Gets or sets the type of the content to search (region, district, city, street, building). 
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string contentType { get; set; }

        /// <summary>
        /// Gets or sets should include parents in results.
        /// </summary>
        /// <value>
        /// Should include parents in results.
        /// </value>
        public int withParent { get; set; }

        /// <summary>
        /// Gets or sets the count of returned objects.
        /// </summary>
        /// <value>
        /// The  count of returned objects.
        /// </value>
        public int limit { get; set; }
    }
}
