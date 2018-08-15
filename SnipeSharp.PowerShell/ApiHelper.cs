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
                if(!(value is null) && !(_instance is null))
                    throw new InvalidOperationException("Cannot connec to an instance when already connected.");
                else
                    _instance = value;
            }
        }
    }
}
