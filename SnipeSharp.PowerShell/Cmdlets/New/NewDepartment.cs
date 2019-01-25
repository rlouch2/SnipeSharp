using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT department.</summary>
    /// <remarks>The New-Department cmdlet creates a new department object.</remarks>
    /// <example>
    ///   <code>New-Department -Name "Potato Peeling"</code>
    ///   <para>Create a new department named "Potato Peeling".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Department))]
    [OutputType(typeof(Department))]
    public class NewDepartment: BaseCmdlet
    {
        /// <summary>
        /// The name of the department.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The uri of the image for the department.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The company the department is in.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The manager of the department.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public UserBinding Manager { get; set; }

        /// <summary>
        /// Where the department is located.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Department {
                Name = this.Name,
                ImageUri = this.ImageUri
            };
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!GetSingleValue(Manager, out var manager))
                    return;
                item.Manager = manager;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Departments.Create(item));
        }
    }
}
