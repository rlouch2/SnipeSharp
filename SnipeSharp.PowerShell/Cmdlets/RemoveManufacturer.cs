using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Manufacturer.</para>
    /// <para type="description">The Remove-Manufacturer cmdlet removes one or more Manufacturer objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Manufacturer 12</code>
    ///   <para>Removes a Manufacturer by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Manufacturer Manufacturer4368</code>
    ///   <para>Removes a Manufacturer explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Manufacturer</code>
    ///   <para>Removes the first 100 Manufacturer objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Manufacturer</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Manufacturer),
        DefaultParameterSetName = nameof(RemoveObject<Manufacturer>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Manufacturer>))]
    public sealed class RemoveManufacturer: RemoveObject<Manufacturer>
    {
    }
}
