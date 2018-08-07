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
            if(element == null)
                throw new ValidationMetadataException();
            if(!(element is IObjectIdentity))
                throw new ValidationMetadataException($"Object {element} is not an IObjectIdentity.");
            if((element as IObjectIdentity).IsNull)
                throw new ValidationMetadataException($"Object {element} has a null inner object.");
        }
    }
}