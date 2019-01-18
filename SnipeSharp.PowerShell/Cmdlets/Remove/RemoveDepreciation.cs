using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Depreciation.</summary>
    /// <remarks>
    ///   <para>The Remove-Depreciation cmdlet removes one or more Depreciation objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
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
    /// <seealso cref="FindDepreciation" />
    [Cmdlet(VerbsCommon.Remove, nameof(Depreciation),
        DefaultParameterSetName = nameof(RemoveObject<Depreciation, ObjectBinding<Depreciation>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Depreciation>))]
    public sealed class RemoveDepreciation: RemoveObject<Depreciation, ObjectBinding<Depreciation>>
    {
    }
}
