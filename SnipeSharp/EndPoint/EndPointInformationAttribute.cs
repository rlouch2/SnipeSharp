using System;

namespace SnipeSharp.EndPoint
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EndPointInformationAttribute : Attribute
    {
        /// <summary>
        /// The base portion of the API, identifying the endpoint.
        /// </summary>
        public string BaseUri { get; private set; }

        /// <summary>
        /// Since the SnipeIT Api uses inconsistent error string to note whether or not an object exists or not, we can use this to declare it.
        /// </summary>
        public string NotFoundMessage { get; private set; }
        
        public EndPointInformationAttribute(string BaseUri, string NotFoundMessage)
        {
            this.BaseUri = BaseUri;
            this.NotFoundMessage = NotFoundMessage;
        }
    }
}