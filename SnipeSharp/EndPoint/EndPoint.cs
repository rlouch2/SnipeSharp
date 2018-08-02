using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.EndPoint
{
    public class EndPoint<T> : IEndPoint<T> where T: CommonEndPointModel
    {
        internal readonly SnipeItApiv2 Api;
        internal readonly PathSegmentAttribute EndPointInfo;

        internal EndPoint(SnipeItApiv2 api)
        {
            Api = api;
            EndPointInfo = typeof(T).GetCustomAttribute<PathSegmentAttribute>();
            if(EndPointInfo is null)
                throw new MissingRequiredAttributeException(nameof(PathSegmentAttribute), typeof(T).Name);
        }

        public ResponseCollection<T> FindAll(ISearchFilter filter = null)
            => Api.RequestManager.GetAll<T>(EndPointInfo.BaseUri, filter);

        public T FindOne(ISearchFilter filter)
        {
            filter.Limit = 1;
            return Api.RequestManager.Get<ResponseCollection<T>>(EndPointInfo.BaseUri, filter).FirstOrDefault();
        }

        public T Get(int id)
            => Api.RequestManager.Get<T>($"{EndPointInfo.BaseUri}/{id}");

        public T Get(string name, bool caseSensitive = false)
        {
            if(caseSensitive)
            {
                return FindAll(new SearchFilter(name)).Where(i => i.Name == name).FirstOrDefault();   
            }
            else
            {
                name = name.ToLower();
                return FindAll(new SearchFilter(name)).Where(i => i.Name.ToLower() == name).FirstOrDefault();
            }
        }

        public T Create(T toCreate)
            => Api.RequestManager.Post(EndPointInfo.BaseUri, CheckRequiredFields(toCreate)).Payload;

        public RequestResponse<T> Delete(int id)
            => Api.RequestManager.Delete<T>($"{EndPointInfo.BaseUri}/{id}");

        public T Update(T toUpdate)
            => Api.RequestManager.Patch($"{EndPointInfo.BaseUri}/{toUpdate.Id}", toUpdate).Payload;

        public T this[int id]
            => Get(id);

        public T this[string name, bool caseSensitive = false]
            => Get(name, caseSensitive);

        private T CheckRequiredFields(T @object)
        {
            foreach(var property in typeof(T).GetProperties())
                if((property.GetCustomAttribute<FieldAttribute>()?.IsRequired ?? false) && (property.GetValue(@object) == null)) // if required and null
                        throw new MissingRequiredFieldException<T>(property.Name);
            return @object;
        }
    }
}
