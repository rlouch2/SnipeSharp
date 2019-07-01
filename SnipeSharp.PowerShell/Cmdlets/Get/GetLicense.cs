using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT license.</summary>
    /// <remarks>
    ///   <para>The Get-License cmdlet gets one or more license objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-License 14</code>
    ///   <para>Retrieve an license by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-License License4368</code>
    ///   <para>Retrieve an license explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-License</code>
    ///   <para>Retrieve the first 100 licenses by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindLicense" />
    [Cmdlet(VerbsCommon.Get, nameof(License), DefaultParameterSetName = nameof(GetLicense.ParameterSets.All))]
    [OutputType(typeof(License))]
    public sealed class GetLicense: GetObject<License, ObjectBinding<License>>
    {
    }
}
