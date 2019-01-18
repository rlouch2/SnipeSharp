using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT accessory.</summary>
    /// <remarks>The Remove-Accessory cmdlet removes one or more accessory objects by name or by Snipe IT internal id number from the Snipe IT database.</remarks>
    /// <remarks>Whatever identifier is used, both accept pipeline input.</remarks>
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
    /// <seealso cref="FindAccessory" />
    [Cmdlet(VerbsCommon.Remove, nameof(Accessory),
        DefaultParameterSetName = nameof(RemoveObject<Accessory, ObjectBinding<Accessory>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Accessory>))]
    public sealed class RemoveAccessory: RemoveObject<Accessory, ObjectBinding<Accessory>>
    {
    }
}
