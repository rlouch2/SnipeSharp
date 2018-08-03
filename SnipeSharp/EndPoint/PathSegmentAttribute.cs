using System;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Identifies the base Uri of an <see cref="EndPoint">EndPoint</see> within the Snipe-IT API.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PathSegmentAttribute : Attribute
    {
        /// <value>
        /// The path segment identifying the endpoint in the API.
        /// </value>
        public string BaseUri { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the PathSegmentAttribute class with the specified baseUri.
        /// </summary>
        /// <param name="baseUri">The Uri segment as a string that the endpoint can be found at within the API.</param>
        public PathSegmentAttribute(string baseUri)
        {
            this.BaseUri = baseUri;
        }
    }
}
