using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT user.</summary>
    /// <remarks>The Find-User cmdlet finds user objects by filter, company, location, group, or department.</remarks>
    /// <example>
    ///   <code>Find-User -IncludeDeleted</code>
    ///   <para>Finds all users, included deleted ones.</para>
    /// </example>
    /// <example>
    ///   <code>Find-User "ThePotatoPeeler"</code>
    ///   <para>Finds users that match the search string "ThePotatoPeeler".</para>
    /// </example>
    /// <example>
    ///   <code>Find-User -Company $x</code>
    ///   <para>Finds users that work for company $x.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(User), SupportsPaging = true)]
    [OutputType(typeof(User))]
    public class FindUser: FindObject<User, UserSearchColumn, UserSearchFilter>
    {
        /// <summary>Find deleted users, or non-deleted users?</summary>
        [Parameter]
        public bool Deleted { get; set; }

        /// <summary>Filter by company.</summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>Filter by location.</summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>Filter by group membership.</summary>
        [Parameter]
        public ObjectBinding<Group> Group { get; set; }

        /// <summary>Filter by department.</summary>
        [Parameter]
        public ObjectBinding<Department> Department { get; set; }

        /// <inheritdoc />
        protected override bool PopulateFilter(UserSearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return false;
                filter.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return false;
                filter.Location = location;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Group)))
            {
                if (!GetSingleValue(Group, out var group))
                    return false;
                filter.Group = group;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Department)))
            {
                if (!GetSingleValue(Department, out var department))
                    return false;
                filter.Department = department;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Deleted)))
                filter.Deleted = Deleted;
            return true;
        }
    }
}
