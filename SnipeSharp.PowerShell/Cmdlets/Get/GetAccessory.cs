using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe-IT accessory.</summary>
    /// <remarks>The Get-Accessory cmdlet gets one or more accessory objects by name or by Snipe-IT internal id number.</remarks>
    /// <remarks>Whatever identifier is used, both accept pipeline input.</remarks>
    /// <example>
    ///   <code>Get-Accessory 12</code>
    ///   <para>Retrieve an accessory by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Accessory Accessory4368</code>
    ///   <para>Retrieve an accessory explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Accessory</code>
    ///   <para>Retrieve the first 100 accessories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindAccessory" />
    [Cmdlet(VerbsCommon.Get, nameof(Accessory), DefaultParameterSetName = nameof(GetAccessory.ParameterSets.All))]
    [OutputType(typeof(Accessory))]
    public sealed class GetAccessory: GetObject<Accessory, ObjectBinding<Accessory>>
    {
    }
}
