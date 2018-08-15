using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT department.</para>
    /// <para type="description">The Get-Department cmdlet gets one or more department objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Department 14</code>
    ///   <para>Retrieve an department by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Department Department4368</code>
    ///   <para>Retrieve an department explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Department</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Department</para>
    [Cmdlet(VerbsCommon.Get, nameof(Department),
        DefaultParameterSetName = nameof(GetObject<Department>.ParameterSets.All)
    )]
    [OutputType(typeof(Department))]
    public sealed class GetDepartment: GetObject<Department>
    {
    }
}
