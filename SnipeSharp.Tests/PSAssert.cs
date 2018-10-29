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
            ExecuteScript(script, out _, out var errors);
            return errors;
        }

        internal static List<POSH.PSObject> PSHasOutput(string script)
        {
            ExecuteScript(script, out var output, out _);
            return output;
        }

        private static void ExecuteScript(string script, out List<POSH.PSObject> output, out List<POSH.ErrorRecord> errors)
        {
            errors = new List<POSH.ErrorRecord>();
            output = new List<POSH.PSObject>();
            using(var posh = POSH.PowerShell
                #if NETCORE
                .Create()
                #else
                .Create(State)
                #endif
                .AddScript($"Import-Module {Path.Combine(Environment.CurrentDirectory, "SnipeSharp.PowerShell.psd1")}").AddScript(script))
            {
                output.AddRange(posh.Invoke());
                if(posh.HadErrors)
                    errors.AddRange(posh.Streams.Error);
            }
        }
    }
}
