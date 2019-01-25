using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT depreciation.</summary>
    /// <remarks>The Set-Depreciation cmdlet changes the properties of an existing Snipe-IT depreciation object.</remarks>
    /// <example>
    ///   <code>Set-Depreciation -Name "General Potato Peeler" -NewName "Generic Potato Peeler"</code>
    ///   <para>Changes the name of depreciation "General Potato Peeler" to "Generic Potato Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Depreciation))]
    [OutputType(typeof(Depreciation))]
    public class SetDepreciation: SetObject<Depreciation, ObjectBinding<Depreciation>>
    {
        /// <summary>
        /// The new name of the depreciation.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The new duration of the depreciation in months.
        /// </summary>
        [Parameter]
        public int Months { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(Depreciation item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Months)))
                item.Months = this.Months;
            return true;
        }
    }
}
