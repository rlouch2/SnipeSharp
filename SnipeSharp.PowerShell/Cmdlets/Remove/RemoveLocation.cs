using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Location.</summary>
    /// <remarks>
    ///   <para>The Remove-Location cmdlet removes one or more Location objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Remove-Location 12</code>
    ///   <para>Removes a Location by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Location Location4368</code>
    ///   <para>Removes a Location explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Location</code>
    ///   <para>Removes the first 100 Location objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindLocation" />
    [Cmdlet(VerbsCommon.Remove, nameof(Location),
        DefaultParameterSetName = nameof(RemoveObject<Location, ObjectBinding<Location>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Location>))]
    public sealed class RemoveLocation: RemoveObject<Location, ObjectBinding<Location>>
    {
    }
}
