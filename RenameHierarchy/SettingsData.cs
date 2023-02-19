﻿// <copyright file="SettingsData.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>
// <auto-generated />

namespace PublicDomain
{
    // Directives
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Urlister settings.
    /// </summary>
    public class SettingsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PublicDomain.SettingsData"/> class.
        /// </summary>
        public SettingsData()
        {
            // Parameterless constructor
        }

        /// <summary>
        /// Gets or sets the length of the name.
        /// </summary>
        /// <value>The length of the name.</value>
        public int NameLength { get; set; } = 5;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> enable undo.
        /// </summary>
        /// <value><c>true</c> if enable undo; otherwise, <c>false</c>.</value>
        public bool EnableUndo { get; set; } = true;
    }
}