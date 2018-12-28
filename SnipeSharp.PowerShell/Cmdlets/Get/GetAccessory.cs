using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe-IT accessory.</para>
    /// <para type="description">The Get-Accessory cmdlet gets one or more accessory objects by name or by Snipe-IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Accessory 12</code>
    ///   <para>Retrieve an accessory by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Accessory Accessory4368</code>
    ///   <para>Retrieve an accessory explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Accessory</code>
    ///   <para>Retrieve the first 100 accessories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Accessory</para>
    [Cmdlet(VerbsCommon.Get, nameof(Accessory), DefaultParameterSetName = nameof(GetAccessory.ParameterSets.All))]
    [OutputType(typeof(Accessory))]
    public sealed class GetAccessory: GetObject<Accessory, ObjectBinding<Accessory>>
    {
    }
}
