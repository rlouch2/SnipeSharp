using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT company.</summary>
    /// <remarks>The Set-Company cmdlet changes the properties of an existing Snipe-IT company object.</remarks>
    /// <example>
    ///   <code>Set-Company -Name 'Potato Inc.' -NewName 'Global Potato Unlimited'</code>
    ///   <para>Changes the name of company "Potato Inc." to "Global Potato Unlimited".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Company))]
    [OutputType(typeof(Company))]
    public class SetCompany: SetObject<Company, ObjectBinding<Company>>
    {
        /// <summary>
        /// The new name of the company.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(Company item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.NewName;
            return true;
        }
    }
}
