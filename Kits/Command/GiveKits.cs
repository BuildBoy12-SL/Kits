using System;
using Exiled.API.Features;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace Kits.Command
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class KitSafe : ICommand
    {
        public string Command => "kitsafe";
        public string[] Aliases => null;
        public string Description => "Give Yourself a Kit Safe (Only if you have perms)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(MainClass.singleton.Config.KitSafePermission))
            {
                response = "You dont have perms to execute this command";
                return false;
            }
            Player p = Player.Get(sender);

            if (!Round.IsStarted)
            {
                response = "You cant execute the command (The round is not started)";
                return false;
            }

            if (!MainClass.singleton.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (MainClass.singleton.Config.RestrictedRolesForKits.Contains(p.Role.Type))
            {
                response = "You can't use kits with this role, this role is restricted in the config";
                return false;
            }

            p.AddItem(MainClass.singleton.Config.KitSafe);
            MainClass.singleton.OneTimePerRound = false;

            response = "Done!";
            return true;
        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class KitEuclid : ICommand
    {
        public string Command => "kiteuclid";
        public string[] Aliases => null;
        public string Description => "Give Yourself a Kit Euclid (Only if you have perms)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(MainClass.singleton.Config.KitEuclidPermission))
            {
                response = "You dont have perms to execute this command";
                return false;
            }
            Player p = Player.Get(sender);

            if (!Round.IsStarted)
            {
                response = "You cant execute the command (The round is not started)";
                return false;
            }

            if (!MainClass.singleton.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (MainClass.singleton.Config.RestrictedRolesForKits.Contains(p.Role.Type))
            {
                response = "You can't use kits with this role, this role is restricted in the config";
                return false;
            }

            p.AddItem(MainClass.singleton.Config.KitEuclid);
            MainClass.singleton.OneTimePerRound = false;

            response = "Done!";
            return true;
        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class KitKetter : ICommand
    {
        public string Command => "kitketter";
        public string[] Aliases => null;
        public string Description => "Give Yourself a Kit Ketter (Only if you have perms)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(MainClass.singleton.Config.KitKetterPermission))
            {
                response = "You dont have perms to execute this command";
                return false;
            }
            Player p = Player.Get(sender);

            if (!Round.IsStarted)
            {
                response = "You cant execute the command (The round is not started)";
                return false;
            }

            if (!MainClass.singleton.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (MainClass.singleton.Config.RestrictedRolesForKits.Contains(p.Role.Type))
            {
                response = "You can't use kits with this role, this role is restricted in the config";
                return false;
            }

            p.AddItem(MainClass.singleton.Config.KitKetter);
            MainClass.singleton.OneTimePerRound = false;

            response = "Done!";
            return true;
        }
    }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class KitApollyon : ICommand
    {
        public string Command => "kitapollyon";
        public string[] Aliases => null;
        public string Description => "Give Yourself a Kit Apollyon (Only if you have perms)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(MainClass.singleton.Config.KitApollyonPermission))
            {
                response = "You dont have perms to execute this command";
                return false;
            }
            Player p = Player.Get(sender);

            if (!Round.IsStarted)
            {
                response = "You cant execute the command (The round is not started)";
                return false;
            }

            if (!MainClass.singleton.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (MainClass.singleton.Config.RestrictedRolesForKits.Contains(p.Role.Type))
            {
                response = "You can't use kits with this role, this role is restricted in the config";
                return false;
            }

            p.AddItem(MainClass.singleton.Config.KitApollyon);
            MainClass.singleton.OneTimePerRound = false;

            response = "Done!";
            return true;
        }
    }
}
