using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace RenameHierarchy
{
    public class RenameData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        /// <value>The directory path.</value>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the rename dictionary.
        /// </summary>
        /// <value>The rename dictionary.</value>
        public Dictionary<string, string> RenameDictionary { get; set; }

        /// <summary>
        /// Gets or sets the rename date time.
        /// </summary>
        /// <value>The rename date time.</value>
        public DateTime RenameDateTime { get; set; }
    }
}