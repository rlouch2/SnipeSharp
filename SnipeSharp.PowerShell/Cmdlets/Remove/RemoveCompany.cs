using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Company.</para>
    /// <para type="description">The Remove-Company cmdlet removes one or more Company objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Company 12</code>
    ///   <para>Removes a Company by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Company Company4368</code>
    ///   <para>Removes a Company explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Company</code>
    ///   <para>Removes the first 100 Company objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Company</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Company),
        DefaultParameterSetName = nameof(RemoveObject<Company>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Company>))]
    public sealed class RemoveCompany: RemoveObject<Company>
    {
    }
}
