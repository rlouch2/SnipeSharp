using System;
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
            var endPoint = ApiHelper.Instance.Users;
            ApiOptionalResponse<User> result;
            var userFilter = filter as UserSearchFilter;

            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);

                    if(null == type)
                    {
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
                        else if(int.TryParse(value, out var id))
                            result = endPoint.GetOptional(id);
                        else
                            result = new ApiOptionalResponse<User> { Exception = new ArgumentException($"Cannot find an object for query: {value}", "query") };
                    } else
                    {
                        switch(type)
                        {
                            case "cname":
                                QueryUnion.CaseSensitive = true;
                                goto case "iname";
                            case "name":
                            case "iname":
                                result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                                break;
                            case "id":
                                if(int.TryParse(value, out var id))
                                    result = endPoint.GetOptional(id);
                                else
                                    result = new ApiOptionalResponse<User> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                                break;
                            case "username":
                            case "uname":
                                result = endPoint.GetByUserNameOptional(value, userFilter);
                                break;
                            case "email":
                                result = endPoint.GetByEmailAddressOptional(value, userFilter);
                                break;
                            case "search":
                                try
                                {
                                    result = endPoint.FindOneOptional(value);
                                } catch(Exception e)
                                {
                                    result = new ApiOptionalResponse<User> { Exception = e };
                                }
                                break;
                            default:
                                result = new ApiOptionalResponse<User> { Exception = new ArgumentException($"Query does not have a proper type: {type}", "query") };
                                break;
                        }
                        if(null == result.Value)
                        {
                            try
                            {
                                result = endPoint.FindOneOptional(value);
                            } catch(Exception e)
                            {
                                result = new ApiOptionalResponse<User> { Exception = e };
                            }
                        }
                    }
                    break;
                case BindingQueryUnion.Type.Integer:
                    result = endPoint.GetOptional(QueryUnion.IntegerValue);
                    break;
                default:
                    result = new ApiOptionalResponse<User> { Exception = new InvalidOperationException("Cannot resolve an invalid binding.") };
                    break;
            }

            Value = new User[] { result.Value };
            Error = result.Exception;
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
