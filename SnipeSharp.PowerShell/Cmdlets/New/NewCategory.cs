using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    /// <summary>
    /// <para type="synopsis">Creates a new Snipe-IT category.</para>
    /// <para type="description">The New-Category cmdlet creates a new category object.</para>
    /// </summary>
    /// <example>
    ///   <code>New-Category -Name "Utility" -Type Accessory</code>
    ///   <para>Create a new category for accessories named "Utility".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Category))]
    [OutputType(typeof(Category))]
    public class NewCategory: PSCmdlet
    {
        /// <summary>
        /// The name of the category.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// What type the category is for.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public CategoryType Type { get; set; }

        /// <summary>
        /// Should users be emailed when they check in/out things from this category?
        /// </summary>
        [Parameter]
        public bool EmailUserOnCheckInOrOut { get; set; }

        /// <summary>
        /// Is it required to accept the EULA?
        /// </summary>
        [Parameter]
        public bool IsAcceptanceRequired { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Category {
                Name = this.Name,
                CategoryType = this.Type
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmailUserOnCheckInOrOut)))
                item.EmailUserOnCheckInOrOut = this.EmailUserOnCheckInOrOut;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsAcceptanceRequired)))
                item.IsAcceptanceRequired = this.IsAcceptanceRequired;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Categories.Create(item));
        }
    }
}
