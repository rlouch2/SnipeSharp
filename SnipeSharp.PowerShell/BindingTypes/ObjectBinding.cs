using System;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell;

namespace  SnipeSharp.PowerShell.BindingTypes
{
    public class ObjectBinding<T> where T: CommonEndPointModel
    {
        public T Object { get; protected set; }
        public string Query { get; protected set; }

        public ObjectBinding(int id)
        {
            Query = $"id:{id}"
            Object = ApiHelper.Instance.GetEndPoint<T>().Get(id);
        }

        public ObjectBinding(string name, bool caseSensitive = false)
        {
            Query = query;
            Object = ApiHelper.Instance.GetEndPoint<T>().Get(name, caseSensitive);
            if(Object == null)
                throw new ArgumentException($"Query \"{query}\" could not find an object of type {typeof(T).Name}");
        }

        public ObjectBinding(T @object)
        {
            Query = $"object:{@object.Id}";
            Object = ApiHelper.Instance.GetEndPoint<T>().Get(@object.Id);
        }
    }
}
