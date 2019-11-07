using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    public sealed class ComponentEndPoint : EndPoint<Component>
    {
        // TODO: docs
        internal ComponentEndPoint(SnipeItApi api) : base(api) {}

        /// <summary>
        /// Get the list of component assignees for a component.
        /// </summary>
        /// <param name="component">The component to get the assignee list of.</param>
        /// <returns>A ResponseCollection list of ComponentAssignees.</returns>
        public ResponseCollection<ComponentAssignee> GetAssignedAssets(Component component)
            => Api.RequestManager.GetAll<ComponentAssignee>($"{EndPointInfo.BaseUri}/{component.Id}/assets").RethrowExceptionIfAny().Value;
    }
}
