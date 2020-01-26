using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell
{
    internal static class CmdletUtility
    {
        /// <summary>
        /// Write a "Not found" error.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <param name="exception">Any exception to include?</param>
        /// <typeparam name="T">The type of object being retrieved.</typeparam>
        internal static void WriteNotFoundError<T>(this Cmdlet cmdlet, string queryType, string value, Exception exception = null)
        {
            var message = $"{typeof(T).Name} not found by {queryType} \"{value}\"";
            cmdlet.WriteError(new ErrorRecord(exception ?? new ApiErrorException(message), message, ErrorCategory.InvalidArgument, value));
        }

        /// <summary>
        /// Write a "Too many found" error.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <typeparam name="T">The type of object being retrieved.</typeparam>
        internal static void WriteTooManyFoundError<T>(this Cmdlet cmdlet, string queryType, string value)
        {
            var message = $"Too many {typeof(T).Name} found by {queryType} \"{value}\"";
            cmdlet.WriteError(new ErrorRecord(new ApiErrorException(message), message, ErrorCategory.InvalidArgument, value));
        }

        /// <summary>
        /// Write an exception out.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="category">The error category.</param>
        /// <param name="target">The object being operated on.</param>
        internal static void WriteApiError(this Cmdlet cmdlet, Exception exception, ErrorCategory category = ErrorCategory.NotSpecified, object target = null)
        {
            cmdlet.WriteError(new ErrorRecord(exception, exception.Message, category, target));
        }

        /// <summary>
        /// Validate that a binding has one and exactly one value.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="binding">The binding to validate.</param>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <typeparam name="T">The type of object the binding is for.</typeparam>
        /// <returns>True if the binding is valid, else false.</returns>
        internal static bool ValidateHasExactlyOneValue<T>(this Cmdlet cmdlet, ObjectBinding<T> binding, string queryType = "query", string value = null)
            where T : AbstractBaseModel, new()
        {
            value = value ?? binding.Query;
            if(!binding.HasValue)
            {
                cmdlet.WriteNotFoundError<T>(queryType, value, binding.Error);
                return false;
            }
            if(binding.Value.Count > 1)
            {
                cmdlet.WriteTooManyFoundError<T>(queryType, value);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that a collection of items has one and exactly one value.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="items">The collection of items to validate.</param>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <typeparam name="T">The type of object the binding is for.</typeparam>
        /// <returns>True if the binding is valid, else false.</returns>
        internal static bool ValidateHasExactlyOneValue<T>(this Cmdlet cmdlet, IReadOnlyCollection<T> items, string queryType = "query", string value = null)
            where T : AbstractBaseModel, new()
        {
            if(0 == items.Count)
            {
                cmdlet.WriteNotFoundError<T>(queryType, value);
                return false;
            }
            if(items.Count > 1)
            {
                cmdlet.WriteTooManyFoundError<T>(queryType, value);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Retrieve a single value from a binding.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="binding">The binding to use.</param>
        /// <param name="value">The value to output.</param>
        /// <param name="queryType">The type of query.</param>
        /// <param name="queryValue">The value of the query.</param>
        /// <typeparam name="R">The type of object to retrieve</typeparam>
        /// <returns>True if a valid value was retrieved.</returns>
        internal static bool GetSingleValue<R>(this Cmdlet cmdlet, ObjectBinding<R> binding, out R value, string queryType = "identity", string queryValue = null)
            where R : AbstractBaseModel, new()
        {
            value = null;
            if (null == binding)
            {
                cmdlet.WriteApiError(new ArgumentNullException(paramName: nameof(binding)));
                return false;
            }
            if(null != binding.Error)
            {
                cmdlet.WriteApiError(binding.Error, target: binding.Query.ToString());
                return false;
            }
            if (cmdlet.ValidateHasExactlyOneValue(binding, queryType, queryValue))
            {
                value = binding.Value[0];
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieve many values from an array of bindings.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to operate on.</param>
        /// <param name="bindings">The bindings to use.</param>
        /// <param name="values">The value to output.</param>
        /// <param name="queryType">The type of query.</param>
        /// <param name="queryValue">The value of the query.</param>
        /// <typeparam name="R">The type of object to retrieve</typeparam>
        /// <returns>True if all valid values were retrieved; false if any binding was not resolved.</returns>
        internal static bool GetManyValues<R>(this Cmdlet cmdlet, ObjectBinding<R>[] bindings, out ResponseCollection<R> values,
                                                string queryType = "identity", string queryValue = null)
            where R: AbstractBaseModel, new()
        {
            var result = true;
            values = new ResponseCollection<R>();
            foreach(var binding in bindings)
            {
                result = cmdlet.GetSingleValue(binding, out var value, queryType, queryValue) && result;
                if(result)
                    values.Add(value);
            }
            if(!result)
                values = null;
            return result;
        }
    }
}
