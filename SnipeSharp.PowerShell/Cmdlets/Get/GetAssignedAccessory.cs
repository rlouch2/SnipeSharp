using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets the Snipe IT accessories checked out by a user.</summary>
    /// <remarks>The Get-AssignedAccessory cmdlet gets, for each user provided, the accessory objects associated with that user.</remarks>
    /// <example>
    ///   <code>Get-AssignedAccessory User1234</code>
    ///   <para>Retrieves the accessories checked out by the user User1234.</para>
    /// </example>
    /// <example>
    ///   <code>Get-AssignedAccessory User1234, User5678</code>
    ///   <para>Retrieve the accessories checked out by the user User1234 or the user User5678.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "AssignedAccessory")]
    [OutputType(typeof(Asset))]
    public sealed class GetAssignedAccessory: Cmdlet
    {
        /// <summary>The user to find the accessories of.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public UserBinding[] User { get; set; }

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            foreach(var item in User)
            {
                if (this.GetSingleValue(item, out var itemValue))
                    WriteObject(ApiHelper.Instance.Users.GetAssignedAccessories(itemValue), !NoEnumerate.IsPresent);
            }
        }
    }
}
