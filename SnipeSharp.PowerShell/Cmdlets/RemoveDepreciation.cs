using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Depreciation.</para>
    /// <para type="description">The Remove-Depreciation cmdlet removes one or more Depreciation objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Depreciation 12</code>
    ///   <para>Removes a Depreciation by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Depreciation Depreciation4368</code>
    ///   <para>Removes a Depreciation explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Depreciation</code>
    ///   <para>Removes the first 100 Depreciation objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Depreciation</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Depreciation),
        DefaultParameterSetName = nameof(RemoveObject<Depreciation>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Depreciation>))]
    public class RemoveDepreciation: RemoveObject<Depreciation>
    {
    }
}
