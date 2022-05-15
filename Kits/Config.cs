using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace Kits
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string KitSafePermission { get; set; } = "kits.safe";
        public string KitEuclidPermission { get; set; } = "kits.euclid";
        public string KitKetterPermission { get; set; } = "kits.ketter";
        public string KitApollyonPermission { get; set; } = "kits.apollyon";
        
        public List<ItemType> KitSafe { get; set; } = new List<ItemType>()
        {
        };

        public List<ItemType> KitEuclid { get; set; } = new List<ItemType>()
        {
        };

        public List<ItemType> KitKetter { get; set; } = new List<ItemType>()
        {
        };
        public List<ItemType> KitApollyon { get; set; } = new List<ItemType>()
        {
        };
    }
}