using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Interface for testing if a binding has a value.
    /// </summary>
    /// <remarks>
    ///    Only one thing, <see cref="ObjectBinding{T}" />, should implement this. It's used in
    ///    <see cref="ValidateIdentityNotNullAttribute" /> for internal validation.
    /// </remarks>
    public interface IObjectBinding
    {
        /// <summary>
        /// Does the binding have a value?
        /// </summary>
        bool HasValue { get; }
    }
}
