using System;
using System.Collections.Generic;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// A contract all EndPoints must follow.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEndPoint<T> where T: ApiObject
    {
        /// <summary>
        /// Create a new object of the generic type.
        /// </summary>
        /// <param name="toCreate">An instance of the generic type with serializable fields.</param>
        /// <returns>A stub of the object, indicating that the creation was successful.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">When the request was not successful.</exception>
        T Create(T toCreate);

        /// <summary>
        /// Update an existing object of the generic type.
        /// </summary>
        /// <param name="toUpdate">An instance of the generic type with serializable fields.</param>
        /// <returns>A stub of the object, indicating that the update was successful.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">When the request was not successful.</exception>
        T Update(T toUpdate);

        /// <summary>
        /// Delete an object of the generic type by Id.
        /// </summary>
        /// <param name="id">The Id of an object of the generic type.</param>
        /// <returns>A response indicating that the deletion was successful.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">When the request was not successful.</exception>
        RequestResponse<T> Delete(int id);

        /// <summary>
        /// Get an object of the generic type by Id.
        /// </summary>
        /// <param name="id">The Id of the object to fetch from the EndPoint.</param>
        /// <returns>The object with the supplied Id.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">When the request was not successful or the object does not exist.</exception>
        T Get(int id);

        /// <summary>
        /// Get an object of the generic type by Id.
        /// </summary>
        /// <param name="id">The Id of the object to fetch from the EndPoint.</param>
        /// <returns>The object with the supplied Id (or null) in a tuple with an error thrown (which is null if there was no error).</returns>
        (T Value, Exception Error) GetOrNull(int id);

        /// <summary>
        /// Get an object of the generic type by Name.
        /// </summary>
        /// <param name="name">The name of the object to fetch from the EndPoint.</param>
        /// <param name="caseSensitive">If true, perform a case-sensitive match. Default false.</param>
        /// <returns>The object with the supplied name, or null if it does not exist.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">When the request was not successful.</exception>
        T Get(string name, bool caseSensitive = false);

        /// <summary>
        /// Get an object of the generic type by Name.
        /// </summary>
        /// <param name="name">The name of the object to fetch from the EndPoint.</param>
        /// <param name="caseSensitive">If true, perform a case-sensitive match. Default false.</param>
        /// <returns>The object with the supplied name (or null) in a tuple with an error thrown (which is null if there was no error).</returns>
        (T Value, Exception Error) GetOrNull(string name, bool caseSensitive = false);

        /// <summary>
        /// Finds all objects of the generic type matching the filter.
        /// </summary>
        /// <param name="filter">The filter to search by.</param>
        /// <returns>A collection of relevant objects, which may be empty.</returns>
        ResponseCollection<T> FindAll(ISearchFilter filter = null);

        /// <summary>
        /// Finds all objects of the generic type matching the search string.
        /// </summary>
        /// <param name="search">The search string to filter by.</param>
        /// <returns>A collection of relevant objects, which may be empty.</returns>
        ResponseCollection<T> FindAll(string search);

        /// <summary>
        /// Gets all objects in the EndPoint.
        /// </summary>
        /// <returns>A collection of relevant objects, which may be empty.</returns>
        /// <remarks>It is recommended that implementations simply wrap <see cref="FindAll(ISearchFilter)"/>.</remarks>
        ResponseCollection<T> GetAll();

        /// <summary>
        /// Gets all objects in the EndPoint.
        /// </summary>
        /// <returns>A collection of relevant objects (or null), which may be empty, in a tuple with an error thrown (which is null if there was no error).</returns>
        (ResponseCollection<T> Value, Exception Error) GetAllOrNull();

        /// <summary>
        /// Finds the first object of the generic type matching the filter.
        /// </summary>
        /// <param name="filter">The filter to search by. The limit will be forced to 1.</param>
        /// <returns>The relevant object, or null if no object was found matching the filter.</returns>
        T FindOne(ISearchFilter filter);

        /// <summary>
        /// Finds the first object of the generic type matching the search string.
        /// </summary>
        /// <param name="search">The search string to filter by.</param>
        /// <returns>The relevant object, or null if no object was found matching the filter.</returns>
        T FindOne(string search);

        /// <value>Gets an object by Id.</value>
        /// <seealso cref="Get(int)" />
        T this[int id] { get; }

        /// <value>Gets an object by name.</value>
        /// <seealso cref="Get(string,bool)" />
        T this[string name, bool caseSensitive = false] { get; }
    }
}
