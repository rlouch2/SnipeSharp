using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT user.</para>
    /// <para type="description">The Get-User cmdlet gets one or more user objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-User 14</code>
    ///   <para>Retrieve an user by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-User User4368</code>
    ///   <para>Retrieve an user explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-User</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-User</para>
    [Cmdlet(VerbsCommon.Get, nameof(User),
        DefaultParameterSetName = nameof(GetObject<User>.ParameterSets.All)
    )]
    [OutputType(typeof(User))]
    public sealed class GetUser: GetObject<User>
    {
    }
}
