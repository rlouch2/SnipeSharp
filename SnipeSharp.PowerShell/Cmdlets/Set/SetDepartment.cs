using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT department.</para>
    /// <para type="description">The Set-Department cmdlet changes the properties of an existing Snipe-IT department object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-Department -Name "Potato Peeling" -NewName "Potato Preparation" -Manager respud</code>
    ///   <para>Changes the name of department "Potato Peeling" to "Potato Preparation" and its manager to "R. E. Spud".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Department))]
    [OutputType(typeof(Depreciation))]
    public class SetDepartment: SetObject<Department>
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
        protected override void PopulateItem(Department item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Object;
        }
    }
}
