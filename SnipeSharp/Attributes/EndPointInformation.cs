using System;

namespace SnipeSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EndPointInformation : Attribute
    {
        /// <summary>
        /// The base portion of the API, identifying the endpoint.
        /// </summary>
        public string BaseUri { get; private set; }

        /// <summary>
        /// Since the SnipeIT Api uses inconsistent error string to note whether or not an object exists or not, we can use this to declare it.
        /// </summary>
        public string NotFoundMessage { get; private set; }
        
        public EndPointInformation(string BaseUri, string NotFoundMessage)
        {
            this.BaseUri = BaseUri;
            this.NotFoundMessage = NotFoundMessage;
        }
    }
}
