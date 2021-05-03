using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public enum Permission
    {
        [EnumMember(Value = "admin")]
        Admin,

        [EnumMember(Value = "import")]
        Import,

        [EnumMember(Value = "reports.view")]
        ViewReports,

        [EnumMember(Value = "assets.view")]
        ViewAssets,

        [EnumMember(Value = "assets.create")]
        CreateAssets,

        [EnumMember(Value = "assets.edit")]
        EditAssets,

        [EnumMember(Value = "assets.delete")]
        DeleteAssets,

        [EnumMember(Value = "assets.checkin")]
        CheckinAssets,

        [EnumMember(Value = "assets.checkout")]
        CheckoutAssets,

        [EnumMember(Value = "assets.audit")]
        AuditAssets,

        [EnumMember(Value = "assets.view.requestable")]
        ViewRequestableAssets,

        [EnumMember(Value = "accessories.view")]
        ViewAccessories,

        [EnumMember(Value = "accessories.create")]
        CreateAccessories,

        [EnumMember(Value = "accessories.edit")]
        EditAccessories,

        [EnumMember(Value = "accessories.delete")]
        DeleteAccessories,

        [EnumMember(Value = "accessories.checkout")]
        CheckoutAccessories,

        [EnumMember(Value = "accessories.checkin")]
        CheckinAccessories,

        [EnumMember(Value = "consumables.view")]
        ViewConsumables,

        [EnumMember(Value = "consumables.create")]
        CreateConsumables,

        [EnumMember(Value = "consumables.edit")]
        EditConsumables,

        [EnumMember(Value = "consumables.delete")]
        DeleteConsumables,

        [EnumMember(Value = "consumables.checkout")]
        CheckoutConsumables,

        [EnumMember(Value = "licenses.view")]
        ViewLicenses,

        [EnumMember(Value = "licenses.create")]
        CreateLicenses,

        [EnumMember(Value = "licenses.edit")]
        EditLicenses,

        [EnumMember(Value = "licenses.delete")]
        DeleteLicenses,

        [EnumMember(Value = "licenses.checkout")]
        CheckoutLicenses,

        [EnumMember(Value = "licenses.keys")]
        KeysLicenses,

        [EnumMember(Value = "components.view")]
        ViewComponents,

        [EnumMember(Value = "components.create")]
        CreateComponents,

        [EnumMember(Value = "components.edit")]
        EditComponents,

        [EnumMember(Value = "components.delete")]
        DeleteComponents,

        [EnumMember(Value = "components.checkout")]
        CheckoutComponents,

        [EnumMember(Value = "components.checkin")]
        CheckinComponents,

        [EnumMember(Value = "kits.view")]
        ViewKits,

        [EnumMember(Value = "kits.create")]
        CreateKits,

        [EnumMember(Value = "kits.edit")]
        EditKits,

        [EnumMember(Value = "kits.delete")]
        DeleteKits,

        [EnumMember(Value = "kits.checkout")]
        CheckoutKits,

        [EnumMember(Value = "users.view")]
        ViewUsers,

        [EnumMember(Value = "users.create")]
        CreateUsers,

        [EnumMember(Value = "users.edit")]
        EditUsers,

        [EnumMember(Value = "users.delete")]
        DeleteUsers,

        [EnumMember(Value = "models.view")]
        ViewModels,

        [EnumMember(Value = "models.create")]
        CreateModels,

        [EnumMember(Value = "models.edit")]
        EditModels,

        [EnumMember(Value = "models.delete")]
        DeleteModels,

        [EnumMember(Value = "categories.view")]
        ViewCategories,

        [EnumMember(Value = "categories.create")]
        CreateCategories,

        [EnumMember(Value = "categories.edit")]
        EditCategories,

        [EnumMember(Value = "categories.delete")]
        DeleteCategories,

        [EnumMember(Value = "departments.view")]
        ViewDepartments,

        [EnumMember(Value = "departments.create")]
        CreateDepartments,

        [EnumMember(Value = "departments.edit")]
        EditDepartments,

        [EnumMember(Value = "departments.delete")]
        DeleteDepartments,

        [EnumMember(Value = "statuslabels.view")]
        ViewStatuslabels,

        [EnumMember(Value = "statuslabels.create")]
        CreateStatuslabels,

        [EnumMember(Value = "statuslabels.edit")]
        EditStatuslabels,

        [EnumMember(Value = "statuslabels.delete")]
        DeleteStatuslabels,

        [EnumMember(Value = "customfields.view")]
        ViewCustomfields,

        [EnumMember(Value = "customfields.create")]
        CreateCustomfields,

        [EnumMember(Value = "customfields.edit")]
        EditCustomfields,

        [EnumMember(Value = "customfields.delete")]
        DeleteCustomfields,

        [EnumMember(Value = "suppliers.view")]
        ViewSuppliers,

        [EnumMember(Value = "suppliers.create")]
        CreateSuppliers,

        [EnumMember(Value = "suppliers.edit")]
        EditSuppliers,

        [EnumMember(Value = "suppliers.delete")]
        DeleteSuppliers,

        [EnumMember(Value = "manufacturers.view")]
        ViewManufacturers,

        [EnumMember(Value = "manufacturers.create")]
        CreateManufacturers,

        [EnumMember(Value = "manufacturers.edit")]
        EditManufacturers,

        [EnumMember(Value = "manufacturers.delete")]
        DeleteManufacturers,

        [EnumMember(Value = "depreciations.view")]
        ViewDepreciations,

        [EnumMember(Value = "depreciations.create")]
        CreateDepreciations,

        [EnumMember(Value = "depreciations.edit")]
        EditDepreciations,

        [EnumMember(Value = "depreciations.delete")]
        DeleteDepreciations,

        [EnumMember(Value = "locations.view")]
        ViewLocations,

        [EnumMember(Value = "locations.create")]
        CreateLocations,

        [EnumMember(Value = "locations.edit")]
        EditLocations,

        [EnumMember(Value = "locations.delete")]
        DeleteLocations,

        [EnumMember(Value = "companies.view")]
        ViewCompanies,

        [EnumMember(Value = "companies.create")]
        CreateCompanies,

        [EnumMember(Value = "companies.edit")]
        EditCompanies,

        [EnumMember(Value = "companies.delete")]
        DeleteCompanies,

        [EnumMember(Value = "self.two_factor")]
        SelfTwoFactor,

        [EnumMember(Value = "self.api")]
        SelfApi,

        [EnumMember(Value = "self.edit_location")]
        SelfEditLocation,

        [EnumMember(Value = "self.checkout_assets")]
        SelfCheckoutAssets,

        [EnumMember(Value = "superuser")]
        SuperUser,

    }

    [JsonConverter(typeof(Serialization.PermissionSetConverter))]
    public sealed class PermissionSet : ISet<Permission>
    {
        private readonly ISet<Permission> _permissions;
        public readonly IReadOnlyDictionary<string, bool> Other;
        public int Count => _permissions.Count + Other.Count;
        bool ICollection<Permission>.IsReadOnly => true;

        internal PermissionSet(ISet<Permission> innerSet, IReadOnlyDictionary<string, bool> other)
            => (_permissions, Other) = (innerSet, other);
        
        internal PermissionSet(): this(new HashSet<Permission>(), new Dictionary<string,bool>())
        {
        }

        void ICollection<Permission>.Add(Permission item) => throw new NotImplementedException();
        void ICollection<Permission>.Clear() => throw new NotImplementedException();
        bool ICollection<Permission>.Remove(Permission item) => throw new NotImplementedException();
        bool ISet<Permission>.Add(Permission item) => throw new NotImplementedException();
        void ISet<Permission>.ExceptWith(IEnumerable<Permission> other) => throw new NotImplementedException();
        void ISet<Permission>.IntersectWith(IEnumerable<Permission> other) => throw new NotImplementedException();
        void ISet<Permission>.UnionWith(IEnumerable<Permission> other) => throw new NotImplementedException();
        void ISet<Permission>.SymmetricExceptWith(IEnumerable<Permission> other) => throw new NotImplementedException();

        IEnumerator<Permission> IEnumerable<Permission>.GetEnumerator()
            => _permissions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => _permissions.GetEnumerator();
        void ICollection<Permission>.CopyTo(Permission[] array, int arrayIndex)
            => _permissions.CopyTo(array, arrayIndex);

        public bool Contains(Permission item)
            => _permissions.Contains(item);

        public bool IsProperSubsetOf(IEnumerable<Permission> other)
            => _permissions.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<Permission> other)
            => _permissions.IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<Permission> other)
            => _permissions.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<Permission> other)
            => _permissions.IsSupersetOf(other);

        public bool Overlaps(IEnumerable<Permission> other)
            => _permissions.Overlaps(other);

        bool ISet<Permission>.SetEquals(IEnumerable<Permission> other)
            => _permissions.SetEquals(other);
    }

    namespace Serialization
    {
        internal sealed class PartialPermissionSet
        {
            [JsonExtensionData]
            public IDictionary<string,JsonElement> Properties { get; set; } = new Dictionary<string,JsonElement>();
        }

        internal sealed class PermissionSetConverter : JsonConverter<PermissionSet>
        {
            private static readonly Dictionary<string,Permission> PermissionNameMap;
            static PermissionSetConverter()
            {
                var permission = typeof(Permission);
                PermissionNameMap = new Dictionary<string, Permission>();
                foreach(var value in Enum.GetValues(permission))
                {
                    var name = Enum.GetName(permission, value) ?? throw new ArgumentNullException();// TODO: better exception
                    var attr = permission
                        .GetMember(name)
                        .FirstOrDefault(member => member.DeclaringType == permission)
                        ?.GetCustomAttribute<EnumMemberAttribute>(false);
                    PermissionNameMap[attr?.Value ?? name] = (Permission)value;
                }
            }

            public override PermissionSet? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialPermissionSet>(ref reader, options);
                if(null == partial)
                    return null;
                var set = new HashSet<Permission>();
                var other = new Dictionary<string,bool>();
                foreach(var pair in partial.Properties)
                {
                    if(pair.Value.ValueKind != JsonValueKind.String)
                        throw new JsonException("Unexpected non-string.");
                    var value =  int.Parse(pair.Value.GetString() ?? throw new ArgumentNullException());
                    if(!PermissionNameMap.TryGetValue(pair.Key, out var permission))
                        other[pair.Key] = value == 1;
                    else if(value == 1)
                        set.Add(permission);
                }
                return new PermissionSet(set, other);
            }

            public override void Write(Utf8JsonWriter writer, PermissionSet value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}