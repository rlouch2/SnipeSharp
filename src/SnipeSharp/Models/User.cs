using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(UserConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class User: IApiObject<User>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.User.AVATAR)]
        public string FirstName { get; }

        [DeserializeAs(Static.User.LAST_NAME)]
        public string LastName { get; }

        [DeserializeAs(Static.USERNAME)]
        public string Username { get; }

        [DeserializeAs(Static.User.EMPLOYEE_NUMBER)]
        public string? EmployeeNumber { get; }

        [DeserializeAs(Static.User.EMAIL)]
        public string EmailAddress { get; }

        [DeserializeAs(Static.NOTES)]
        public string Notes { get; }

        [DeserializeAs(Static.User.ACTIVATED, IsNonNullable = true)]
        public bool IsActivated { get; }

        [DeserializeAs(Static.User.LDAP_IMPORT, IsNonNullable = true)]
        public bool IsImportedFromLDAP { get; }

        [DeserializeAs(Static.User.TWO_FACTOR_ENROLLED, IsNonNullable = true)]
        public bool IsTwoFactorActivated { get; }

        [DeserializeAs(Static.User.TWO_FACTOR_ACTIVATED, IsNonNullable = true)]
        public bool IsTwoFactorEnrolled { get; }

        [DeserializeAs(Static.Count.ASSETS, IsNonNullable = true)]
        public int AssetsCount { get; }

        [DeserializeAs(Static.Count.LICENSES, IsNonNullable = true)]
        public int LicensesCount { get; }

        [DeserializeAs(Static.Count.ACCESSORIES, IsNonNullable = true)]
        public int AccessoriesCount { get; }

        [DeserializeAs(Static.Count.CONSUMABLES, IsNonNullable = true)]
        public int ConsumablesCount { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.User.LAST_LOGIN)]
        public FormattedDateTime? LastLogin { get; }

        [DeserializeAs(Static.DELETED_AT)]
        public FormattedDateTime? DeletedAt { get; }
        public bool IsDeleted => null != DeletedAt;

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialUser.Actions), IsNonNullable = true)]
        public Actions AvailableActions { get; }

        [DeserializeAs(Static.PERMISSIONS)]
        public PermissionSet Permissions { get; }

        [DeserializeAs(Static.MANAGER)]
        public Stub<User>? Manager { get; }

        [DeserializeAs(Static.User.TITLE)]
        public string? JobTitle { get; }

        [DeserializeAs(Static.User.PHONE)]
        public string? PhoneNumber { get; }

        [DeserializeAs(Static.User.WEBSITE)]
        public string? Website { get; }

        [DeserializeAs(Static.Location.ADDRESS)]
        public string? Address { get; }

        [DeserializeAs(Static.Location.CITY)]
        public string? City { get; }

        [DeserializeAs(Static.Location.STATE)]
        public string? State { get; }

        [DeserializeAs(Static.Location.COUNTRY)]
        public string? Country { get; }

        [DeserializeAs(Static.Location.ZIP)]
        public string? ZipCode { get; }

        [DeserializeAs(Static.Types.DEPARTMENT)]
        public Stub<Department>? Department { get; }

        [DeserializeAs(Static.Types.LOCATION)]
        public Stub<Location>? Location { get; }

        [DeserializeAs(Static.Types.COMPANY)]
        public Stub<Company>? Company { get; }

        [DeserializeAs(Static.Types.GROUP)]
        public DataTable<Stub<Group>>? Groups { get; }

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
            public bool Clone { get; }
            public bool Restore { get; }
        }

        internal User(PartialUser partial)
        {
            Id = partial.Id ?? throw new MissingRequiredPropertyException(nameof(Id), nameof(User));
            Name = partial.Name ?? throw new MissingRequiredPropertyException(nameof(Name), nameof(User));
            FirstName = partial.FirstName ?? throw new MissingRequiredPropertyException(nameof(FirstName), nameof(User));
            LastName = partial.LastName ?? throw new MissingRequiredPropertyException(nameof(LastName), nameof(User));
            Username = partial.Username ?? throw new MissingRequiredPropertyException(nameof(Username), nameof(User));
            EmailAddress = partial.EmailAddress ?? throw new MissingRequiredPropertyException(nameof(EmailAddress), nameof(User));
            Notes = partial.Notes ?? string.Empty;
            Permissions = partial.Permissions ?? new PermissionSet();
            AvailableActions = new User.Actions(partial.AvailableActions);

            CreatedAt = partial.CreatedAt ?? throw new MissingRequiredPropertyException(nameof(CreatedAt), nameof(User));
            UpdatedAt = partial.UpdatedAt ?? throw new MissingRequiredPropertyException(nameof(UpdatedAt), nameof(User));
            LastLogin = partial.LastLogin;
            DeletedAt = partial.DeletedAt;

            Company = partial.Company;
            Department = partial.Department;
            Location = partial.Location;
            Manager = partial.Manager;
            Groups = partial.Groups;

            Address = partial.Address;
            City = partial.City;
            Country = partial.Country;
            EmployeeNumber = partial.EmployeeNumber;
            JobTitle = partial.JobTitle;
            PhoneNumber = partial.PhoneNumber;
            State = partial.State;
            Website = partial.Website;
            ZipCode = partial.ZipCode;

            IsActivated = partial.IsActivated;
            IsImportedFromLDAP = partial.IsImportedFromLDAP;
            IsTwoFactorActivated = partial.IsTwoFactorActivated;
            IsTwoFactorEnrolled = partial.IsTwoFactorEnrolled;
            AssetsCount = partial.AssetsCount;
            LicensesCount = partial.LicensesCount;
            AccessoriesCount = partial.AccessoriesCount;
            ConsumablesCount = partial.ConsumablesCount;
        }
    }

    [GenerateFilter(typeof(UserSortOn))]
    public sealed partial class UserFilter: IFilter<User>
    {
        [SerializeAsString("deleted")]
        public bool? Deleted { get; set; }

        [SerializeAsString(Static.Id.COMPANY)]
        public IApiObject<Company>? Company { get; set; }

        [SerializeAsString(Static.Id.LOCATION)]
        public IApiObject<Location>? Location { get; set; }

        [SerializeAsString(Static.User.EMAIL)]
        public string? EmailAddress { get; set; }

        [SerializeAsString(Static.USERNAME)]
        public string? Username { get; set; }

        [SerializeAsString(Static.Id.GROUP)]
        public IApiObject<Group>? Group { get; set; }

        [SerializeAsString(Static.Id.DEPARTMENT)]
        public IApiObject<Department>? Department { get; set; }
    }

    [SortColumn]
    public enum UserSortOn
    {
        [EnumMember(Value = Static.User.FIRST_NAME)]
        FirstName = 0,

        [EnumMember(Value = "accessories")]
        Accessories,

        [EnumMember(Value = Static.Count.ACCESSORIES)]
        AccessoriesCount,

        [EnumMember(Value = Static.Location.ADDRESS)]
        Address,

        [EnumMember(Value = "assets")]
        Assets,

        [EnumMember(Value = Static.Count.ASSETS)]
        AssetsCount,

        [EnumMember(Value = Static.Location.CITY)]
        City,

        [EnumMember(Value = Static.Types.COMPANY)]
        Company,

        [EnumMember(Value = "consumables")]
        Consumables,

        [EnumMember(Value = Static.Count.CONSUMABLES)]
        ConsumablesCount,

        [EnumMember(Value = Static.Location.COUNTRY)]
        Country,

        [EnumMember(Value = Static.CREATED_AT)]
        CreatedAt,

        [EnumMember(Value = Static.Types.DEPARTMENT)]
        Department,

        [EnumMember(Value = Static.User.EMAIL)]
        EmailAddress,

        [EnumMember(Value = Static.User.EMPLOYEE_NUMBER)]
        EmployeeNumber,

        [EnumMember(Value = "groups")]
        Groups,

        [EnumMember(Value = Static.ID)]
        Id,

        [EnumMember(Value = Static.User.ACTIVATED)]
        IsActivated,

        [EnumMember(Value = Static.User.LDAP_IMPORT)]
        IsImportedFromLDAP,

        [EnumMember(Value = Static.User.TWO_FACTOR_ENROLLED)]
        IsTwoFactorEnrolled,

        [EnumMember(Value = "two_factor_optin")]
        IsTwoFactorOptedIn,

        [EnumMember(Value = Static.User.TITLE)]
        JobTitle,

        [EnumMember(Value = Static.User.LAST_LOGIN)]
        LastLogin,

        [EnumMember(Value = Static.User.LAST_NAME)]
        LastName,

        [EnumMember(Value = "licenses")]
        Licenses,

        [EnumMember(Value = Static.Count.LICENSES)]
        LicensesCount,

        [EnumMember(Value = Static.Types.LOCATION)]
        Location,

        [EnumMember(Value = Static.MANAGER)]
        Manager,

        [EnumMember(Value = Static.User.PHONE)]
        PhoneNumber,

        [EnumMember(Value = Static.Location.STATE)]
        State,

        [EnumMember(Value = Static.USERNAME)]
        Username,

        [EnumMember(Value = Static.Location.ZIP)]
        ZipCode,
    }
}
