using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT component.</summary>
    /// <remarks>
    ///   <para>The Get-Component cmdlet gets one or more component objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-Component 14</code>
    ///   <para>Retrieve an component by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Component Component4368</code>
    ///   <para>Retrieve an component explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Component</code>
    ///   <para>Retrieve the first 100 components by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindComponent" />
    [Cmdlet(VerbsCommon.Get, nameof(Component), DefaultParameterSetName = nameof(GetComponent.ParameterSets.All))]
    [OutputType(typeof(Component))]
    public sealed class GetComponent: GetObject<Component, ObjectBinding<Component>>
    {
    }
}
