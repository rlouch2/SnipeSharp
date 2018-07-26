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

        public IList<T> FindAll(ISearchFilter filter = null)
        {
            var result = Api.RequestManager.Get<ResponseCollection<T>>(EndPointInfo.BaseUri, filter);
            var offset = filter?.Offset == null ? 0 : filter.Offset;
            if(filter?.Limit == null && offset + result.Count < result.Total)
            {
                if(filter == null)
                    filter = new SearchFilter();
                filter.Limit = 1000;
                filter.Offset = offset + result.Count;
                while(offset + result.Count < result.Total)
                {
                    var batch = Api.RequestManager.Get<ResponseCollection<T>>(EndPointInfo.BaseUri, filter);
                    result.AddRange(batch);
                    filter.Offset += 1000;
                }
            }
            return result;
        }

        public T FindOne(ISearchFilter filter)
        {
            filter.Limit = 1;
            return Api.RequestManager.Get<ResponseCollection<T>>(EndPointInfo.BaseUri, filter).FirstOrDefault();
        }

        public T Get(int id) => Api.RequestManager.Get<T>($"{EndPointInfo.BaseUri}/{id}");

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
    }
}