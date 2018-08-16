using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.PowerShell;
using Microsoft.PowerShell.Commands;
using Xunit;
using POSH = System.Management.Automation;

namespace SnipeSharp.Tests
{
    internal static class PSAssert
    {
        private static POSH.Runspaces.InitialSessionState State
        {
            get
            {
                var state = POSH.Runspaces.InitialSessionState.CreateDefault() ?? throw new Exception("Failed to create initial session state");
                state.LanguageMode = POSH.PSLanguageMode.FullLanguage;
                state.ExecutionPolicy = ExecutionPolicy.RemoteSigned;
                return state;
            }
        }
        internal static List<POSH.ErrorRecord> PSHasErrorRecord(string script)
        {
            var list = new List<POSH.ErrorRecord>();
            using(var posh = POSH.PowerShell
                #if NETCORE
                .Create()
                #else
                .Create(State)
                #endif
                .AddScript($"Import-Module {Path.Combine(Environment.CurrentDirectory, "SnipeSharp.PowerShell.psd1")}").AddScript(script))
            {
                posh.Invoke();
                if(posh.HadErrors)
                    list.AddRange(posh.Streams.Error);
            }
            return list;
        }
    }
}
