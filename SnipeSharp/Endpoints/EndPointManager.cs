using Newtonsoft.Json;
using SnipeSharp.Attributes;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnipeSharp.Endpoints
{
    /// <summary>
    /// Generic class that can represent each of the different models returned by each endpoint. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EndPointManager<T> : IEndPointManager<T> where T: CommonEndpointModel
    {
        protected IRequestManager RequestManager;
        protected string BaseUri;
        protected string NotFoundMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqManager"></param>
        public EndPointManager(IRequestManager reqManager)
        {
            RequestManager = reqManager;
            var attribute = typeof(T).GetCustomAttributes(typeof(EndPointInformation), true).FirstOrDefault() as EndPointInformation;
            if(attribute != null)
            {
                BaseUri = attribute.BaseUri;
                NotFoundMessage = attribute.NotFoundMessage;
            } else
            {
                throw new ArgumentException($"Generic type {typeof(T).Name} does not have the attribute EndPointInformation");
            }
        }

        /// <summary>
        /// Gets all objects from the endpoint
        /// </summary>
        /// <returns></returns>
        public IResponseCollection<T> GetAll()
        {
            // Let FindAll logic get everything for us.
            return FindAll(null);
        }


        /// <summary>
        /// Search for Assets that match filters defined in an ISearchFilter object. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IResponseCollection<T> FindAll(ISearchFilter filter)
        {
            var result = PerformLookup<ResponseCollection<T>>(BaseUri, filter);

            var baseOffset = filter.Offset == null ? 0 : filter.Offset;
            // If there is no limit and there are more total than retrieved
            if(filter.Limit == null && baseOffset + result.Rows.Count < result.Total)
            {
                filter.Limit = 1000;
                filter.Offset = baseOffset + result.Rows.Count;
                
                while (baseOffset + result.Rows.Count < result.Total)
                {
                    var batch = PerformLookup<ResponseCollection<T>>(BaseUri, filter);

                    result.Rows.AddRange(batch.Rows);

                    filter.Offset += 1000;
                }
            }

            return result;
        }

        /// <summary>
        /// Finds all objects that match the filter and returns the first
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T FindOne(ISearchFilter filter)
        {
            var result = PerformLookup<ResponseCollection<T>>(BaseUri, filter);
            return (result.Rows != null) ? result.Rows[0] : default(T);
        }

        /// <summary>
        /// Attempts to get a given object by it's ID
        /// </summary>
        /// <param name="id">ID of the object to find</param>
        /// <returns></returns>
        public T Get(int id) => PerformLookup<T>($"{BaseUri}/{id}");

        /// <summary>
        /// Attempts to find a given object by it's name. 
        /// </summary>
        /// <param name="name">The name of the object we want to find</param>
        /// <param name="caseSensitive">Whether or not to compare names with case in mind</param>
        /// <returns></returns>
        /// 
        public T Get(string name, bool caseSensitive = false)
        {
            var list = FindAll(new SearchFilter {
                Search = name
            }).Rows;

            if(caseSensitive)
                return list.Where(i => i.Name == name).FirstOrDefault();
            else
            {
                var lowerName = name.ToLower();
                return list.Where(i => i.Name.ToLower() == lowerName).FirstOrDefault();
            }
        }

        /// <summary>
        /// Creates a new object from the provided CommonResponseObject
        /// </summary>
        /// <param name="toCreate"></param>
        /// <returns></returns>
        public IRequestResponse Create(T toCreate)
        {
            var res = RequestManager.Post(BaseUri, toCreate);
            var response = JsonConvert.DeserializeObject<RequestResponse>(res);
            return response;
        }

        public IRequestResponse Update(T toUpdate)
        {
            var response = RequestManager.Put($"{BaseUri}/{toUpdate.Id}", toUpdate);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Delete(int id)
        {
            var response = RequestManager.Delete($"{BaseUri}/{id}");
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Delete(T toDelete) => Delete((int)toDelete.Id);

        /// <summary>
        /// Performs a lookup, returning default(R) if there was an API error.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected R PerformLookup<R>(string path, ISearchFilter filter = null) where R : class
        {
            var response =  filter == null ? RequestManager.Get(path) : RequestManager.Get(path, filter);
            // Parse the response as a message to see if there's a result.
            var message = JsonConvert.DeserializeObject<RequestResponse>(response);
            // If there isn't a result, return default(T).
            if(message.Status == "error" && message.Messages.ContainsKey("general") && message.Messages["general"] == NotFoundMessage)
            {
                return default(R);
            }
            // We do have one, so re-deserialize the response as the type we want.
            return JsonConvert.DeserializeObject<R>(response);
        }
    }
}
