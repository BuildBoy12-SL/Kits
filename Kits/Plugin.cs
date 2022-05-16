// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="xNexus-ACS">
// Copyright (c) xNexus-ACS. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Kits
{
    using System;
    using Exiled.API.Features;
    using RemoteAdmin;
    using ServerHandler = Exiled.Events.Handlers.Server;

    /// <inheritdoc />
    public class Plugin : Plugin<Config, Translation>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override string Author => "xNexus-ACS & Build";

        /// <inheritdoc />
        public override string Name => "Kits";

        /// <inheritdoc />
        public override string Prefix => "kits";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new(5, 2, 1);

        /// <inheritdoc />
        public override Version Version { get; } = new(1, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(this);
            ServerHandler.RestartingRound += eventHandlers.OnRestartingRound;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandler.RestartingRound -= eventHandlers.OnRestartingRound;
            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }

        /// <inheritdoc />
        public override void OnRegisteringCommands()
        {
            QueryProcessor.DotCommandHandler.RegisterCommand(Translation.KitCommand);
        }

        /// <inheritdoc />
        public override void OnUnregisteringCommands()
        {
            QueryProcessor.DotCommandHandler.UnregisterCommand(Translation.KitCommand);
        }
    }
}