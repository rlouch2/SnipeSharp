using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT location.</para>
    /// <para type="description">The Get-Location cmdlet gets one or more location objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Location 14</code>
    ///   <para>Retrieve an location by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Location Location4368</code>
    ///   <para>Retrieve an location explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Location</code>
    ///   <para>Retrieve the first 100 locations by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Location</para>
    [Cmdlet(VerbsCommon.Get, nameof(Location), DefaultParameterSetName = nameof(GetLocation.ParameterSets.All))]
    [OutputType(typeof(Location))]
    public sealed class GetLocation: GetObject<Location, ObjectBinding<Location>>
    {
    }
}
