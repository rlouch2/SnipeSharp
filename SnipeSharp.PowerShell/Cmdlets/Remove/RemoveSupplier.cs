using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Supplier.</para>
    /// <para type="description">The Remove-Supplier cmdlet removes one or more Supplier objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Supplier 12</code>
    ///   <para>Removes a Supplier by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Supplier Supplier4368</code>
    ///   <para>Removes a Supplier explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Supplier</code>
    ///   <para>Removes the first 100 Supplier objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Supplier</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Supplier),
        DefaultParameterSetName = nameof(RemoveObject<Supplier, ObjectBinding<Supplier>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Supplier>))]
    public sealed class RemoveSupplier: RemoveObject<Supplier, ObjectBinding<Supplier>>
    {
    }
}
