using System;

namespace SnipeSharp.Test
{
    internal static class Utility
    {
        internal static string TEST_URI_STRING { get; } = Environment.GetEnvironmentVariable("SnipeSharp_TestSite") ?? throw new Exception("Could not find environment variable SnipeSharp_TestSite.");
        internal static string TEST_TOKEN { get; } = Environment.GetEnvironmentVariable("SnipeSharp_TestToken") ?? throw new Exception("Could not find environment variable SnipeSharp_TestToken.");
        internal static Uri TEST_URI { get; } = new Uri(TEST_URI_STRING);
    }
}
