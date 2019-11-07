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
            if(null == element)
                throw new ValidationMetadataException();
            if(!(element is IObjectBinding))
                throw new ValidationMetadataException($"Object {element} is not an ObjectBinding.");
            if(!((IObjectBinding)element).HasValue)
                throw new ValidationMetadataException($"Object {element} has a null inner object.");
        }
    }
}
