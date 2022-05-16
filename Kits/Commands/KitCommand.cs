// -----------------------------------------------------------------------
// <copyright file="KitCommand.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using CommandSystem;
    using Exiled.API.Features;
    using Kits.Models;

    /// <inheritdoc />
    public class KitCommand : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "givekit";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "kit" };

        /// <inheritdoc />
        public string Description { get; set; } = "Give yourself a kit.";

        /// <summary>
        /// Gets or sets the response to send the player when the round is not in progress.
        /// </summary>
        [Description("The response to send the player when the round is not in progress.")]
        public string RoundNotOngoingResponse { get; set; } = "Kits cannot be given while the round is not in progress.";

        /// <summary>
        /// Gets or sets the response to send the player when no kit or an unavailable kit is specified.
        /// </summary>
        [Description("The response to send the player when no kit or an unavailable kit is specified.")]
        public string SpecifyKitResponse { get; set; } = "Please specify an available kit. Available kits: {0}";

        /// <summary>
        /// Gets or sets the characters that split the kit names in the {0} argument in the <see cref="SpecifyKitResponse"/>.
        /// </summary>
        [Description("The characters that split the kit names in the {0} argument in the SpecifyKitResponse.")]
        public string AvailableKitsSeparator { get; set; } = ", ";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Player.Get(sender) is not Player player)
            {
                response = "This command may not be used from the server console.";
                return false;
            }

            if (!Round.IsStarted)
            {
                response = RoundNotOngoingResponse;
                return false;
            }

            IEnumerable<Kit> allowedKits = Plugin.Instance.Config.Kits.Where(kit => kit.CanBeUsed(player));
            if (arguments.Count == 0)
            {
                response = string.Format(SpecifyKitResponse, string.Join(AvailableKitsSeparator, allowedKits));
                return false;
            }

            Kit selectedKit = allowedKits.FirstOrDefault(kit => kit.Name.Equals(arguments.At(0), System.StringComparison.OrdinalIgnoreCase));
            if (selectedKit is null)
            {
                response = string.Format(SpecifyKitResponse, string.Join(AvailableKitsSeparator, allowedKits));
                return false;
            }

            return selectedKit.Give(player, out response);
        }
    }
}
