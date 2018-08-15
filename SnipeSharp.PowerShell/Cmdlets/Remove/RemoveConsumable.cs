using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Consumable.</para>
    /// <para type="description">The Remove-Consumable cmdlet removes one or more Consumable objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Consumable 12</code>
    ///   <para>Removes a Consumable by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Consumable Consumable4368</code>
    ///   <para>Removes a Consumable explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Consumable</code>
    ///   <para>Removes the first 100 Consumable objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Consumable</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Consumable),
        DefaultParameterSetName = nameof(RemoveObject<Consumable>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Consumable>))]
    public sealed class RemoveConsumable: RemoveObject<Consumable>
    {
    }
}
