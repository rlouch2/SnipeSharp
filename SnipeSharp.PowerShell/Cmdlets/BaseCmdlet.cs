using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using System;
using SnipeSharp.Exceptions;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Base class for most cmdlets, providing common functionality.
    /// </summary>
    public abstract class BaseCmdlet: PSCmdlet
    {
        /// <summary>
        /// Write a "Not found" error.
        /// </summary>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <param name="exception">Any exception to include?</param>
        /// <typeparam name="T">The type of object being retrieved.</typeparam>
        protected void WriteNotFoundError<T>(string queryType, string value, Exception exception = null)
        {
            var message = $"{typeof(T).Name} not found by {queryType} \"{value}\"";
            WriteError(new ErrorRecord(exception ?? new ApiErrorException(message), message, ErrorCategory.InvalidArgument, value));
        }

        /// <summary>
        /// Write a "Too many found" error.
        /// </summary>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <typeparam name="T">The type of object being retrieved.</typeparam>
        protected void WriteTooManyFoundError<T>(string queryType, string value)
        {
            var message = $"Too many {typeof(T).Name} found by {queryType} \"{value}\"";
            WriteError(new ErrorRecord(new ApiErrorException(message), message, ErrorCategory.InvalidArgument, value));
        }

        /// <summary>
        /// Write an exception out.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="category">The error category.</param>
        /// <param name="target">The object being operated on.</param>
        protected void WriteApiError(Exception exception, ErrorCategory category = ErrorCategory.NotSpecified, object target = null)
        {
            WriteError(new ErrorRecord(exception, exception.Message, category, target));
        }

        /// <summary>
        /// Validate that a binding has one and exactly one value.
        /// </summary>
        /// <param name="binding">The binding to validate.</param>
        /// <param name="queryType">What type of query was it?</param>
        /// <param name="value">What was the query value?</param>
        /// <typeparam name="T">The type of object the binding is for.</typeparam>
        /// <returns>True if the binding is valid, else false.</returns>
        protected bool ValidateHasExactlyOneValue<T>(ObjectBinding<T> binding, string queryType = "query", string value = null)
            where T : CommonEndPointModel
        {
            value = value ?? binding.Query;
            if(!binding.HasValue)
            {
                WriteNotFoundError<T>(queryType, value, binding.Error);
                return false;
            }
            if(binding.Value.Count > 1)
            {
                WriteTooManyFoundError<T>(queryType, value);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Retrieve a single value from a binding.
        /// </summary>
        /// <param name="binding">The binding to use.</param>
        /// <param name="value">The value to output.</param>
        /// <param name="queryType">The type of query.</param>
        /// <param name="queryValue">The value of the query.</param>
        /// <param name="required">Are null returns disallowed? (Does the binding have to have a value?)</param>
        /// <typeparam name="R">The type of object to retrieve</typeparam>
        /// <returns>True if a valid value was retrieved.</returns>
        protected bool GetSingleValue<R>(ObjectBinding<R> binding, out R value, string queryType = "identity", string queryValue = null, bool required = false)
            where R : CommonEndPointModel
        {
            value = null;
            if (null == binding)
            {
                if(!required) // let us return null if a value wasn't required and we don't have a binding.
                    return true;
                WriteApiError(new ArgumentNullException(paramName: nameof(binding)));
                return false;
            }
            if(null != binding.Error)
            {
                WriteApiError(binding.Error, target: binding.Query.ToString());
                return false;
            }
            if(!binding.HasValue && !required) // let us return nulls if we don't need a value
                return true;
            if (ValidateHasExactlyOneValue(binding, queryType, queryValue))
            {
                value = binding.Value[0];
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieve many values from an array of bindings.
        /// </summary>
        /// <param name="bindings">The bindings to use.</param>
        /// <param name="values">The value to output.</param>
        /// <param name="queryType">The type of query.</param>
        /// <param name="queryValue">The value of the query.</param>
        /// <param name="required">Are null returns disallowed? (Does the binding have to have a value?)</param>
        /// <typeparam name="R">The type of object to retrieve</typeparam>
        /// <returns>True if all valid values were retrieved; false if any binding was not resolved.</returns>
        protected bool GetManyValues<R>(ObjectBinding<R>[] bindings, out ResponseCollection<R> values, string queryType = "identity", string queryValue = null, bool required = false)
            where R: CommonEndPointModel
        {
            var result = true;
            values = new ResponseCollection<R>();
            foreach(var binding in bindings)
                if(result = GetSingleValue(binding, out var value, queryType, queryValue, required) && result)
                    values.Add(value);
            if(!result)
                values = null;
            return result;
        }
    }
}
