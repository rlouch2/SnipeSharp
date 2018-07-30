using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    public class EndPoint<T> : IEndPoint<T> where T: CommonEndPointModel
    {
        internal readonly SnipeItApiv2 Api;
        internal readonly EndPointInformationAttribute EndPointInfo;

        internal EndPoint(SnipeItApiv2 api)
        {
            Api = api;
            EndPointInfo = typeof(T).GetCustomAttribute<EndPointInformationAttribute>();
            if(EndPointInfo is null)
                throw new MissingRequiredAttributeException(nameof(EndPointInformationAttribute), typeof(T).Name);
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
        {
            throw new System.NotImplementedException();
        }

        public RequestResponse Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T toUpdate)
        {
            throw new System.NotImplementedException();
        }

        public T this[int id]
        {
            get => Get(id);
            set => Update(value); // TODO: is this a good idea?
        }

        public T this[string name, bool caseSensitive = false]
        {
            get => Get(name, caseSensitive);
        }
    }
}