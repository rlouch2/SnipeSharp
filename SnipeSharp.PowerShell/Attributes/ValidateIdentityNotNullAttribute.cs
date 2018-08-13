using System;
using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class ValidateIdentityNotNullAttribute : ValidateEnumeratedArgumentsAttribute
    {
        protected override void ValidateElement(object element)
        {
            if(element is null)
                throw new ValidationMetadataException();
            if(!(element is INullObjectBinding))
                throw new ValidationMetadataException($"Object {element} is not an ObjectBinding.");
            if((element as INullObjectBinding)?.IsNull ?? false)
                throw new ValidationMetadataException($"Object {element} has a null inner object.");
        }
    }
}
