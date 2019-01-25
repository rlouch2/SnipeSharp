using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT user.</summary>
    /// <remarks>
    ///   <para>The Get-User cmdlet gets one or more user objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-User 14</code>
    ///   <para>Retrieve an user by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-User -UserName User4368</code>
    ///   <para>Retrieve an user explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-User</code>
    ///   <para>Retrieve the first 100 users by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindUser" />
    [Cmdlet(VerbsCommon.Get, nameof(User), DefaultParameterSetName = nameof(GetUser.ParameterSets.All))]
    [OutputType(typeof(User))]
    public sealed class GetUser: GetObject<User, UserBinding, UserSearchFilter>
    {
        /// <summary>
        /// Extra parameter sets this cmdlet supports.
        /// </summary>
        internal enum UserParameterSets
        {
            ByUserName,
            ByEmailAddress,
            ByLocation, // not implemented until the API fixes it.
            Me
        }

        /// <summary>The username for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByUserName))]
        public string[] UserName { get; set; }

        /// <summary>The email address for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByEmailAddress))]
        public string[] EmailAddress { get; set; }

        // <summary>
        // A location where users are.
        // </summary>
        // NOT IMPLEMENTED : the controller /locations/{id}/users LocationsController@getDataViewUsers in SnipeIT doesn't exist!
        //[Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByLocation))]
        //public ObjectBinding<Location>[] Location;

        /// <summary>Find deleted users, or non-deleted users?</summary>
        [Parameter(ParameterSetName = nameof(ParameterSets.All))]
        [Parameter(ParameterSetName = nameof(UserParameterSets.ByUserName))]
        [Parameter(ParameterSetName = nameof(UserParameterSets.ByEmailAddress))]
        [Parameter(ParameterSetName = nameof(ParameterSets.ByIdentity))]
        [Parameter(ParameterSetName = nameof(ParameterSets.ByName))]
        public bool Deleted { get; set; }

        /// <summary>Get the current user for the API.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.Me))]
        public SwitchParameter Me { get; set; }

        /// <inheritdoc />
        protected override IEnumerable<UserBinding> GetBoundObjects(UserSearchFilter filter)
        {
            switch(ParameterSetName)
            {
                case nameof(UserParameterSets.ByUserName):
                    foreach(var item in UserName)
                        yield return UserBinding.FromUserName(item, filter);
                    break;
                case nameof(UserParameterSets.ByEmailAddress):
                    foreach(var item in EmailAddress)
                        yield return UserBinding.FromEmailAddress(item, filter);
                    break;
                case nameof(UserParameterSets.ByLocation):
                    //foreach(var item in Location)
                        //yield return null;
                    break;
                case nameof(UserParameterSets.Me):
                    yield return UserBinding.Me();
                    break;
            }
        }

        /// <inheritdoc />
        protected override bool PopulateFilter(UserSearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Deleted)))
                filter.Deleted = Deleted;
            return true;
        }
    }
}
