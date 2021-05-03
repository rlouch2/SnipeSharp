// List of Models in SnipeIT 5
type int = number;
type Uri = string;
type StatusLabelType = 'pending' | 'archived' | 'undeployable' | 'deployable';
type StatusMeta = 'deployed'| // if assigned
                    StatusLabelType; // if not assigned
type CheckoutToType = 'location' | 'asset' | 'user';
type CheckoutError = {
    asset: string|Pick<Asset, 'id' | 'asset_tag'>,
    target_id?: int,
    target_type?: CheckoutToType
};

type DataTable<T> = {
    total: int,
    rows: T[]
};

type FormattedDateString = string; // Format: settings->date_display_format
type DateString = string; // Format: Y-m-d
type DateTimeString = string; // Format: Y-m-d H:i:s
type FormattedDate = {
    date: DateString,
    formatted: FormattedDateString
};
type FormattedDateTime = {
    datetime: DateTimeString,
    formatted: FormattedDateString
};

type RequestedAsset = {
    id: int,
    name: string,
    asset_tag: string,
    serial: string,
    image: Uri|null,
    model: string|null,
    model_number: string|null,
    expected_checkin: FormattedDate,
    location: string|null,
    status: StatusMeta|null,
    available_actions: {
        cancel: boolean,
        request: boolean
    }
};

type RequestableType = string; // TODO: snake_case(class_basename(this->requestable_type))
type ProfileControllerRequestedAsset = {
    image: Uri, // TODO: null?
    name: string, //TODO
    type: RequestableType,
    qty: int, // TODO: null? checkoutRequest->quantity,
    location: string|null,
    expected_checkin: FormattedDateTime,
    request_date: FormattedDateTime
};

type SelectListItem<T> = {
    // id refers to id in T
    id: int,
    text: string,
    image: Uri|null
};
type SelectList<T> = {
    items: SelectListItem<T>[],
    pagination: {
        more: boolean,
        per_page: int
    },
    total_count: int,
    page: int,
    page_count: int
};

type FormattedCurrency = string; // #.##
type Accessory = {
    id: int,
    name: string,
    image: Uri|null,
    company: Pick<Company, 'id' | 'name'>|null,
    manufacturer: Pick<Manufacturer, 'id' | 'name'>|null,
    supplier: Pick<Supplier, 'id' | 'name'>|null,
    model_number: string|null,
    category: Pick<Category, 'id' | 'name'> | null,
    location: Pick<SnipeLocation, 'id' | 'name'> | null,
    notes: string|null,
    qty: int|null,
    purchase_date: FormattedDate|null,
    purchase_cost: FormattedCurrency,
    order_number: string|null,
    min_qty: int|null,
    remaining_qty: int, // can be negative if qty is null -- this makes no sense, but is the way it is

    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        checkout: boolean,
        checkin: false,
        update: boolean,
        delete: boolean
    },
    user_can_checkout: boolean
};

type TODO = undefined;
type ActionLog = {
    id: int,
    icon: string, // TODO: check?
    file: null | {
        url: string,// TODO: URI?
        filename: string,
        inlineable: boolean
    },
    item: null | {
        id: int,
        name: string,
        type: string // TODO
    },
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    next_audit_date: null|FormattedDate,
    days_to_next_audit: TODO,
    action_type: TODO,
    admin: null|Pick<User, 'id'|'name'|'first_name'|'last_name'>,
    target: null|{
        id: int,
        name: string,
        type: string // TODO
    },
    note: string|null,
    signature_file: string|null, // TODO: URI?
    log_meta: null|Map<string, Map<'old' | 'new', string|null>>
    action_date: null|FormattedDateTime
}

type AssetAssignedType = 'user'; //TODO: or what?
type Asset = {
    id: int,
    name: string|null,
    asset_tag: string,
    serial: string,
    model: null | Pick<Model, 'id' | 'name'>,
    model_number: string|null,
    eol: FormattedDate|null,
    status_label: null|{
        id: int,
        name: string,
        status_type: StatusLabelType,
        status_meta: StatusMeta
    },
    category: null|Pick<Category, 'id' | 'name'>
    manufacturer: null|Pick<Manufacturer, 'id'|'name'>,
    supplier: null|Pick<Supplier, 'id'|'name'>,
    notes: string|null,
    order_number: string|null,
    company: null|Pick<Company, 'id'|'name'>,
    location: null|Pick<SnipeLocation, 'id'|'name'>,
    rtd_location: null|Pick<SnipeLocation, 'id'|'name'>,
    image: string|null, //TODO: URI?
    assigned_to: null
        |(Pick<User, 'id'|'username'|'name'|'first_name'|'last_name'> & { type: 'user', employee_number: string|null })
        |{ id: int, name: string|null/*?*/, type: AssetAssignedType },
    warranty_months: string|null,
    warranty_expires: FormattedDate|null,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    last_audit_date: FormattedDateTime|null,
    next_audit_date: FormattedDate|null,
    deleted_at: FormattedDateTime|null,
    purchase_date: FormattedDate|null,
    last_checkout: FormattedDateTime|null,
    expected_checkin: FormattedDate|null,
    purchase_cost: number,
    checkin_counter: int,
    checkout_counter: int,
    requests_counter: int,
    user_can_checkout: boolean,
    custom_fields: Record<string, { field: string, value: string, field_format: string }>|[],
    available_actions: {
        checkout: boolean,
        checkin: boolean,
        clone: boolean,
        restore: boolean,
        update: boolean,
        delete: boolean
    }
};

type CheckedOutAccessoryUser = {
    assigned_pivot_id: int,
    id: int,
    username: string,
    name: string,
    first_name: string,
    last_name: string,
    employee_number: string,
    checkout_notes: string,//TODO
    last_checkout: FormattedDateTime,
    type: 'user',
    available_actions: {
        checkin: true
    }
};

type CategoryType = 'asset' | 'accessory' | 'consumable' | 'component' | 'license';
type UpperCategoryType = 'Asset' | 'Accessory' | 'Consumable' | 'Component' | 'License';
type Category = {
    id: int,
    name: string,
    image: Uri|null,
    category_type: UpperCategoryType,
    has_eula: boolean,
    eula: string|null,
    checkin_email: boolean,
    require_acceptance: boolean,
    item_count: int,
    assets_count: int,
    accessories_count: int,
    consumables_count: int,
    components_count: int,
    licenses_count: int,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type Company = {
    id: int,
    name: string,
    image: Uri|null,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    assets_count: int,
    licenses_count: int,
    accessories_count: int,
    consumables_count: int,
    components_count: int,
    users_count: int,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type Component = {
    id: int,
    name: string,
    image: Uri|null,
    serial: string|null,
    location: null|Pick<SnipeLocation, 'id' | 'name'>,
    qty: int|null,
    min_amt: int|null,
    category: null|Pick<Category, 'id' | 'name'>,
    order_number: string,
    purchase_date: FormattedDate,
    purchase_cost: FormattedCurrency,
    remaining: int,
    company: null|Pick<Company, 'id' | 'name'>,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    user_can_checkout: 1 | 0,
    available_actions: {
        checkout: boolean,
        checkin: boolean,
        update: boolean,
        delete: boolean
    }
};

type CheckedOutComponent = {
    assigned_pivot_id: int,
    id: int,
    name: string,
    qty: int, //TODO asset->pivot->assigned_qty
    type: 'asset',
    created_at: FormattedDateTime,
    available_actions: {
        checkin: true
    }
};

type Consumable = {
    id: int,
    name: string,
    image: Uri|null,
    category: null|Pick<Category, 'id' | 'name'>,
    company: null|Pick<Company, 'id' | 'name'>,
    item_no: string,
    location: null|Pick<SnipeLocation, 'id' | 'name'>,
    manufacturer: null|Pick<Manufacturer, 'id' | 'name'>,
    min_amt: int,
    model_number: string|null,
    remaining: int, // can be negative?
    order_number: string,
    purchase_cost: FormattedCurrency,
    purchase_date: FormattedDate,
    qty: int,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    user_can_checkout: false,
    available_actions: {
        'checkout': boolean,
        'checkin': boolean,
        'update': boolean,
        'delete': boolean
    }
};

type LaravelLinkToRoute<Route,Title,Parameter> = string; // TODO
type ConsumableDataView = {
    name: LaravelLinkToRoute<'users.show', 'fullName', 'id'> | 'DeletedUser',
    created_at: FormattedDateTime,
    admin: LaravelLinkToRoute<'TODO', 'TODO', 'TODO'> | ''
};

type CustomField = {
    id: int,
    name: string,
    db_column_name: string,
    format: string,
    field_values: string|null,
    field_values_array: string[]|null,
    type: string, // TODO enum
    required: boolean, // TODO field->pivot->required
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime
};

type CustomFieldWithDefaultValue = {
    id: int,
    name: string,
    type: string, // TODO enum
    field_values_array: string[]|null,
    default_value: string
};

type Department = {
    id: int,
    name: string,
    image: Uri|null,
    company: null|Pick<Company, 'id' | 'name'>,
    manager: null|Pick<User, 'id' | 'name' | 'first_name' | 'last_name'>,
    location: null|Pick<SnipeLocation, 'id' | 'name'>,
    users_count: string,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type MonthsString = string; // \d Months
type Depreciation = {
    id: int,
    name: string,
    months: MonthsString,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type Fieldset = {
    id: int,
    name: string,
    fields: DataTable<CustomField>,
    models: DataTable<Pick<Model, 'id' | 'name'>>,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime
};

type GroupPermissions = object; // TODO: group permissions from json (WHY)
type Group = {
    id: int,
    name: string,
    permissions: GroupPermissions,
    users_count: int,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type Import = {
    // TODO
};
type ImportResponse = {
    files: Import[]
};

type Kit = {
    id: int,
    name: string,
    user_can_checkout: true,
    available_actions: {
        update: boolean,
        delete: boolean,
        checkout: boolean
    }
};

type KitElement = {
    id: int,
    pivot_id: int,
    owner_id: int,
    quantity: int,
    name: string,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type License = {
    id: int,
    name: string,
    company: null|Pick<Company,'id'|'name'>,
    manufacturer: null|Pick<Manufacturer, 'id' | 'name'>,
    product_key: string|'------------',
    order_numeber: string,
    purchase_order: string,
    purchase_date: FormattedDate,
    purchase_cost: string,
    notes: string,
    expiration_date: FormattedDate,
    seats: int,
    free_seats_count: int,
    license_name: string,
    license_email: string,
    reassignable: boolean,
    maintained: boolean,
    supplier: null|Pick<Supplier, 'id' | 'name'>,
    category: null|Pick<Category, 'id' | 'name'>,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    user_can_checkout: boolean,
    available_actions: {
        checkout: boolean,
        checkin: boolean,
        clone: boolean,
        update: boolean,
        delete: boolean
    }
}

type SnipeLocation = {
    id: int,
    name: string,
    image: Uri|null,
    address: string|null,
    address2: string|null,
    city: string|null,
    state: string|null,
    country: string|null,
    zip: string|null,
    assigned_assets_count: int,
    assets_count: int,
    users_count: int,
    currency: string|null,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    parent: null | Pick<SnipeLocation, 'id' | 'name'>,
    manager: User | null, // TODO: is this actually populating all user properties, or just wasting time?
    children: Pick<SnipeLocation, 'id' | 'name'>[],
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type LoginAttempt = {
    id: int,
    username: string,
    user_agent: string,
    remote_ip: '--'|string,
    successful: string, // TODO: there has to be a better type for this
    created_at: FormattedDateTime
}

type Maintenance = {
    id: int,
    asset: null|Pick<Asset, 'id' | 'name' | 'asset_tag'>,
    model: null|Pick<Model, 'id' | 'name'>,
    company: null|Pick<Company, 'id' | 'name'>,
    title: string|null,
    location: null|Pick<SnipeLocation, 'id' | 'name'>,
    notes: string|null,
    supplier: null|Pick<Supplier, 'id' | 'name'>,
    cost: FormattedCurrency,
    asset_maintenance_type: string, // TODO: enum?
    start_date: FormattedDate,
    asset_maintenance_time: string, // TODO: type?
    completion_date: FormattedDate,
    user_id: null|Pick<User, 'id' | 'name'>,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type Manufacturer = {
    id: int,
    name: string,
    url: string,
    image: string|null,
    support_url: string,
    support_phone: string,
    support_email: string,
    assets_count: int,
    licenses_count: int,
    consumables_count: int,
    accessories_count: int,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    deleted_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        restore: boolean,
        delete: boolean
    }
};

type Model = {
    id: int,
    name: string,
    manufacturer: null|Pick<Manufacturer, 'id' | 'name'>,
    image: string|null,
    model_number: string,
    depreciation: null|Pick<Depreciation, 'id' | 'name'>,
    assets_count: int,
    category: null|Pick<Category, 'id' | 'name'>,
    fieldset: null|Pick<Fieldset, 'id' | 'name'>,
    eol: 'None' | MonthsString,
    requestable: boolean,
    notes: string,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    deleted_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean,
        clone: boolean,
        restore: boolean
    }
}

type Supplier = {
    id: int,
    name: string,
    image: string|null,
    url: string, //TODO: Uri?,
    address: string,
    address2: string,
    city: string,
    state: string, // TODO: enum?
    country: string, // TODO: enum?
    zip: string, // TODO: pattern?,
    fax: string,
    phone: string,
    email: string,
    contact: string,
    assets_count: int,
    accessories_count: int,
    licenses_count: int,
    notes: string|null,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};

type StandardResponseStatus = 'error' | 'success';
type StandardResponse<T> = {
    status: StandardResponseStatus,
    messages: string|null|Map<string, string|boolean|int>,// TODO: is belongsToMany()->count() int or bool?
    payload: T|null
};
type SlackMessageStrings = 'Success'
                         | 'Something went wrong :('
                         | 'Oops! Please check the channel name and webhook endpoint URL. Slack responded with: `$e->getMessage()`';
type Message<T> = {
    message: T
};

type StatusLabel = {
    id: int,
    name: string,
    type: StatusLabelType,
    color: HexColor|null,
    show_in_nav: boolean,
    default_label: boolean,
    assets_count: int,
    notes: string,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean
    }
};
type HexColor = string;
type StatusLabelAssetcountObject = {
    labels: string[],
    datasets: [
        {
            data: int[],
            backgroundColor: HexColor[],
            hoverBackgroundcolor: HexColor[]
        }
    ]
};

type User = {
    id: int,
    avatar: string,
    name: string,
    first_name: string,
    last_name: string,
    username: string,
    employee_num: string,
    manager: null|Pick<User, 'id' | 'name'>,
    jobtitle: string|null,
    phone: string|null,
    website: string|null, // TODO: URL?
    address: string|null,
    city: string|null,
    state: string|null,
    country: string|null,
    zip: string|null,
    email: string,
    department: null|Pick<Department, 'id' | 'name'>,
    location: null|Pick<SnipeLocation, 'id' | 'name'>,
    notes: string,
    permissions: TODO,
    activated: boolean,
    two_factor_activated: boolean,
    two_factor_enrolled: boolean,
    assets_count: int,
    licenses_count: int,
    accessories_count: int,
    consumables_count: int,
    company: null|Pick<Company, 'id' | 'name'>,
    created_at: FormattedDateTime,
    updated_at: FormattedDateTime,
    last_login: FormattedDateTime,
    deleted_at: null|FormattedDateTime,
    available_actions: {
        update: boolean,
        delete: boolean,
        clone: boolean,
        restore: boolean
    },
    groups: null|DataTable<Pick<Group, 'id' | 'name'>>
};
