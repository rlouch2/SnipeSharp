using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT fieldset.</para>
    /// <para type="description">The Get-FieldSet cmdlet gets one or more fieldset objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-FieldSet 14</code>
    ///   <para>Retrieve an fieldset by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-FieldSet FieldSet4368</code>
    ///   <para>Retrieve an fieldset explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-FieldSet</code>
    ///   <para>Retrieve the first 100 fieldsets by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-FieldSet</para>
    [Cmdlet(VerbsCommon.Get, nameof(FieldSet), DefaultParameterSetName = nameof(GetFieldSet.ParameterSets.All))]
    [OutputType(typeof(FieldSet))]
    public sealed class GetFieldSet: GetObject<FieldSet, ObjectBinding<FieldSet>>
    {
    }
}
