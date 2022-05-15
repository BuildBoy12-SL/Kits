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
            if (!sender.CheckPermission("kits.safe"))
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

            if (!Checker.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (p.Role.Type != RoleType.NtfCaptain && p.Role.Type != RoleType.NtfPrivate &&
                p.Role.Type != RoleType.NtfSergeant && p.Role.Type != RoleType.NtfSpecialist)
            {
                response = "You aren't a NTF";
                return false;
            }

            p.AddItem(Kits.KitSafe);
            Checker.OneTimePerRound = false;

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
            if (!sender.CheckPermission("kits.euclid"))
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

            if (!Checker.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (p.Role.Type != RoleType.NtfCaptain && p.Role.Type != RoleType.NtfPrivate &&
                p.Role.Type != RoleType.NtfSergeant && p.Role.Type != RoleType.NtfSpecialist)
            {
                response = "You aren't a NTF";
                return false;
            }

            p.AddItem(Kits.KitEuclid);
            Checker.OneTimePerRound = false;

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
            if (!sender.CheckPermission("kits.ketter"))
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

            if (!Checker.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (p.Role.Type != RoleType.NtfCaptain && p.Role.Type != RoleType.NtfPrivate &&
                p.Role.Type != RoleType.NtfSergeant && p.Role.Type != RoleType.NtfSpecialist)
            {
                response = "You aren't a NTF";
                return false;
            }

            p.AddItem(Kits.KitKetter);
            Checker.OneTimePerRound = false;

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
            if (!sender.CheckPermission("kits.apollyon"))
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

            if (!Checker.OneTimePerRound)
            {
                response = "You used the kit, you cant use it again this round";
                return false;
            }

            if (p.Role.Type != RoleType.NtfCaptain && p.Role.Type != RoleType.NtfPrivate &&
                p.Role.Type != RoleType.NtfSergeant && p.Role.Type != RoleType.NtfSpecialist)
            {
                response = "You aren't a NTF";
                return false;
            }

            p.AddItem(Kits.KitApollyon);
            Checker.OneTimePerRound = false;

            response = "Done!";
            return true;
        }
    }
}
