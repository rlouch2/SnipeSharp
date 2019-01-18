using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT status label.</summary>
    /// <remarks>
    ///   <para>The Get-StatusLabel cmdlet gets one or more status label objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
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
    ///   <para>Retrieve the first 100 status labels by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindStatusLabel" />
    [Cmdlet(VerbsCommon.Get, nameof(StatusLabel), DefaultParameterSetName = nameof(GetStatusLabel.ParameterSets.All))]
    [OutputType(typeof(StatusLabel))]
    public sealed class GetStatusLabel: GetObject<StatusLabel, ObjectBinding<StatusLabel>>
    {
    }
}
