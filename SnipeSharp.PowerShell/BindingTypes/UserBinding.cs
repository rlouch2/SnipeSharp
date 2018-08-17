using System;
using System.Collections.Generic;
using SnipeSharp.Models;
using static SnipeSharp.EndPoint.EndPointExtensions;

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
        public UserBinding(string query)
        {
            Query = query;
            var (type, value) = ParseQuery(query);
            var endPoint = ApiHelper.Instance.GetEndPoint<User>();
            if(type is null)
            {
                // username -> email -> name -> id
                (Object, Error) = endPoint.GetByUserNameOrNull(value);
                if(!(Object is null))
                    return;
                (Object, Error) = endPoint.GetByEmailAddressOrNull(value);
                if(!(Object is null))
                    return;
                (Object, Error) = endPoint.GetOrNull(value);
                if(Object is null && int.TryParse(value, out var id))
                    (Object, Error) = endPoint.GetOrNull(id);
                else
                    Error = new ArgumentException($"Cannot find an object for query: {value}", nameof(query));
            } else
            {
                switch(type)
                {
                    case "cname":
                        (Object, Error) = endPoint.GetOrNull(value, true);
                        break;
                    case "name":
                    case "iname":
                        (Object, Error) = endPoint.GetOrNull(value, false);
                        break;
                    case "id":
                        if(int.TryParse(value, out var id))
                            (Object, Error) = endPoint.GetOrNull(id);
                        else
                        {
                            Error = new ArgumentException($"Id is not an integer: {value}", nameof(query));
                            return;
                        }
                        break;
                    case "username":
                    case "uname":
                        (Object, Error) = endPoint.GetByUserNameOrNull(value);
                        break;
                    case "email":
                        (Object, Error) = endPoint.GetByEmailAddressOrNull(value);
                        break;
                    case "search":
                        try
                        {
                            Object = endPoint.FindOne(value);
                        } catch(Exception e)
                        {
                            Error = e;
                            return;
                        }
                        break;
                    default:
                        Error = new ArgumentException($"Query does not have a proper type: {type}", nameof(query));
                        return;
                }
                if(Object is null)
                    try
                    {
                        Object = endPoint.FindOne(value);
                    } catch(Exception e)
                    {
                        Error = e;
                    }
            }
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

        internal static UserBinding FromUserName(string username)
            => new UserBinding(username, ApiHelper.Instance.Users.GetByUserNameOrNull(username));
        internal new static UserBinding FromId(int id)
            => new UserBinding(id);
        internal new static UserBinding FromName(string name)
            => new UserBinding(name, ApiHelper.Instance.Users.GetOrNull(name));
        internal static UserBinding FromEmailAddress(string email)
            => new UserBinding(email, ApiHelper.Instance.Users.GetByEmailAddressOrNull(email));
    }
}
