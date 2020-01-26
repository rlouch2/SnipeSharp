namespace SnipeSharp.Models
{
    /// <summary>
    /// <para>ApiObject is the base class for all classes used for interacting with the API.</para>
    /// <para>It serves as a common root for all objects except for search filters, which extend from <see cref="SnipeSharp.Filters.ISearchFilter" />.</para>
    /// </summary>
    public class ApiObject
    {
        // just so there's a base between requestresponse and AbstractBaseModel
    }
}
