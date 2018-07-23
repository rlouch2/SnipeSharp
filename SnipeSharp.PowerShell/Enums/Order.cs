namespace SnipeSharp.PowerShell.Enums
{
    /// <summary>
    /// Methods for the <see cref="SnipeSharp.PowerShell.Enums.Order" /> type.
    /// </summary>
    internal static class OrderMethods
    {
        /// <summary>
        /// Converts an <see cref="SnipeSharp.PowerShell.Enums.Order" /> into a string compatible with the Snipe IT API.
        /// </summary>
        /// <param name="order">An order.</param>
        /// <returns>A Snipe IT API-compatible order string.</returns>
        public static string ToString(this Order order) => order == Order.Ascending ? "asc" : "desc";
    }

    /// <summary>
    /// Sort order for results in the Snipe IT API.
    /// </summary>
    public enum Order
    {
        /// <summary>Order results in an Ascending order.</summary>
        Ascending,
        /// <summary>Order results in an Descending order.</summary>
        Descending
    }
}