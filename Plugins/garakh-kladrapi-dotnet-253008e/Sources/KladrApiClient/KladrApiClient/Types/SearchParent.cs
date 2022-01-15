using System;
using System.Collections.Generic;
using System.Text;
namespace KladrApiClient.Types
{
    /// <summary>
    /// Parent information.
    /// </summary>
    public class SearchParent
    {
        /// <summary>
        /// Gets or sets the parent id.
        /// </summary>
        /// <value>
        /// The parent id.
        /// </value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        public string zip { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }

        /// <summary>
        /// Gets or sets the short type.
        /// </summary>
        /// <value>
        /// The short type.
        /// </value>
        public string typeShort { get; set; }
    }
}
