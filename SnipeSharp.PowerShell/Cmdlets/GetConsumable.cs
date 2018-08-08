using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT consumable.</para>
    /// <para type="description">The Get-Consumable cmdlet gets one or more consumable objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Consumable 14</code>
    ///   <para>Retrieve an consumable by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Consumable Consumable4368</code>
    ///   <para>Retrieve an consumable explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Consumable</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Consumable</para>
    [Cmdlet(VerbsCommon.Get, nameof(Consumable),
        DefaultParameterSetName = nameof(GetObject<Consumable>.ParameterSets.ByName)
    )]
    [OutputType(typeof(Consumable))]
    public class GetConsumable: GetObject<Consumable>
    {
    }
}
