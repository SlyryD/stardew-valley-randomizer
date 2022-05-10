using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Archipelago
{
    public class SlotData
    {
        private readonly Dictionary<string, object> _slotData;

        public SlotData(IDictionary<string, object> dictionary, string seed, int slot, string name)
        {
            _slotData = new Dictionary<string, object>(dictionary)
            {
                { "seed", seed }, { "slot", slot }, { "name", name }
            };
        }

        public string       Seed                   => (string) _slotData["seed"];
        public int          Slot                   => (int) _slotData["slot"];
        public string       Name                   => (string) _slotData["name"];
        public bool         DeathLink              => Convert.ToInt32(_slotData["death_link"]) == 1;
        public bool         UniversalChests        => Convert.ToInt32(_slotData["universal_chests"]) == 1;
        public bool         UniversalFairyChests   => Convert.ToInt32(_slotData["universal_fairy_chests"]) == 1;
    }
}
