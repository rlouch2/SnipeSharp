using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT manufacturer.</para>
    /// <para type="description">The Get-Manufacturer cmdlet gets one or more manufacturer objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Manufacturer 14</code>
    ///   <para>Retrieve an manufacturer by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Manufacturer Manufacturer4368</code>
    ///   <para>Retrieve an manufacturer explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Manufacturer</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Manufacturer</para>
    [Cmdlet(VerbsCommon.Get, nameof(Manufacturer),
        DefaultParameterSetName = nameof(GetObject<Manufacturer>.ParameterSets.All)
    )]
    [OutputType(typeof(Manufacturer))]
    public sealed class GetManufacturer: PSCmdlet
    {
    }
}
