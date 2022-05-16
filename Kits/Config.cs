// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using Kits.Models;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the kits that are available.
        /// </summary>
        [Description("The kits that are available.")]
        public List<Kit> Kits { get; set; } = new()
        {
            new("Safe", "kits.safe"),
            new("Euclid", "kits.euclid"),
            new("Keter", "kits.keter"),
            new("Apollyon", "kits.apollyon"),
        };
    }
}