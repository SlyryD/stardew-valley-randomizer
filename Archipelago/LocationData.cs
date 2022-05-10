namespace Archipelago
{
    public class LocationData
    {
        public LocationData(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public int    Code { get; }
        public string Name { get; }
    }
}
