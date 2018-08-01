using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;

namespace SnipeSharp.EndPoint
{
    public interface IEndPoint<T>
    {
        T Create(T toCreate);
        T Update(T toUpdate);
        RequestResponse Delete(int id);
        T Get(int id);
        T Get(string name, bool caseSensitive = false);
        ResponseCollection<T> FindAll(ISearchFilter filter = null);
        T FindOne(ISearchFilter filter);
        T this[int id] { get; }
        T this[string name, bool caseSensitive = false] { get; }
    }
}