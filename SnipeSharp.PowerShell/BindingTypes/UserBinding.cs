using System;
using System.Collections.Generic;
using SnipeSharp;
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
        internal UserBinding(string query, (User, Exception) item): base(query, item)
        {
        }

                /// <inheritdoc />
        protected override (User, Exception) ResolveBinding(ISearchFilter filter = null)
        {
            var endPoint = ApiHelper.Instance.GetEndPoint<User>();
            (User Object, Exception Error) result;
            var userFilter = filter as UserSearchFilter;

            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);
                    
                    if(type is null)
                    {
                        // username -> email -> name -> id
                        result = endPoint.GetByUserNameOrNull(value, userFilter);
                        if(null != result.Object)
                            return result;
                        result = endPoint.GetByEmailAddressOrNull(value, userFilter);
                        if(null != result.Object)
                            return result;
                        result = endPoint.GetOrNull(value, QueryUnion.CaseSensitive);
                        if(null != result.Object)
                            return result;
                        else if(int.TryParse(value, out var id))
                            return endPoint.GetOrNull(id);
                        else
                            return (null, new ArgumentException($"Cannot find an object for query: {value}", "query"));
                    } else
                    {
                        switch(type)
                        {
                            case "cname":
                                QueryUnion.CaseSensitive = true;
                                goto case "iname";
                            case "name":
                            case "iname":
                                result = endPoint.GetOrNull(value, QueryUnion.CaseSensitive, filter);
                                break;
                            case "id":
                                if(int.TryParse(value, out var id))
                                    result = endPoint.GetOrNull(id);
                                else
                                    return (null, new ArgumentException($"Id is not an integer: {value}", "query"));
                                break;
                            case "username":
                            case "uname":
                                result = endPoint.GetByUserNameOrNull(value, userFilter);
                                break;
                            case "email":
                                result = endPoint.GetByEmailAddressOrNull(value, userFilter);
                                break;
                            case "search":
                                try
                                {
                                    result = (endPoint.FindOne(value), null);
                                } catch(Exception e)
                                {
                                    return (null, e);
                                }
                                break;
                            default:
                                return (null, new ArgumentException($"Query does not have a proper type: {type}", "query"));
                        }
                        if(result.Object is null)
                            try
                            {
                                return (endPoint.FindOne(value), null);
                            } catch(Exception e)
                            {
                                return (null, e);
                            }
                        else
                            return result;
                    }
                case BindingQueryUnion.Type.Integer:
                    return endPoint.GetOrNull(QueryUnion.IntegerValue);
                default:
                    return (null, new InvalidOperationException("Cannot resolve an invalid binding."));
            }
        }

        internal static UserBinding FromUserName(string username, UserSearchFilter filter = null)
            => new UserBinding(username, ApiHelper.Instance.Users.GetByUserNameOrNull(username, filter));
        internal new static UserBinding FromId(int id)
            => new UserBinding(id);
        internal new static UserBinding FromName(string name)
            => new UserBinding(name, ApiHelper.Instance.Users.GetOrNull(name));
        internal static UserBinding FromEmailAddress(string email, UserSearchFilter filter = null)
            => new UserBinding(email, ApiHelper.Instance.Users.GetByEmailAddressOrNull(email, filter));
        
        internal static UserBinding Me()
        {
            User me;
            try
            {
                me = ApiHelper.Instance.Users.Me();
                return new UserBinding(me.UserName, (me, null));
            } catch (Exception e)
            {
                return new UserBinding(string.Empty, (null, e));
            }
        }
    }
}
