using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT License.</para>
    /// <para type="description">The Remove-License cmdlet removes one or more License objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-License 12</code>
    ///   <para>Removes a License by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-License License4368</code>
    ///   <para>Removes a License explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-License</code>
    ///   <para>Removes the first 100 License objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-License</para>
    [Cmdlet(VerbsCommon.Remove, nameof(License),
        DefaultParameterSetName = nameof(RemoveObject<License, ObjectBinding<License>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<License>))]
    public sealed class RemoveLicense: RemoveObject<License, ObjectBinding<License>>
    {
    }
}
