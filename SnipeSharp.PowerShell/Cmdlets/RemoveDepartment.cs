using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Department.</para>
    /// <para type="description">The Remove-Department cmdlet removes one or more Department objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Department 12</code>
    ///   <para>Removes a Department by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Department Department4368</code>
    ///   <para>Removes a Department explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Department</code>
    ///   <para>Removes the first 100 Department objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Department</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Department),
        DefaultParameterSetName = nameof(RemoveObject<Department>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Department>))]
    public sealed class RemoveDepartment: RemoveObject<Department>
    {
    }
}
