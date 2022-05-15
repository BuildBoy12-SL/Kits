using System.Collections.Generic;

namespace Kits
{
    public static class Kits
    {
        public static List<ItemType> KitSafe { get; set; } = new List<ItemType>()
        {
            ItemType.ArmorCombat,
            ItemType.Coin,
            ItemType.Painkillers
        };

        public static List<ItemType> KitEuclid { get; set; } = new List<ItemType>()
        {
            ItemType.ArmorCombat,
            ItemType.Medkit,
            ItemType.Radio,
            ItemType.Coin
        };

        public static List<ItemType> KitKetter { get; set; } = new List<ItemType>()
        {
            ItemType.ArmorCombat,
            ItemType.Medkit,
            ItemType.SCP244b,
            ItemType.Radio,
        };
        public static List<ItemType> KitApollyon { get; set; } = new List<ItemType>()
        {
            ItemType.ArmorCombat,
            ItemType.Medkit,
            ItemType.SCP244b,
            ItemType.Radio,
            ItemType.SCP268
        };
    }

    public static class Checker
    {
        public static bool OneTimePerRound = true;
    }
}
