using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Category))]
    [OutputType(typeof(Category))]
    public class SetCategory: SetObject<Category>
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
        protected override void PopulateItem(Category item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.CategoryType = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmailUserOnCheckInOrOut)))
                item.EmailUserOnCheckInOrOut = this.EmailUserOnCheckInOrOut;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsAcceptanceRequired)))
                item.IsAcceptanceRequired = this.IsAcceptanceRequired;
        }
    }
}
