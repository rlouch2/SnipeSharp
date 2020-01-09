using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets the Snipe IT assets assigned to a user.</summary>
    /// <remarks>
    ///   <para>The Get-AssignedAsset cmdlet gets, for each user provided, the asset objects associated with that user.</para>
    ///   <para>The Asset objects returned by this cmdlet will not have their assignee data.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-AssignedAsset User1234</code>
    ///   <para>Retrieves the assets assigned to the user User1234.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset User1234, User5678</code>
    ///   <para>Retrieve the assets assigned to the user User1234 or the user User5678.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "AssignedAsset", DefaultParameterSetName = nameof(ParameterSets.ByUser))]
    [OutputType(typeof(Asset))]
    public sealed class GetAssignedAsset: PSCmdlet
    {
        /// <summary>
        /// Parameter sets this cmdlet supports
        /// </summary>
        internal enum ParameterSets
        {
            ByUser,
            ByLocation,
            ByAsset
        }

        /// <summary>The user to find the assets of.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByUser))]
        public UserBinding[] User { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == nameof(ParameterSets.ByUser))
            {
                foreach(var item in User)
                {
                    if (this.GetSingleValue(item, out var user))
                        WriteObject(ApiHelper.Instance.Users.GetAssignedAssets(user), true);
                }
            }
        }
    }
}
