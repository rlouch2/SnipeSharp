using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT User.</para>
    /// <para type="description">The Remove-User cmdlet removes one or more User objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-User 12</code>
    ///   <para>Removes a User by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-User User4368</code>
    ///   <para>Removes a User explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-User</code>
    ///   <para>Removes the first 100 User objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-User</para>
    [Cmdlet(VerbsCommon.Remove, nameof(User),
        DefaultParameterSetName = nameof(RemoveObject<User>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<User>))]
    public class RemoveUser: RemoveObject<User>
    {
    }
}
