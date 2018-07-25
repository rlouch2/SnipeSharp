using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class ValidateIdentityNotNullAttribute : ValidateEnumeratedArgumentsAttribute
    {
        protected override void ValidateElement(object element)
        {
            if(element == null)
                throw new ValidationMetadataException();
            // TODO: check identities for null for real
        }
    }
}