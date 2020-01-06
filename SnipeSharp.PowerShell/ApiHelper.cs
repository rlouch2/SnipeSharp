using System;

namespace SnipeSharp.PowerShell
{
    internal static class ApiHelper
    {
        private static SnipeItApi _instance = null;
        public static SnipeItApi Instance
        {
            get => _instance ?? throw new InvalidOperationException("Not connected to an instance.");
            set
            {
                if(null != value && null != _instance)
                    throw new InvalidOperationException("Cannot connect to an instance when already connected.");
                else
                    _instance = value;
            }
        }
        public static bool HasApiInstance => null != _instance;
        internal static void Reset()
        {
            _instance = null;
            DisableLookupVerification = false;
        }

        public static bool DisableLookupVerification { get; set; } = false;
    }
}
