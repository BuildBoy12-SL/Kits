// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using Kits.Commands;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets the response to send a player when the selected kit lacks configured items.
        /// </summary>
        [Description("The response to send a player when the selected kit lacks configured items.")]
        public string NoItems { get; set; } = "This kit contains no items.";

        /// <summary>
        /// Gets or sets the response to send a player when giving the kit.
        /// </summary>
        [Description("The response to send a player when giving the kit.")]
        public string GaveKit { get; set; } = "You have been given the {0} kit.";

        /// <summary>
        /// Gets or sets the command used for players to give themselves kits.
        /// </summary>
        [Description("The command used for players to give themselves kits.")]
        public KitCommand KitCommand { get; set; } = new();
    }
}