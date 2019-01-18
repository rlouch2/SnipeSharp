using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Field set.</summary>
    /// <remarks>
    ///   <para>The Remove-FieldSet cmdlet removes one or more FieldSet objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
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
    /// <seealso cref="FindFieldSet" />
    [Cmdlet(VerbsCommon.Remove, nameof(FieldSet),
        DefaultParameterSetName = nameof(RemoveObject<FieldSet, ObjectBinding<FieldSet>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<FieldSet>))]
    public sealed class RemoveFieldSet: RemoveObject<FieldSet, ObjectBinding<FieldSet>>
    {
    }
}
