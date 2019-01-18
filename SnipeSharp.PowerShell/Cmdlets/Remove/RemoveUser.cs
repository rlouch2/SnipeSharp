using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT User.</summary>
    /// <remarks>
    ///   <para>The Remove-User cmdlet removes one or more User objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Remove-User 12</code>
    ///   <para>Removes a User by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-User User4368</code>
    ///   <para>Removes a User explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-User</code>
    ///   <para>Removes the first 100 User objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindUser" />
    [Cmdlet(VerbsCommon.Remove, nameof(User),
        DefaultParameterSetName = nameof(RemoveObject<User, UserBinding>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<User>))]
    public sealed class RemoveUser: RemoveObject<User, UserBinding>
    {
        internal enum UserParameterSets
        {
            ByUserName,
            ByEmailAddress
        }

        /// <summary>The username for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByUserName), ValueFromPipelineByPropertyName = true)]
        public string[] UserName { get; set; }

        /// <summary>The email address for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByEmailAddress), ValueFromPipelineByPropertyName = true)]
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
