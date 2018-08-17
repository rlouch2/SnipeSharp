using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT model.</para>
    /// <para type="description">The Get-Model cmdlet gets one or more model objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Model 14</code>
    ///   <para>Retrieve an model by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Model Model4368</code>
    ///   <para>Retrieve an model explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Model</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Model</para>
    [Cmdlet(VerbsCommon.Get, nameof(Model),
        DefaultParameterSetName = nameof(GetModel.ParameterSets.All)
    )]
    [OutputType(typeof(Model))]
    public sealed class GetModel: GetObject<Model, ObjectBinding<Model>>
    {
    }
}
