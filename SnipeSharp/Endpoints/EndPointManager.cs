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
    public class EndPointManager<T> : IEndpointManager<T> where T : CommonEndpointModel
    {
        protected IRequestManager _reqManager;
        protected string _endPoint;
        protected string _notFoundMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqManager"></param>
        /// <param name="endPoint"></param>
        public EndPointManager(IRequestManager reqManager, string endPoint)
        {
            _reqManager = reqManager;
            _endPoint = endPoint;
            var attribute = typeof(T).GetCustomAttributes(typeof(EndpointObjectNotFoundMessage), true).FirstOrDefault() as EndpointObjectNotFoundMessage;
            if(attribute != null)
            {
                _notFoundMessage = attribute.Message;
            }
        }

        /// <summary>
        /// Gets all objects from the endpoint
        /// </summary>
        /// <returns></returns>
        public IResponseCollection<T> GetAll()
        {

            // Figure out how many rows the results will return so we can split up requests
            var count = FindAll(new SearchFilter { Limit = 1 });

            // If there are more than 1000 assets split up the requests to avoid timeouts
            if (count.Total < 1000)
            {
                return FindAll(new SearchFilter { Limit = (int) count.Total });
            } else
            {
                var finalResults = new ResponseCollection<T> {
                    Total = count.Total,
                    Rows = new List<T>()
                };

                var filter = new SearchFilter {
                    Limit = 1000,
                    Offset = 0
                };

                while (finalResults.Rows.Count < count.Total)
                {
                    var batch = FindAll(filter);

                    finalResults.Rows.AddRange(batch.Rows);

                    filter.Offset += 1000;
                }

                return finalResults;
            }
        }


        /// <summary>
        /// Search for Assets that match filters defined in an ISearchFilter object. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IResponseCollection<T> FindAll(ISearchFilter filter)
        {
            var result = PerformLookup<ResponseCollection<T>>(_endPoint, filter);

            var baseOffset = filter.Offset == null ? 0 : filter.Offset;
            // If there is no limit and there are more total than retrieved
            if(filter.Limit == null && baseOffset + result.Rows.Count < result.Total)
            {
                filter.Limit = 1000;
                filter.Offset = baseOffset + result.Rows.Count;
                
                while (baseOffset + result.Rows.Count < result.Total)
                {
                    var batch = PerformLookup<ResponseCollection<T>>(_endPoint, filter);

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
            var result = PerformLookup<ResponseCollection<T>>(_endPoint, filter);
            return (result.Rows != null) ? result.Rows[0] : default(T);
        }

        /// <summary>
        /// Attempts to get a given object by it's ID
        /// </summary>
        /// <param name="id">ID of the object to find</param>
        /// <returns></returns>
        public T Get(int id) => PerformLookup<T>($"{_endPoint}/{id}");

        /// <summary>
        /// Attempts to find a given object by it's name. 
        /// </summary>
        /// <param name="name">The name of the object we want to find</param>
        /// <returns></returns>
        /// 
        public T Get(string name) => Get(name, false);

        /// <summary>
        /// Attempts to find a given object by it's name. 
        /// </summary>
        /// <param name="name">The name of the object we want to find</param>
        /// <param name="caseSensitive">Whether or not to compare names with case in mind</param>
        /// <returns></returns>
        /// 
        public T Get(string name, bool caseSensitive)
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
            var res = _reqManager.Post(_endPoint, toCreate);
            var response = JsonConvert.DeserializeObject<RequestResponse>(res);
            return response;
        }

        public IRequestResponse Update(T toUpdate)
        {
            var response = _reqManager.Put($"{_endPoint}/{toUpdate.Id}", toUpdate);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Delete(int id)
        {
            var response = _reqManager.Delete($"{_endPoint}/{id}");
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Delete(T toDelete) => Delete((int)toDelete.Id);

        /// <summary>
        /// Performs a lookup, returning null if there was an API error.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected R PerformLookup<R>(string path) where R : class
        {
            var response = _reqManager.Get(path);
            return JsonConvert.DeserializeObject<R>(response);
        }

        /// <summary>
        /// Performs a lookup, returning null if there was an API error.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected R PerformLookup<R>(string path, ISearchFilter filter) where R : class
        {
            var response = _reqManager.Get(path, filter);
            return JsonConvert.DeserializeObject<R>(response);
        }
    }
}
