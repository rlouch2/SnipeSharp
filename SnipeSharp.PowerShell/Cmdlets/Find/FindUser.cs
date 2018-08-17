using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    [Cmdlet(VerbsCommon.Find, nameof(User),
        SupportsPaging = true
    )]
    [OutputType(typeof(User))]
    public class FindUser: FindObject<User, UserSearchColumn, UserSearchFilter>
    {
        /// <summary>
        /// <para type="description">If present, also search for deleted users.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter IncludeDeleted { get; set; }

        /// <summary>
        /// <para type="description">Filter by company.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// <para type="description">Filter by location.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// <para type="description">Filter by group membership.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Group> Group { get; set; }

        /// <summary>
        /// <para type="description">Filter by department.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Department> Department { get; set; }

        /// <inheritdoc />
        protected override void PopulateFilter(UserSearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                filter.Company = Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                filter.Location = Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Group)))
                filter.Group = Group?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Department)))
                filter.Department = Department?.Object;
            if(IncludeDeleted.IsPresent)
                filter.IncludeDeleted = true;
        }
    }
}
