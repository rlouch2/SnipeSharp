namespace SnipeSharp.Models
{
    // TODO: deserialization
    public sealed class LicenseSeat: IApiObject<LicenseSeat>
    {
        public int Id { get; }
        public IApiObject<License> LicenseId { get; }
        public string Name { get; }
        public StubLicenseSeatUser? AssignedUser { get; }
        public Stub<Asset>? AssignedAsset { get; }
        public Stub<Location>? Location { get; }
        public bool IsReassignable { get; }
        public bool CanUserCheckout { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool CheckOut { get; }
            public bool CheckIn { get; }
            public bool Clone { get; }
            public bool Update { get; }
            public bool Delete { get; }
        }
    }

    // TODO: deserialization
    public sealed class StubLicenseSeatUser: IApiObject<User>
    {
        public int Id { get; }
        public string Name { get; }
        public Stub<Department> Department { get; }
    }
}
