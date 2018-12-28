using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Company))]
    [OutputType(typeof(Company))]
    public class SetCompany: SetObject<Company>
    {
        /// <summary>
        /// The new name of the company.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }
        
        /// <inheritdoc />
        protected override void PopulateItem(Company item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.NewName;
        }
    }
}
