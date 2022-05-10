using Archipelago.Definitions;

namespace Archipelago
{
    public class ItemData
    {
        public ItemData(int code, string name, ItemType type)
        {
            Code = code;
            Name = name;
            Type = type;
        }

        public ItemType Type { get; }
        public int      Code { get; }
        public string   Name { get; }
    }
}
