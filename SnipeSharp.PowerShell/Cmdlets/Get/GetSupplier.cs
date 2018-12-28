using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT supplier.</para>
    /// <para type="description">The Get-Supplier cmdlet gets one or more supplier objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Supplier 14</code>
    ///   <para>Retrieve an supplier by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Supplier Supplier4368</code>
    ///   <para>Retrieve an supplier explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Supplier</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Supplier</para>
    [Cmdlet(VerbsCommon.Get, nameof(Supplier), DefaultParameterSetName = nameof(GetSupplier.ParameterSets.All))]
    [OutputType(typeof(Supplier))]
    public sealed class GetSupplier: GetObject<Supplier, ObjectBinding<Supplier>>
    {
    }
}
