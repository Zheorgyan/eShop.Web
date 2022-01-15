namespace KladrApiClient
{
    using System;
    using Types;

    /// <summary>
    /// Class that returns the data from Kladr API.
    /// </summary>
    public sealed class KladrResponse
    {
        /// <summary>
        /// Search Context Info.
        /// </summary>
        public SearchContext searchContext { get;set;}

        /// <summary>
        /// Gets or sets the search results.
        /// </summary>
        /// <value>
        /// The search results.
        /// </value>
        public SearchResult[] result { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Exception Error { get; set; }

        /// <summary>
        /// Gets or sets the info message.
        /// </summary>
        /// <value>
        /// The info message.
        /// </value>
        public string InfoMessage { get; set; }

    }
}
