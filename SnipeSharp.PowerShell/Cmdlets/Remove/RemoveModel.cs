using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Model.</summary>
    /// <remarks>
    ///   <para>The Remove-Model cmdlet removes one or more Model objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Remove-Model 12</code>
    ///   <para>Removes a Model by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Model Model4368</code>
    ///   <para>Removes a Model explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Model</code>
    ///   <para>Removes the first 100 Model objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindModel" />
    [Cmdlet(VerbsCommon.Remove, nameof(Model),
        DefaultParameterSetName = nameof(RemoveObject<Model, ObjectBinding<Model>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Model>))]
    public sealed class RemoveModel: RemoveObject<Model, ObjectBinding<Model>>
    {
    }
}
