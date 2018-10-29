using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Columns a user search can be sorted on.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserSearchColumn
    {
        /// <summary>The users' manager.</summary>
        [EnumMember(Value = "manager")]
        Manager,
        /// <summary>The user's location.</summary>
        [EnumMember(Value = "location")]
        Location,
        /// <summary>The user's department.</summary>
        [EnumMember(Value = "department")]
        Department,
        /// <summary>The user's last name.</summary>
        [EnumMember(Value = "last_name")]
        LastName,
        /// <summary>The user's first name.</summary>
        [EnumMember(Value = "first_name")]
        FirstName,
        /// <summary>The user's email address.</summary>
        [EnumMember(Value = "email")]
        EmailAddress,
        /// <summary>The users' job title.</summary>
        [EnumMember(Value = "jobtitle")]
        JobTitle,
        /// <summary>The user's username.</summary>
        [EnumMember(Value = "username")]
        UserName,
        /// <summary>The user's employee number.</summary>
        [EnumMember(Value = "employee_num")]
        EmployeeNumber,
        
        /* These columns, while technically present in the allowed column list,
         * will cause many errors if you try to actually use them.
         * I'm disabling them for now, maybe these'll be fixed in the future.
         *
         * [EnumMember(Value = "assets")]
         * Assets,
         * [EnumMember(Value = "accessories")]
         * Accessories,
         * [EnumMember(Value = "consumables")]
         * Consumables,
         * [EnumMember(Value = "licenses")]
         * Licenses,
         * [EnumMember(Value = "groups")]
         * Groups,
         */
        /// <summary>Whether or not the user is activated.</summary>
        [EnumMember(Value = "activated")]
        IsActivated,
        /// <summary>The date the user was created.</summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,
        /// <summary>Whether or not the user is enrolled in two-factor.</summary>
        [EnumMember(Value = "two_factor_enrolled")]
        IsEnrolledInTwoFactor,
        /// <summary>Whether or not the user is opted in to two-factor.</summary>
        [EnumMember(Value = "two_factor_optin")]
        IsOptedInToTwoFactor,
        /// <summary>The date the user last logged in.</summary>
        [EnumMember(Value = "last_login")]
        LastLoginDate,
        /// <summary>How many assets the user has assigned to them.</summary>
        [EnumMember(Value = "assets_count")]
        AssetsCount,
        /// <summary>How many licenses the user has assigned to them.</summary>
        [EnumMember(Value = "licenses_count")]
        LicensesCount,
        /// <summary>How many consumables the user has assigned to them.</summary>
        [EnumMember(Value = "consumables_count")]
        ConsumablesCount,
        /// <summary>How many accessories the user has assigned to them.</summary>
        [EnumMember(Value = "accessories_count")]
        AccessoriesCount,
        /// <summary>The user's phone number.</summary>
        [EnumMember(Value = "phone")]
        PhoneNumber,
        /// <summary>The user's street address.</summary>
        [EnumMember(Value = "address")]
        Address,
        /// <summary>The city of the user's address.</summary>
        [EnumMember(Value = "city")]
        City,
        /// <summary>The state the user's address is in.</summary>
        [EnumMember(Value = "state")]
        State,
        /// <summary>The country the user's address is in.</summary>
        [EnumMember(Value = "country")]
        Country,
        /// <summary>The zip code of the user's address.</summary>
        [EnumMember(Value = "zip")]
        ZipCode,
        /// <summary>The internal Id number.</summary>
        [EnumMember(Value = "id")]
        Id
    }
}