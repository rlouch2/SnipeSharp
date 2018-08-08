using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Status label.</para>
    /// <para type="description">The Remove-StatusLabel cmdlet removes one or more StatusLabel objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
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
    /// <para type="link">Find-StatusLabel</para>
    [Cmdlet(VerbsCommon.Remove, nameof(StatusLabel),
        DefaultParameterSetName = nameof(RemoveObject<StatusLabel>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<StatusLabel>))]
    public class RemoveStatusLabel: RemoveObject<StatusLabel>
    {
    }
}
