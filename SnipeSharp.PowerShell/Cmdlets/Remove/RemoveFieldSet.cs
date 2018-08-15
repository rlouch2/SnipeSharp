using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Field set.</para>
    /// <para type="description">The Remove-FieldSet cmdlet removes one or more FieldSet objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-FieldSet 12</code>
    ///   <para>Removes a FieldSet by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-FieldSet FieldSet4368</code>
    ///   <para>Removes a FieldSet explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-FieldSet</code>
    ///   <para>Removes the first 100 FieldSet objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-FieldSet</para>
    [Cmdlet(VerbsCommon.Remove, nameof(FieldSet),
        DefaultParameterSetName = nameof(RemoveObject<FieldSet>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<FieldSet>))]
    public sealed class RemoveFieldSet: RemoveObject<FieldSet>
    {
    }
}
