using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT department.</summary>
    /// <remarks>
    ///   <para>The Get-Department cmdlet gets one or more department objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
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
    ///   <para>Retrieve the first 100 departments by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindDepartment" />
    [Cmdlet(VerbsCommon.Get, nameof(Department), DefaultParameterSetName = nameof(GetDepartment.ParameterSets.All))]
    [OutputType(typeof(Department))]
    public sealed class GetDepartment: GetObject<Department, ObjectBinding<Department>>
    {
    }
}
