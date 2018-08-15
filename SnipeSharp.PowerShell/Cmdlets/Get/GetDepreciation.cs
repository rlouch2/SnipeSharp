using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT depreciation.</para>
    /// <para type="description">The Get-Depreciation cmdlet gets one or more depreciation objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Depreciation 14</code>
    ///   <para>Retrieve an depreciation by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Depreciation Depreciation4368</code>
    ///   <para>Retrieve an depreciation explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Depreciation</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Depreciation</para>
    [Cmdlet(VerbsCommon.Get, nameof(Depreciation),
        DefaultParameterSetName = nameof(GetObject<Depreciation>.ParameterSets.All)
    )]
    [OutputType(typeof(Depreciation))]
    public sealed class GetDepreciation: GetObject<Depreciation>
    {
    }
}
