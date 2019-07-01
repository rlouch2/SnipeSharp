using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT category.</summary>
    /// <remarks>The Set-Category cmdlet changes the properties of an existing Snipe-IT category object.</remarks>
    /// <example>
    ///   <code>Set-Category -Name 'Utility' -IsAcceptanceRequired $true</code>
    ///   <para>Changes the category 'Utility' to require EULA acceptance.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Category))]
    [OutputType(typeof(Category))]
    public class SetCategory: SetObject<Category, ObjectBinding<Category>>
    {
        /// <summary>
        /// The new name of the category.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The updated type the category is for.
        /// </summary>
        [Parameter]
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
        protected override bool PopulateItem(Category item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.CategoryType = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmailUserOnCheckInOrOut)))
                item.EmailUserOnCheckInOrOut = this.EmailUserOnCheckInOrOut;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsAcceptanceRequired)))
                item.IsAcceptanceRequired = this.IsAcceptanceRequired;
            return true;
        }
    }
}
