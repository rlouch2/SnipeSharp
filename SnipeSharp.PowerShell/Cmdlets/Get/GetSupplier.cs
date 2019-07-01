using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT supplier.</summary>
    /// <remarks>
    ///   <para>The Get-Supplier cmdlet gets one or more supplier objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
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
    ///   <para>Retrieve the first 100 suppliers by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindSupplier" />
    [Cmdlet(VerbsCommon.Get, nameof(Supplier), DefaultParameterSetName = nameof(GetSupplier.ParameterSets.All))]
    [OutputType(typeof(Supplier))]
    public sealed class GetSupplier: GetObject<Supplier, ObjectBinding<Supplier>>
    {
    }
}
