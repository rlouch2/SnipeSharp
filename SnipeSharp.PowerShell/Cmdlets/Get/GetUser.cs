using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
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
        DefaultParameterSetName = nameof(GetUser.ParameterSets.All)
    )]
    [OutputType(typeof(User))]
    public sealed class GetUser: GetObject<User, UserBinding>
    {
        internal enum UserParameterSets
        {
            ByUserName,
            ByEmailAddress
        }

        /// <summary>
        /// <para type="description">The username for the User.</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByUserName))]
        public string[] UserName { get; set; }

        /// <summary>
        /// <para type="description">The email address for the User.</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByEmailAddress))]
        public string[] EmailAddress { get; set; }

        /// <inheritdoc />
        protected override IEnumerable<UserBinding> GetBoundObjects()
        {
            if(ParameterSetName == nameof(UserParameterSets.ByUserName))
            {
                foreach(var item in UserName)
                    yield return UserBinding.FromUserName(item);
            } else
            {
                foreach(var item in EmailAddress)
                    yield return UserBinding.FromEmailAddress(item);
            }
        }
    }
}
