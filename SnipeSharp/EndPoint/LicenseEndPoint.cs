using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    public sealed class LicenseEndPoint : EndPoint<License>
    {
        // TODO: docs
        internal LicenseEndPoint(SnipeItApi api) : base(api) {}

        /// <summary>
        /// Get details for the license seats of a license.
        /// </summary>
        /// <param name="license">A license to get the details of.</param>
        /// <returns>A ResponseCollection of LicenseSeats.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the license does not exist.</exception>
        public ResponseCollection<LicenseSeat> GetSeats(License license)
            => Api.RequestManager.GetAll<LicenseSeat>($"{EndPointInfo.BaseUri}/{license.Id}/seats").RethrowExceptionIfAny().Value;
    }
}
