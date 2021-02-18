namespace FleetManagement.Vehicles
{
    public class Owner
    {
        public Owner(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}