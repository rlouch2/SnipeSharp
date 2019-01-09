using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT custom field.</para>
    /// <para type="description">The Get-CustomField cmdlet gets one or more custom field objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-CustomField 2</code>
    ///   <para>Retrieve an fieldset by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-CustomField Length</code>
    ///   <para>Retrieve a custom field explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-CustomField</code>
    ///   <para>Retrieve the first 100 custom fields by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-CustomField</para>
    [Cmdlet(VerbsCommon.Get, nameof(CustomField), DefaultParameterSetName = nameof(GetCustomField.ParameterSets.All))]
    [OutputType(typeof(CustomField))]
    public sealed class GetCustomField: GetObject<CustomField, ObjectBinding<CustomField>>
    {
    }
}
