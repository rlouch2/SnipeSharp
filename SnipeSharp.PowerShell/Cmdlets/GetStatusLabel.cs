using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT status label.</para>
    /// <para type="description">The Get-StatusLabel cmdlet gets one or more status label objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-StatusLabel 14</code>
    ///   <para>Retrieve an status label by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-StatusLabel StatusLabel4368</code>
    ///   <para>Retrieve an status label explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-StatusLabel</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-StatusLabel</para>
    [Cmdlet(VerbsCommon.Get, nameof(StatusLabel),
        DefaultParameterSetName = nameof(GetObject<StatusLabel>.ParameterSets.ByName)
    )]
    [OutputType(typeof(StatusLabel))]
    public class GetStatusLabel: GetObject<StatusLabel>
    {
    }
}
