using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.UserSerializer))]
    public sealed class User: IApiObject<User>
    {
        public int Id { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public string? EmployeeNumber { get; }
        public string EmailAddress { get; }
        public string Notes { get; }

        public bool IsActivated { get; }
        public bool IsImportedFromLDAP { get; }
        public bool IsTwoFactorActivated { get; }
        public bool IsTwoFactorEnrolled { get; }
        public int AssetsCount { get; }
        public int LicensesCount { get; }
        public int AccessoriesCount { get; }
        public int ConsumablesCount { get; }

        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public FormattedDateTime? LastLogin { get; }
        public FormattedDateTime? DeletedAt { get; }
        public bool IsDeleted => null != DeletedAt;

        public User.Actions AvailableActions { get; }
        public PermissionSet Permissions { get; }

        public Stub<User>? Manager { get; }
        public string? JobTitle { get; }
        public string? PhoneNumber { get; }
        public string? Website { get; }
        public string? Address { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
        public string? ZipCode { get; }
        public Stub<Department>? Department { get; }
        public Stub<Location>? Location { get; }
        public Stub<Company>? Company { get; }
        public DataTable<Stub<Group>>? Groups { get; }

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
            public bool Clone { get; }
            public bool Restore { get; }

            internal Actions(Serialization.PartialUser.Actions partial)
                => (Update, Delete, Clone, Restore) = partial;

            public override string ToString()
            {
                var joiner = new StringJoiner("{", ",", "}");
                if(Clone)
                    joiner.Append(nameof(Clone));
                if(Delete)
                    joiner.Append(nameof(Delete));
                if(Restore)
                    joiner.Append(nameof(Delete));
                if(Update)
                    joiner.Append(nameof(Delete));
                return joiner.ToString();
            }
        }

        internal User(Serialization.PartialUser partial)
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
            PhoneNumber = partial.Phone;
            State = partial.State;
            Website = partial.Website;
            ZipCode = partial.ZipCode;

            IsActivated = partial.IsActivated ?? false;
            IsImportedFromLDAP = partial.IsImportedFromLDAP ?? false;
            IsTwoFactorActivated = partial.IsTwoFactorActivated ?? false;
            IsTwoFactorEnrolled = partial.IsTwoFactorEnrolled ?? false;
            AssetsCount = partial.AssetsCount ?? 0;
            LicensesCount = partial.LicensesCount ?? 0;
            AccessoriesCount = partial.AccessoriesCount ?? 0;
            ConsumablesCount = partial.ConsumablesCount ?? 0;
        }
    }

    public sealed class UserFilter: IFilter<User>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public UserSortOn? SortOn { get; set; }

        public bool? Deleted { get; set; }
        public IApiObject<Company>? Company { get; set; }
        public IApiObject<Location>? Location { get; set; }
        public string? EmailAddress { get; set; }
        public string? Username { get; set; }
        public IApiObject<Group>? Group { get; set; }
        public IApiObject<Department>? Department { get; set; }

        IFilter<User> IFilter<User>.Clone()
            => new UserFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn,
                Deleted = Deleted,
                Company = Company,
                Location = Location,
                EmailAddress = EmailAddress,
                Username = Username,
                Group = Group,
                Department = Department
            };

        IReadOnlyDictionary<string, string?> IFilter<User>.GetParameters()
        {
            var dict = new Dictionary<string, string?>();
            if(null != Limit)
                dict["limit"] = Limit.ToString();
            if(null != Offset)
                dict["offset"] = Limit.ToString();
            if(null != SearchString)
                dict["search"] = SearchString;
            var order = SortOrder.Serialize();
            if(null != order)
                dict["order"] = order;
            var column = SortOn.Serialize();
            if(null != column)
                dict["sort"] = column;
            if(null != Deleted)
                dict["deleted"] = (bool)Deleted ? "true" : "false";
            if(null != Company)
                dict["company_id"] = Company.Id.ToString();
            if(null != Location)
                dict["location_id"] = Location.Id.ToString();
            if(null != EmailAddress)
                dict["email"] = EmailAddress;
            if(null != Username)
                dict["username"] = Username;
            if(null != Group)
                dict["group_id"] = Group.Id.ToString();
            if(null != Department)
                dict["department_id"] = Department.Id.ToString();
            return dict;
        }
    }

    public enum UserSortOn
    {
        FirstName = 0,
        Accessories,
        AccessoriesCount,
        Address,
        Assets,
        AssetsCount,
        City,
        Company,
        Consumables,
        ConsumablesCount,
        Country,
        CreatedAt,
        Department,
        EmailAddress,
        EmployeeNumber,
        Groups,
        Id,
        IsActivated,
        IsImportedFromLDAP,
        IsTwoFactorEnrolled,
        IsTwoFactorOptedIn,
        JobTitle,
        LastLogin,
        LastName,
        Licenses,
        LicensesCount,
        Location,
        Manager,
        PhoneNumber,
        State,
        Username,
        ZipCode,
    }

    public static class UserSortOnExtensions
    {
        public static string? Serialize(this UserSortOn? column)
            => column switch
            {
                UserSortOn.FirstName => "first_name",
                UserSortOn.Accessories => "accessories",
                UserSortOn.AccessoriesCount => "accessories_count",
                UserSortOn.Address => "address",
                UserSortOn.Assets => "assets",
                UserSortOn.AssetsCount => "assets_count",
                UserSortOn.City => "city",
                UserSortOn.Company => "company",
                UserSortOn.Consumables => "consumables",
                UserSortOn.ConsumablesCount => "consumables_count",
                UserSortOn.Country => "country",
                UserSortOn.CreatedAt => "created_at",
                UserSortOn.Department => "department",
                UserSortOn.EmailAddress => "email",
                UserSortOn.EmployeeNumber => "employee_num",
                UserSortOn.Groups => "groups",
                UserSortOn.Id => "id",
                UserSortOn.IsActivated => "activated",
                UserSortOn.IsImportedFromLDAP => "ldap_import",
                UserSortOn.IsTwoFactorEnrolled => "two_factor_enrolled",
                UserSortOn.IsTwoFactorOptedIn => "two_factor_optin",
                UserSortOn.JobTitle => "jobtitle",
                UserSortOn.LastLogin => "last_login",
                UserSortOn.LastName => "last_name",
                UserSortOn.Licenses => "licenses",
                UserSortOn.LicensesCount => "licenses_count",
                UserSortOn.Location => "location",
                UserSortOn.Manager => "manager",
                UserSortOn.PhoneNumber => "phone",
                UserSortOn.State => "state",
                UserSortOn.Username => "username",
                UserSortOn.ZipCode => "zip",
                _ => null
            };
    }

    namespace Serialization
    {
        internal sealed class PartialUser {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName("avatar")]
            // this isn't a URI because it can be missing a protocol
            public string? Avatar { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName("first_name")]
            public string? FirstName { get; set; }

            [JsonPropertyName("last_name")]
            public string? LastName { get; set; }

            [JsonPropertyName("username")]
            public string? Username { get; set; }

            [JsonPropertyName("manager")]
            public Stub<User>? Manager { get; set; }

            [JsonPropertyName("employee_num")]
            public string? EmployeeNumber;

            [JsonPropertyName("jobtitle")]
            public string? JobTitle { get; set; }

            [JsonPropertyName("phone")]
            public string? Phone { get; set; }

            [JsonPropertyName("website")] // TODO: URL?
            public string? Website { get; set; }

            [JsonPropertyName("address")]
            public string? Address { get; set; }

            [JsonPropertyName("city")]
            public string? City { get; set; }

            [JsonPropertyName("state")]
            public string? State { get; set; }

            [JsonPropertyName("country")]
            public string? Country { get; set; }

            [JsonPropertyName("zip")]
            public string? ZipCode { get; set; }

            [JsonPropertyName("email")]
            public string? EmailAddress { get; set; }

            [JsonPropertyName(Static.Types.DEPARTMENT)]
            public Stub<Department>? Department { get; set; }

            [JsonPropertyName(Static.Types.LOCATION)]
            public Stub<Location>? Location { get; set; }

            [JsonPropertyName(Static.NOTES)]
            public string? Notes { get; set; }

            [JsonPropertyName(Static.PERMISSIONS)]
            public PermissionSet? Permissions { get; set; }

            [JsonPropertyName("activated")]
            public bool? IsActivated { get; set; }

            [JsonPropertyName("ldap_import")]
            public bool? IsImportedFromLDAP { get; set; }

            [JsonPropertyName("two_factor_activated")]
            public bool? IsTwoFactorActivated { get; set; }

            [JsonPropertyName("two_factor_enrolled")]
            public bool? IsTwoFactorEnrolled { get; set; }

            [JsonPropertyName(Static.Count.ASSETS)]
            public int? AssetsCount { get; set; }

            [JsonPropertyName(Static.Count.LICENSES)]
            public int? LicensesCount { get; set; }

            [JsonPropertyName(Static.Count.ACCESSORIES)]
            public int? AccessoriesCount { get; set; }

            [JsonPropertyName(Static.Count.CONSUMABLES)]
            public int? ConsumablesCount { get; set; }

            [JsonPropertyName(Static.Types.COMPANY)]
            public Stub<Company>? Company { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName("last_login")]
            public FormattedDateTime? LastLogin { get; set; }

            [JsonPropertyName(Static.DELETED_AT)]
            public FormattedDateTime? DeletedAt { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public PartialUser.Actions AvailableActions { get; set; }

            [JsonPropertyName("groups")]
            public DataTable<Stub<Group>>? Groups { get; set; }

            public struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }

                [JsonPropertyName(Static.Actions.CLONE)]
                public bool Clone { get; set; }

                [JsonPropertyName(Static.Actions.RESTORE)]
                public bool Restore { get; set; }

                internal void Deconstruct(out bool update, out bool delete, out bool clone, out bool restore)
                    => (update, delete, clone, restore) = (Update, Delete, Clone, Restore);
            }
        }

        internal sealed class UserSerializer : JsonConverter<User>
        {
            public override User? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialUser>(ref reader, options);
                if(null == partial)
                    return null;
                return new User(partial);
            }

            public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
