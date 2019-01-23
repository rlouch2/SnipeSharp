using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Implements <see cref="IEndPoint{T}" />.
    /// </summary>
    /// <seealso cref="EndPointExtensions" />
    /// <typeparam name="T">A <see cref="Models.CommonEndPointModel">CommonEndPointModel</see> with the <see cref="PathSegmentAttribute">PathSegmentAttribute</see> attribute.</typeparam>
    public class EndPoint<T> : IEndPoint<T>
        where T: CommonEndPointModel
    {
        internal readonly SnipeItApi Api;
        internal readonly PathSegmentAttribute EndPointInfo;

        /// <param name="api">The Api to grab the RequestManager from.</param>
        /// <exception cref="SnipeSharp.Exceptions.MissingRequiredAttributeException">When the type parameter does not have the <see cref="PathSegmentAttribute">PathSegmentAttribute</see> attribute.</exception>
        internal EndPoint(SnipeItApi api)
        {
            Api = api;
            EndPointInfo = typeof(T).GetCustomAttribute<PathSegmentAttribute>();
            if(EndPointInfo is null)
                throw new MissingRequiredAttributeException(nameof(PathSegmentAttribute), typeof(T).Name);
        }

        /// <inheritdoc />
        public ApiOptionalResponse<ResponseCollection<T>> FindAllOptional(ISearchFilter filter = null)
            => Api.RequestManager.GetAll<T>(EndPointInfo.BaseUri, filter);

        /// <inheritdoc />
        public ResponseCollection<T> FindAll(ISearchFilter filter = null)
            => FindAllOptional(filter).RethrowExceptionIfAny().Value;

        /// <inheritdoc />
        public ApiOptionalResponse<ResponseCollection<T>> FindAllOptional(string search)
            => FindAllOptional(new SearchFilter(search));

        /// <inheritdoc />
        public ResponseCollection<T> FindAll(string search)
            => FindAll(new SearchFilter(search));

        /// <inheritdoc />
        public ApiOptionalResponse<T> FindOneOptional(ISearchFilter filter)
        {
            filter.Limit = 1;
            var response = Api.RequestManager.Get<ResponseCollection<T>>(EndPointInfo.BaseUri, filter);
            if(!response.HasValue)
                return new ApiOptionalResponse<T> { Exception = response.Exception };
            return new ApiOptionalResponse<T> { Value = response.Value.FirstOrDefault() };
        }

        /// <inheritdoc />
        public T FindOne(ISearchFilter filter)
            => FindOneOptional(filter).RethrowExceptionIfAny().Value;

        /// <inheritdoc />
        public ApiOptionalResponse<T> FindOneOptional(string search)
            => FindOneOptional(new SearchFilter(search));
        
        /// <inheritdoc />
        public T FindOne(string search)
            => FindOne(new SearchFilter(search));

        /// <inheritdoc />
        public T Get(int id)
            => GetOptional(id).RethrowExceptionIfAny().Value;

        /// <inheritdoc />
        public ApiOptionalResponse<T> GetOptional(int id)
            => Api.RequestManager.Get<T>($"{EndPointInfo.BaseUri}/{id}");
        
        /// <inheritdoc />
        public T Get(string name, bool caseSensitive = false, ISearchFilter filter = null)
            => GetOptional(name, caseSensitive, filter).RethrowExceptionIfAny().Value;

        /// <inheritdoc />
        public ApiOptionalResponse<T> GetOptional(string name, bool caseSensitive = false, ISearchFilter filter = null)
        {
            filter = filter ?? new SearchFilter();
            filter.Search = name;
            var comparer = caseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
            var result = FindAllOptional(filter);
            if(!result.HasValue)
                return new ApiOptionalResponse<T> { Exception = result.Exception };
            return new ApiOptionalResponse<T> { Value = result.Value.Where(i => comparer.Equals(i.Name, name)).FirstOrDefault() };
        }
        
        /// <inheritdoc />
        public ResponseCollection<T> GetAll()
            => FindAll();

        /// <inheritdoc />
        public ApiOptionalResponse<ResponseCollection<T>> GetAllOptional()
            => FindAllOptional();

        /// <inheritdoc />
        public T Create(T toCreate)
            => Api.RequestManager.Post(EndPointInfo.BaseUri, CheckRequiredFields(toCreate, creating: true)).RethrowExceptionIfAny().Value.Payload;

        /// <inheritdoc />
        public RequestResponse<T> Delete(int id)
            => Api.RequestManager.Delete<T>($"{EndPointInfo.BaseUri}/{id}").RethrowExceptionIfAny().Value;

        /// <inheritdoc />
        public T Update(T toUpdate)
            => Api.RequestManager.Patch($"{EndPointInfo.BaseUri}/{toUpdate.Id}", toUpdate).RethrowExceptionIfAny().Value.Payload;

        /// <inheritdoc />
        public T this[int id]
            => Get(id);

        /// <inheritdoc />
        public T this[string name, bool caseSensitive = false, ISearchFilter filter = null]
            => Get(name, caseSensitive, filter);

        private T CheckRequiredFields(T @object, bool creating = false)
        {
            foreach(var property in typeof(T).GetProperties())
                if((property.GetCustomAttribute<FieldAttribute>(true)?.IsRequired ?? false) && (property.GetValue(@object) is null)) // if required and null
                    throw new MissingRequiredFieldException<T>(property.Name);
            return @object;
        }
    }
}
