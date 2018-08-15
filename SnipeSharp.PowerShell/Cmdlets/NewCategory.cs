using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Category")]
    [OutputType(typeof(Category))]
    public class NewCategory: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public CategoryType Type { get; set; }

        [Parameter]
        public bool EmailUserOnCheckInOrOut { get; set; }

        [Parameter]
        public bool IsAcceptanceRequired { get; set; }

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
