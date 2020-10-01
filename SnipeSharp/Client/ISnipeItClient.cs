using System;
using SnipeSharp.Filters;
using SnipeSharp.Models;

#nullable enable
namespace SnipeSharp.Client
{
    public interface ISnipeItClient
    {
        string Token { set; }
        Uri Uri { set; }

        bool HasToken { get; }
        bool HasUri { get; }

        string GetRaw(string relativePath);

        ApiOptionalResponse<R> Get<R>(string relativePath, ISearchFilter? filter = null)
            where R: ApiObject;
        ApiOptionalMultiResponse<R> GetMultiple<R>(string relativePath, ISearchFilter? filter = null)
            where R: ApiObject;

        ApiOptionalResponse<RequestResponse<R>> Post<R>(string relativePath, R obj)
            where R: ApiObject;

        ApiOptionalResponse<RequestResponse<R>> Post<T, R>(string relativePath, T obj)
            where T: ApiObject
            where R: ApiObject;

        ApiOptionalResponse<RequestResponse<R>> Put<R>(string relativePath, R obj)
            where R: ApiObject;

        ApiOptionalResponse<RequestResponse<R>> Patch<R>(string relativePath, R obj)
            where R: ApiObject;

        ApiOptionalResponse<RequestResponse<R>> Delete<R>(string relativePath)
            where R: ApiObject;
    }
}
