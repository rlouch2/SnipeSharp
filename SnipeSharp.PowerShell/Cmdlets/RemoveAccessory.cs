using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT accessory.</para>
    /// <para type="description">The Remove-Accessory cmdlet removes one or more accessory objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Accessory 12</code>
    ///   <para>Removes an accessory by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Accessory Accessory4368</code>
    ///   <para>Removes an accessory explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Accessory</code>
    ///   <para>Removes the first 100 accessories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Accessory</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Accessory),
        DefaultParameterSetName = nameof(RemoveObject<Accessory>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Accessory>))]
    public class RemoveAccessory: RemoveObject<Accessory>
    {
    }
}
