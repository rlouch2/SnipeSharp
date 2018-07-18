using System;
using SnipeSharp;

namespace SnipeSharp.PowerShell
{
    internal static class ApiHelper
    {
        private static SnipeItApi _instance = null;
        public static SnipeItApi Instance
        {
            get
            {
                if(_instance == null)
                    throw new InvalidOperationException("Not connected to an instance.");
                else
                    return _instance;
            }

            set
            {
                if(value == null)
                    _instance = null;
                else if(_instance != null)
                    throw new InvalidOperationException("Cannot connect to an instance when already connected.");
                else
                    _instance = value;
            }
        }
    }
}