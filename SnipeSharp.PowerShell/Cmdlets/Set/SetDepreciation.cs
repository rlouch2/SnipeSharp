using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT depreciation.</para>
    /// <para type="description">The Set-Depreciation cmdlet changes the properties of an existing Snipe-IT depreciation object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-Depreciation -Name "General Potato Peeler" -NewName "Generic Potato Peeler"</code>
    ///   <para>Changes the name of depreciation "General Potato Peeler" to "Generic Potato Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Depreciation))]
    [OutputType(typeof(Depreciation))]
    public class SetDepreciation: SetObject<Depreciation>
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
        protected override void PopulateItem(Depreciation item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Months)))
                item.Months = this.Months;
        }
    }
}
