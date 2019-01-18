using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Status label.</summary>
    /// <remarks>
    ///   <para>The Remove-StatusLabel cmdlet removes one or more StatusLabel objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Remove-StatusLabel 12</code>
    ///   <para>Removes a StatusLabel by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-StatusLabel StatusLabel4368</code>
    ///   <para>Removes a StatusLabel explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-StatusLabel</code>
    ///   <para>Removes the first 100 StatusLabel objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindStatusLabel" />
    [Cmdlet(VerbsCommon.Remove, nameof(StatusLabel),
        DefaultParameterSetName = nameof(RemoveObject<StatusLabel, ObjectBinding<StatusLabel>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<StatusLabel>))]
    public sealed class RemoveStatusLabel: RemoveObject<StatusLabel, ObjectBinding<StatusLabel>>
    {
    }
}
