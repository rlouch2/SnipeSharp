using System;
using System.Collections.Generic;
using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Used to convert a User identity into a User object.
    /// </summary>
    public sealed class UserBinding: ObjectBinding<User>
    {
        /// <summary>
        /// Fetches a single User by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a user.</param>
        public UserBinding(int id) : base(id)
        {
        }

        /// <summary>
        /// Fetches a single User using a simplified query. The query is of the form "[type:]value". Valid types are: id, name, iname, cname, username, uname, email, and search.
        /// </summary>
        /// <param name="query">A User Name, Id, Email Address, UserName, or Search for a user.</param>
        public UserBinding(string query) : base(query)
        {
        }

        /// <summary>
        /// Fetches a User by name, optionally case-sensitive.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="caseSensitive">Whether or not to be case-sensitive in the search (default false).</param>
        public UserBinding(string name, bool caseSensitive = false): base(name, caseSensitive)
        {
        }

        /// <summary>
        /// Re-fetches a User by its internal Id.
        /// </summary>
        /// <param name="user">An User object.</param>
        public UserBinding(User user) : base(user)
        {
        }

        /// <summary>
        /// For use with the internal From* functions.
        /// </summary>
        internal UserBinding(string query, ApiOptionalResponse<User> apiOptionalResponse): base(query, apiOptionalResponse)
        {
        }

        /// <inheritdoc />
        internal override void Resolve(ISearchFilter filter = null)
        {
            if(null != _objects)
                return;
            try
            {
                var endPoint = ApiHelper.Instance.Users;
                if(BindingType.Integer == QueryUnion.Type)
                {
                    var result = endPoint.GetOptional(QueryUnion.IntegerValue);
                    Value = result.HasValue ? new User[] { result.Value } : new User[0];
                    Error = result.Exception;
                } else if(BindingType.String == QueryUnion.Type)
                {
                    int id; // used later for parsing integers
                    ApiOptionalResponse<User> result;
                    var userFilter = filter as UserSearchFilter ?? new UserSearchFilter();
                    switch(ParseQuery(QueryUnion.StringValue, out var tag, out var value))
                    {
                        case BindingQueryType.Absent:
                            // username -> email -> name -> id
                            result = endPoint.GetByUserNameOptional(value, userFilter);
                            if(result.HasValue)
                                break;
                            result = endPoint.GetByEmailAddressOptional(value, userFilter);
                            if(result.HasValue)
                                break;
                            result = endPoint.GetOptional(value, QueryUnion.CaseSensitive);
                            if(result.HasValue)
                                break;
                            else if(int.TryParse(value, out id))
                                result = endPoint.GetOptional(id);
                            else
                                // fall back to search as the last-ditch try.
                                goto case BindingQueryType.Search;
                            break;
                        case BindingQueryType.CaseSensitiveName:
                            QueryUnion.CaseSensitive = true;
                            goto case BindingQueryType.CaseInsensitiveName;
                        case BindingQueryType.CaseInsensitiveName:
                            result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                            break;
                        case BindingQueryType.Id:
                            if(int.TryParse(value, out id))
                                result = endPoint.GetOptional(id);
                            else
                                result = new ApiOptionalResponse<User> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                            break;
                        case BindingQueryType.UserName:
                            result = endPoint.GetByUserNameOptional(value, userFilter);
                            break;
                        case BindingQueryType.Email:
                            result = endPoint.GetByEmailAddressOptional(value, userFilter);
                            break;
                        default:
                            // by default, try searching for the whole thing
                        case BindingQueryType.Search:
                            filter.Search = value;
                            var allResults = endPoint.FindAllOptional(filter);
                            Error = allResults.Exception;
                            Value = allResults.HasValue ? allResults.Value : (IReadOnlyList<User>)new User[0];
                            return;
                    }
                    Value = result.HasValue ? new User[] { result.Value } : new User[0];
                    Error = result.Exception;
                } else
                {
                    Value = new User[0];
                    Error = new InvalidOperationException("Cannot resolve an invalid binding.");
                }
            } catch(Exception ex)
            {
                // let later error-handling mechanisms deal with any errors we encountered.
                Value = new User[0];
                Error = ex;
            }
        }

        internal static UserBinding FromUserName(string username, UserSearchFilter filter = null)
            => new UserBinding(username, ApiHelper.Instance.Users.GetByUserNameOptional(username, filter));
        internal static UserBinding FromEmailAddress(string email, UserSearchFilter filter = null)
            => new UserBinding(email, ApiHelper.Instance.Users.GetByEmailAddressOptional(email, filter));

        internal static UserBinding Me()
        {
            var me = ApiHelper.Instance.Users.MeOptional();
            return new UserBinding(me.HasValue ? me.Value.UserName : string.Empty, me);
        }
    }
}
