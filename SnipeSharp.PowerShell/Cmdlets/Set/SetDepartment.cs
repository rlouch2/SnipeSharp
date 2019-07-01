using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT department.</summary>
    /// <remarks>The Set-Department cmdlet changes the properties of an existing Snipe-IT department object.</remarks>
    /// <example>
    ///   <code>Set-Department -Name "Potato Peeling" -NewName "Potato Preparation" -Manager respud</code>
    ///   <para>Changes the name of department "Potato Peeling" to "Potato Preparation" and its manager to "R. E. Spud".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Department))]
    [OutputType(typeof(Depreciation))]
    public class SetDepartment: SetObject<Department, ObjectBinding<Department>>
    {
        /// <summary>
        /// The new name of the department.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The updated uri of the image for the department.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The update company the department belongs to.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The updated manager of the department.
        /// </summary>
        [Parameter]
        public UserBinding Manager { get; set; }

        /// <summary>
        /// The updated location of the department.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(Department item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return false;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!GetSingleValue(Manager, out var manager))
                    return false;
                item.Manager = manager;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return false;
                item.Location = location;
            }
            return true;
        }
    }
}
