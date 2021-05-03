using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class ReportEndPoint
    {
        private readonly SnipeItApi Api;

        internal ReportEndPoint(SnipeItApi api)
            => Api = api;

        //public Task<DataTable<ActionLog>?> GetActivityReportAsync() => GetActivityReportAsync(new BasicFilter<ActionLog>());
        /*public async Task<DataTable<ActionLog>?> GetActivityReportAsync(IFilter<ActionLog> filter)
        {
            // TODO
        }*/
    }
}
