using System;

namespace SnipeSharp.PowerShell
{
    public static class ApiHelper
    {
        private static SnipeItApi _instance = null;
        public static SnipeItApi Instance
        {
            get => _instance ?? throw new InvalidOperationException("Not connected to an instance.");
            set
            {
                if(value != null && _instance != null)
                    throw new InvalidOperationException("Cannot connec to an instance when already connected.");
                else
                    _instance = value;
            }
        }
    }
}