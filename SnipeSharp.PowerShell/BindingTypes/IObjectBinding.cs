namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Interface for testing if a binding has a value.
    /// </summary>
    public interface IObjectBinding
    {
        /// <summary>
        /// Does the binding have a value?
        /// </summary>
        bool HasValue { get; }
    }
}
