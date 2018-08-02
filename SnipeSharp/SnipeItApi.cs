using SnipeSharp.Common;
using SnipeSharp.Endpoints;
using SnipeSharp.Endpoints.ExtendedManagers;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp
{
    public class SnipeItApi
    {
        public ApiSettings ApiSettings { get; set; }
        public AssetEndpointManager AssetManager;
        public IEndPointManager<Company> CompanyManager;
        public IEndPointManager<Location> LocationManager;
        public IEndPointManager<Consumable> ConsumableManager;
        public IEndPointManager<Component> ComponentManager;
        public UserEndpointManager UserManager;
        public IEndPointManager<StatusLabel> StatusLabelManager;
        public IEndPointManager<Model> ModelManager;
        public IEndPointManager<License> LicenseManager;
        public IEndPointManager<Category> CategoryManager;
        public IEndPointManager<Manufacturer> ManufacturerManager;
        public IEndPointManager<FieldSet> FieldSetManager;
        public StatusLabelEndpointManager StatusLabelsManager;
        public IEndPointManager<Supplier> SupplierManager;
        public IEndPointManager<Depreciation> DepreciationManager;
        public IEndPointManager<Department> DepartmentManager;
        internal RequestManager ReqManager;

        public SnipeItApi()
        {
            ApiSettings = new ApiSettings();
            ReqManager = new RequestManager(this);
            AssetManager = new AssetEndpointManager(ReqManager);
            CompanyManager = new EndPointManager<Company>(ReqManager);
            LocationManager = new EndPointManager<Location>(ReqManager);
            ConsumableManager = new EndPointManager<Consumable>(ReqManager);
            ComponentManager = new EndPointManager<Component>(ReqManager);
            UserManager = new UserEndpointManager(ReqManager);
            StatusLabelManager = new StatusLabelEndpointManager(ReqManager);
            ModelManager = new EndPointManager<Model>(ReqManager);
            LicenseManager = new EndPointManager<License>(ReqManager);
            CategoryManager = new EndPointManager<Category>(ReqManager);
            ManufacturerManager = new EndPointManager<Manufacturer>(ReqManager);
            FieldSetManager = new EndPointManager<FieldSet>(ReqManager);
            SupplierManager = new EndPointManager<Supplier>(ReqManager);
            DepreciationManager = new EndPointManager<Depreciation>(ReqManager);
            DepartmentManager = new EndPointManager<Department>(ReqManager);
        }
    }
}
