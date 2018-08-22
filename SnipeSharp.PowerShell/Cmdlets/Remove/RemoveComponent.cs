using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Component.</para>
    /// <para type="description">The Remove-Component cmdlet removes one or more Component objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Component 12</code>
    ///   <para>Removes a Component by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Component Component4368</code>
    ///   <para>Removes a Component explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Component</code>
    ///   <para>Removes the first 100 Component objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Component</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Component),
        DefaultParameterSetName = nameof(RemoveObject<Component, ObjectBinding<Component>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Component>))]
    public sealed class RemoveComponent: RemoveObject<Component, ObjectBinding<Component>>
    {
    }
}
