using System;

namespace SnipeSharp.EndPoint
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PathSegmentAttribute : Attribute
    {
        /// <summary>
        /// The path segment identifying the endpoint in the API.
        /// </summary>
        public string BaseUri { get; private set; }
        
        public PathSegmentAttribute(string BaseUri)
        {
            this.BaseUri = BaseUri;
        }
    }
}