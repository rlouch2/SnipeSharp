using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT company.</summary>
    /// <remarks>The New-Company cmdlet creates a new company object.</remarks>
    /// <example>
    ///   <code>New-Company -Name "Potato Inc."</code>
    ///   <para>Create a new company named "Potato Inc.".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Company))]
    [OutputType(typeof(Company))]
    public class NewCompany: PSCmdlet
    {
        /// <summary>
        /// The name of the company.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Company {
                Name = this.Name
            };
            // TODO: error handling
            WriteObject(ApiHelper.Instance.Companies.Create(item));
        }
    }
}
