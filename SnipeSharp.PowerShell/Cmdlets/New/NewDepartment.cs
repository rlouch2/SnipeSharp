using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(Department))]
    [OutputType(typeof(Department))]
    public class NewDepartment: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public UserBinding Manager { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Department {
                Name = this.Name,
                ImageUri = this.ImageUri,
                Company = this.Company?.Object,
                Manager = this.Manager?.Object,
                Location = this.Location?.Object
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Departments.Create(item));
        }
    }
}
