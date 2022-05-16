// -----------------------------------------------------------------------
// <copyright file="Kit.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Exiled.Permissions.Extensions;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Represents a kit to be given to a player.
    /// </summary>
    public class Kit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Kit"/> class.
        /// </summary>
        public Kit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Kit"/> class.
        /// </summary>
        /// <param name="name"><inheritdoc cref="Name"/></param>
        /// <param name="requiredPermission"><inheritdoc cref="RequiredPermission"/></param>
        /// <param name="items"><inheritdoc cref="Items"/></param>
        /// <param name="restrictedRoles"><inheritdoc cref="RestrictedRoles"/></param>
        public Kit(string name, string requiredPermission, List<ItemType> items = null, List<RoleType> restrictedRoles = null)
        {
            Name = name;
            RequiredPermission = requiredPermission;
            MaximumUses = 1;
            OncePerSpawn = true;
            Items = items;
            RestrictedRoles = restrictedRoles;
        }

        /// <summary>
        /// Gets all the uses of this kit.
        /// </summary>
        [YamlIgnore]
        public List<KitUses> Uses { get; } = new();

        /// <summary>
        /// Gets or sets the name of the kit.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission required to use the kit.
        /// </summary>
        public string RequiredPermission { get; set; }

        /// <summary>
        /// Gets or sets how many times this kit can be used in a round.
        /// </summary>
        public int MaximumUses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this kit can only be reused after the player respawns as another valid role.
        /// </summary>
        public bool OncePerSpawn { get; set; }

        /// <summary>
        /// Gets or sets the items to give.
        /// </summary>
        public List<ItemType> Items { get; set; }

        /// <summary>
        /// Gets or sets the roles that are blacklisted from using the kit.
        /// </summary>
        public List<RoleType> RestrictedRoles { get; set; }

        /// <summary>
        /// Checks whether a given <see cref="Player"/> can use this kit.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to check.</param>
        /// <returns>Whether the player should be allowed to use this kit.</returns>
        public bool CanBeUsed(Player player)
        {
            return player.CheckPermission(RequiredPermission) && (RestrictedRoles is null || !RestrictedRoles.Contains(player.Role.Type))
                                                              && (Uses.FirstOrDefault(uses => uses.Player == player) is not KitUses kitUses ||
                                                                  (kitUses.Uses < MaximumUses && (!OncePerSpawn || kitUses.LastUsedAs != player.Role.Type)));
        }

        /// <summary>
        /// Gives the player the kit.
        /// </summary>
        /// <param name="player">The player to give the kit.</param>
        /// <param name="response">The response to send to the player.</param>
        /// <returns>Whether the kit was successfully given.</returns>
        public bool Give(Player player, out string response)
        {
            if (Items is null)
            {
                response = Plugin.Instance.Translation.NoItems;
                return false;
            }

            foreach (ItemType item in Items)
            {
                if (player.Items.Count >= 8)
                {
                    Item.Create(item)?.Spawn(player.Position);
                    continue;
                }

                player.AddItem(item);
            }

            UpsertUse(player);
            response = string.Format(Plugin.Instance.Translation.GaveKit, Name);
            return true;
        }

        /// <inheritdoc />
        public override string ToString() => Name;

        private void UpsertUse(Player player)
        {
            if (Uses.FirstOrDefault(uses => uses.Player == player) is KitUses kitUses)
            {
                kitUses.LastUsedAs = player.Role.Type;
                kitUses.Uses++;
                return;
            }

            Uses.Add(new KitUses(player));
        }
    }
}