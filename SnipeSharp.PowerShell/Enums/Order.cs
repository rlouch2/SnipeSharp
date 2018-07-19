namespace SnipeSharp.PowerShell.Enums
{
    internal static class OrderMethods
    {
        public static string ToString(this Order order) => order == Order.Ascending ? "asc" : "desc";
    }

    public enum Order
    {
        Ascending,
        Descending
    }
}