using System.Text;

namespace SnipeSharp
{
    internal static class Static
    {
        public readonly static Encoding UTF8NoBom = new UTF8Encoding(false);
        public const string ASSET_NAME = "asset_name";
        public const string ASSET_TAG = "asset_tag";
        public const string AVAILABLE_ACTIONS = "available_actions";
        public const string COST = "cost";
        public const string CREATED_AT = "created_at";
        public const string CURRENCY = "currency";
        public const string DELETED_AT = "deleted_at";
        public const string EXPECTED_CHECKIN = "expected_checkin";
        public const string ID = "id";
        public const string IMAGE = "image";
        public const string LIMIT = "limit";
        public const string MANAGER = "manager";
        public const string MODEL_NUMBER = "model_number";
        public const string NAME = "name";
        public const string NOTES = "notes";
        public const string OFFSET = "offset";
        public const string ORDER = "order";
        public const string PERMISSIONS = "permissions";
        public const string QUANTITY = "qty";
        public const string SEARCH = "search";
        public const string SERIAL = "serial";
        public const string SORT_COLUMN = "sort";
        public const string STATUS = "status";
        public const string TITLE = "title";
        public const string TYPE = "type";
        public const string UPDATED_AT = "updated_at";
        public const string USERNAME = "username";
        public const string URL = "url";

        internal static class Types
        {
            public const string ASSET = "asset";
            public const string COMPANY = "company";
            public const string CATEGORY = "category";
            public const string DEPARTMENT = "department";
            public const string LOCATION = "location";
            public const string MANUFACTURER = "manufacturer";
            public const string MODEL = "model";
            public const string SUPPLIER = "supplier";
            public const string USER = "user";
        }

        internal static class Id
        {
            public const string ASSET = Types.ASSET + "_" + ID;
            public const string SUPPLIER = Types.SUPPLIER + "_" + ID;
            public const string USER = Types.USER + "_" + ID;
        }

        internal static class Result
        {
            public const string GENERAL = "general";
            public const string MESSAGES = "messages";
            public const string PAYLOAD = "payload";
            public const string SUCCESS = "success";
            public const string ERROR = "error";
        }

        internal static class Count
        {
            public const string ACCESSORIES = "accessories_count";
            public const string ASSETS = "assets_count";
            public const string ASSIGNED_ASSETS = "assigned_assets_count";
            public const string COMPONENTS = "components_count";
            public const string CONSUMABLES = "consumables_count";
            public const string LICENSES = "licenses_count";
            public const string USERS = "users_count";
            public const string CHECKIN = "checkin_counter";
            public const string CHECKOUT = "checkout_counter";
            public const string REQUESTS = "requests_counter";
        }

        internal static class Asset
        {
            public const string END_OF_LIFE = "eol";
            public const string ORDER_NUMBER = "order_number";
            public const string RTD_LOCATION = "rtd_" + Types.LOCATION;
            public const string WARRANTY_MONTHS = "warranty_months";
            public const string WARRANTY_EXPIRES = "warranty_expires";
            public const string USER_CAN_CHECKOUT = "user_can_checkout";
            public const string LAST_AUDIT = "last_audit_date";
            public const string NEXT_AUDIT = "next_audit_date";
            public const string PURCHASE_DATE = "purchase_date";
            public const string LAST_CHECKOUT = "last_checkout";
            public const string PURCHASE_COST = "purchase_cost";
            public const string STATUS_TYPE = "status_type";
            public const string STATUS_META = "status_meta";
        }

        internal static class Depreciation
        {
            public const string MONTHS = "months";
        }

        internal static class Location
        {
            public const string ADDRESS = "address";
            public const string ADDRESS2 = "address2";
            public const string CITY = "city";
            public const string STATE = "state";
            public const string COUNTRY = "country";
            public const string ZIP = "zip";
            public const string PARENT = "parent";
            public const string CHILDREN = "children";
        }

        internal static class LoginAttempt
        {
            public const string USER_AGENT = "user_agent";
            public const string REMOTE_IP = "remote_ip";
            public const string SUCCESSFUL = "successful";
        }

        internal static class Maintenance
        {
            public const string ASSET_MAINTENANCE_TIME = "asset_maintenance_time";
            public const string ASSET_MAINTENANCE_TYPE = "asset_maintenance_type";
            public const string COMPLETION_DATE = "completion_date";
            public const string IS_WARRANTY = "is_warranty";
            public const string START_DATE = "start_date";
        }

        internal static class Manufacturer
        {
            public const string SUPPORT_EMAIL = "support_email";
            public const string SUPPORT_PHONE = "support_phone";
            public const string SUPPORT_URL = "support_url";
        }

        internal static class Error
        {
            public const string VALUE_EMPTY = "Value cannot be null or empty.";
            public const string NULL_DESERIALIZING_STRING = "Encountered null while deserializing string.";
            public const string NULL_DESERIALIZING_DICT = "Encountered null while deserializing dictionary.";
            public const string UNKNOWN_MESSAGES_TYPE = "Unkown JsonElement value kind for \"" + Result.MESSAGES + "\" key.";
        }

        internal static class Actions
        {
            public const string CANCEL = "cancel";
            public const string CHECKIN = "checkin";
            public const string CHECKOUT = "checkout";
            public const string CLONE = "clone";
            public const string DELETE = "delete";
            public const string REQUEST = "request";
            public const string RESTORE = "restore";
            public const string UPDATE = "update";
        }

        internal static class Request
        {
            public const string REQUEST_DATE = "request_date";
        }

        internal static class StatusLabel
        {
            public const string COLOR = "color";
            public const string DEFAULT_LABEL = "default_label";
            public const string SHOW_IN_NAV = "show_in_nav";
        }

        internal static class User
        {
            public const string FIRST_NAME = "first_name";
            public const string LAST_NAME = "last_name";
        }
    }
}
