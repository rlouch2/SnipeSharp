using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT company.</summary>
    /// <remarks>
    ///   <para>The Get-Company cmdlet gets one or more company objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-Company 5</code>
    ///   <para>Retrieve an company by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Company Company4368</code>
    ///   <para>Retrieve an company explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Company</code>
    ///   <para>Retrieve the first 100 companies by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindCompany" />
    [Cmdlet(VerbsCommon.Get, nameof(Company), DefaultParameterSetName = nameof(GetCompany.ParameterSets.All))]
    [OutputType(typeof(Company))]
    public sealed class GetCompany: GetObject<Company, ObjectBinding<Company>>
    {
    }
}
