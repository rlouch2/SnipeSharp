using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT field set.</para>
    /// <para type="description">The Set-FieldSet cmdlet changes the properties of an existing Snipe-IT field set object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-FieldSet -Name "Peeler" -NewName "Potato Peeler"</code>
    ///   <para>Changes the name of fieldset "Peeler" to "Potato Peeler" to distinguish it from "Carrot Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(FieldSet))]
    [OutputType(typeof(FieldSet))]
    public class SetFieldSet: SetObject<FieldSet>
    {
        /// <summary>
        /// The new name for the field set.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        // TODO: assigning fields to/from a set.
        
        /// <inheritdoc />
        protected override void PopulateItem(FieldSet item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = NewName;
        }
    }
}
