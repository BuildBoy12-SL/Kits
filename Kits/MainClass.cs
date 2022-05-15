using System;
using Exiled.API.Features;
using ServerHandler = Exiled.Events.Handlers.Server;

namespace Kits
{
    public class MainClass : Plugin<Config>
    {
        public static MainClass singleton;

        public override string Author { get; } = "xNexus-ACS";
        public override string Name { get; } = "Kits";
        public override string Prefix { get; } = "kits";
        public override Version Version { get; } = new Version(0, 4, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 1);

        private EventHandlers ev;
        public bool OneTimePerRound = true;

        public override void OnEnabled()
        {
            singleton = this;
            ev = new EventHandlers();

            ServerHandler.RestartingRound += ev.OnRestartingRound;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerHandler.RestartingRound -= ev.OnRestartingRound;

            ev = null;
            singleton = null;
            base.OnDisabled();
        }
    }
}