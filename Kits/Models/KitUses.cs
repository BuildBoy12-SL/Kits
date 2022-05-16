// -----------------------------------------------------------------------
// <copyright file="KitUses.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits.Models
{
    using Exiled.API.Features;

    /// <summary>
    /// Tracks a player's kit uses.
    /// </summary>
    public class KitUses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KitUses"/> class.
        /// </summary>
        /// <param name="player"><inheritdoc cref="Player"/></param>
        public KitUses(Player player)
        {
            Player = player;
            LastUsedAs = player.Role.Type;
            Uses = 1;
        }

        /// <summary>
        /// Gets the tracked <see cref="Player"/>.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets or sets the <see cref="RoleType"/> the <see cref="Player"/> was the last time they used the kit.
        /// </summary>
        public RoleType LastUsedAs { get; set; }

        /// <summary>
        /// Gets or sets the amount of times that the <see cref="Player"/> has used the kit.
        /// </summary>
        public int Uses { get; set; }
    }
}