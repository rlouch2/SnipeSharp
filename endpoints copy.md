# List of API Endpoints in SnipeIT 5

- [ ] /api/v1
  - [ ] /accessories
    - [ ] GET /selectlist (`AccessoriesController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`AccessoriesController@index`) :: `DataTable<Accessory>`

        | param             | type     |
        |-------------------|----------|
        | `search`          | `string`
        | `company_id`      | `int`
        | `category_id`     | `int`
        | `manufacturer_id` | `int`
        | `supplier_id`     | `int`
        | `offset`          | `int`
        | `limit`           | `int`
        | `order`           | `asc | *` (`desc`)
        | `sort`            | `category | company | id | name | model_number | eol | notes | created_at | min_amt | company_id` (`created_at`)

    - [ ] GET /{id} (`AccessoriesController@show`) :: `Accessory`
    - [ ] POST (`AccessoriesController@store`) :: `StandardApiResponse<null | RawAccessory>`

        | param             | type
        |-------------------|------
        | `category_id`     | `int`
        | `company_id`      | `int|null`
        | `location_id`     | `int`
        | `name`            | `string`
        | `order_number`    | `string`
        | `purchase_cost`   | `int|null`
        | `purchase_date`   | `date`
        | `model_number`    | `string`
        | `manufacturer_id` | `int`
        | `supplier_id`     | `int`
        | `image`           | `string` -- TODO: URL or null?
        | `qty`             | `int`
        | `requestable`     | `boolean`

    - [ ] PUT /{id} (`AccessoriesController@update`) :: `StandardApiResponse<null | RawAccessory>`

        Params same as post.

    - [ ] DELETE /{id} (`AccessoriesController@destroy`) :: `StandardResponse<null>`
    - [ ] GET /{id}/checkedout (`AccessoriesController@checkedout`) -- [ ] appears twice
            :: `DataTable<CheckedOutAccessoryUser>` (can be none if not accessory users)

        | param    | type
        |----------|---------
        | `search` | `string` // searches first or last name of accessory users
        | `offset` | `int` // for accessory users -- if total < 0, returns all regardless
        | `limit`  | `int` // for accessory users

    - [ ] POST /{id}/checkout (`AccessoriesController@checkout`) :: `StandardApiResponse<null>`

        | param         | type             |
        |---------------|------------------|
        | `assigned_to` | `int` // User ID |
        | `note`        | `string`         |

    - [ ] POST /{id}/checkin (`AccessoriesController@checkin`) :: `StandardApiResponse<null>`

        | param  | type     |
        |--------|----------|
        | `note` | `string` |
  - [ ] /categories
    - [ ] GET /{item_type}/selectlist (`CategoriesController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`CategoriesController@index`) :: `DataTable<Category>`

        | param    | type     |
        |----------|----------|
        | `search` | `string`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | name | category_type | use_default_eula | eula_text | require_acceptance | checkin_email | assets_count | accessories_count | consumables_count | components_count | licenses_count | image` (`assets_count`)

    - [ ] GET /{id} (`CategoriesController@show`) :: `Category`
    - [ ] POST (`CategoriesController@store`) :: `StandardApiResponse<null | RawCategory>`

        | param                | type
        |----------------------|-------
        | `category_type`      | `CategoryType`
        | `checkin_email`      | `string`
        | `eula_text`          | `string`
        | `name`               | `string`
        | `require_acceptance` | `boolean`
        | `use_default_eula`   | `boolean`
        | `user_id`            | `int`

    - [ ] PUT /{id} (`CategoriesController@update`) :: `StandardApiResponse<null | RawCategory>`

        Params same as POST.

    - [ ] DELETE /{id} (`CategoriesController@destroy`) :: `StandardApiResponse<null>`
  - [ ] /departments
    - [ ] GET /selectlist (`DepartmentsController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`DepartmentsController@index`) :: `DataTable<Department>`

        | param    | type     |
        |----------|----------|
        | `search` | `string`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | name | image | users_count | location | manager` (`created_at`)

    - [ ] GET /{id} (`DepartmentsController@show`) :: `Department`
    - [ ] POST (`DepartmentsController@store`) :: `StandardApiResponse<null | RawDepartment>`

        | param         | type     |
        |---------------|----------|
        | `user_id`     | `int`    |
        | `name`        | `string` |
        | `location_id` | `int`    |
        | `company_id`  | `int`    |
        | `manager_id`  | `int`    |
        | `notes`       | `string` |

    - [ ] PUT /{id} (`DepartmentsController@update`) :: `StandardApiResponse<null | RawDepartment>`

        Params same as explicit POST sans explicit manager_id set.

    - [ ] DELETE /{id} (`DepartmentsController@destroy`) :: `StandardApiResponse<null>`
  - [ ] /components
    - [ ] GET (`ComponentsController@index`) :: `DataTable<Component>`

        | param    | type     |
        |----------|----------|
        | `search` | `string`
        | `company_id`  | `int`
        | `category_id` | `int`
        | `location_id` | `int`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | name | min_amt | order_number | serial | purchase_date | purchase_cost | company | category | qty | location | image` (`created_at`)

    - [ ] GET /{id} (`ComponentsController@show`) :: `Component`
    - [ ] POST (`ComponentsController@store`) :: `StandardApiReponse<null | RawComponent>`

        | param           | type
        |-----------------|------
        | `category_id`   | `int`
        | `company_id`    | `int`
        | `location_id`   | `int`
        | `name`          | `string`
        | `purchase_cost` | `number`
        | `purchase_date` | `date`
        | `min_amt`       | `int`
        | `order_number`  | `string`
        | `qty`           | `int`
        | `serial`        | `string`

    - [ ] PUT /{id} (`ComponentsController@update`) :: `StandardApiReponse<null | RawComponent>`

        Params same as POST.

    - [ ] DELETE /{id} (`ComponentsController@destroy`) :: `StandardApiResponse<null>`
    - [ ] GET /{id}/assets (`ComponentsController@getAssets`) :: `DataTable<CheckedOutComponent>`

        | param    | type       |
        |----------|------------|
        | `offset` | `int` (0)  |
        | `limit`  | `int` (50) |
  - [ ] /consumables
    - [ ] GET /selectlist (`ConsumablesControl@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`ConsumablesControl@index`) :: `DataTable<Consumable>`

        | param    | type     |
        |----------|----------|
        | `search` | `string`
        | `company_id`  | `int`
        | `category_id` | `int`
        | `manufacturer_id` | `int`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | name | order_number | min_amt | purchase_date | purchase_cost | company | category | model_number | item_no | manufacturer | location | qty | image` (`created_at`)

    - [ ] GET /{id} (`ConsumablesControl@show`) :: `Consumable`
    - [ ] POST (`ConsumablesControl@store`) :: `StandardApiResponse<null | RawConsumable>`

        | param             | type
        |-------------------|-----
        | `category_id`     | `int`
        | `company_id`      | `int`
        | `item_no`         | `string`
        | `location_id`     | `int`
        | `manufacturer_id` | `int`
        | `name`            | `string`
        | `order_number`    | `string`
        | `model_number`    | `string`
        | `purchase_cost`   | `number`
        | `purchase_date`   | `date`
        | `qty`             | `int`
        | `requestable`     | `boolean`

    - [ ] PUT /{id} (`ConsumablesControl@update`) :: `StandardApiResponse<null | RawConsumable>`

        Params samse as POST.

    - [ ] DELETE /{id} (`ConsumablesControl@destroy`) :: `StandardApiResponse<null>`
    - [ ] GET /view/{id}/users (`ConsumablesController@getDataView`) :: `DataTable<ConsumableDataView>`
    - [ ] POST /{id}/checkout (`ConsumablesController@checkout`) :: `StandardApiResponse<null>`

        | param         | type     |
        |---------------|----------|
        | `assigned_to` | `int`    |
        | `note`        | `string` |

        There's something weird going on here with the `$data` variable -- it's populated, but never used.
  - [ ] /fields
    - [ ] GET (`CustomFieldsController@index`) :: `DataTable<CustomField>` (all, no params)
    - [ ] GET /{id} (`CustomFieldsController@show`) :: `CustomField`
    - [ ] POST (`CustomFieldsController@store`) :: `StandardApiResponse<null | RawCustomField>`

        | param             | type           |
        |-------------------|----------------|
        | `name`            | `string`       |
        | `element`         | `text|listbox` |
        | `format`          | `string` TODO:predefined formats |
        | `field_values`    | TODO
        | `field_encrypted` | `boolean`      |
        | `help_text`       | `string`       |
        | `show_in_email`   | `boolean`      |

    - [ ] PUT /{id} (`CustomFieldsController@update`) :: `StandardApiResponse<null | RawCustomField>`

        Params same as POST, sans `field_encrypted`.

    - [ ] DELETE /{id} (`CustomFieldsController@destroy`) :: `StandardApiResponse<null>`
    - [ ] POST /fieldsets/{id}/order (`CustomFieldsController@postReorder`) :: TODO

        | param  | type                         |
        |--------|------------------------------|
        | `item` | `int[]` (Field IDs in order) |

    - [ ] POST /{id}/associate (`CustomFieldsController@associate`) :: `StandardApiResponse<RawFieldset>`

        | param         | type  |
        |---------------|-------|
        | `fieldset_id` | `int` |

    - [ ] POST /{id}/disassociate (`CustomFieldsController@disassociate`) :: `StandardApiResponse<RawFieldset>`

        | param         | type  |
        |---------------|-------|
        | `fieldset_id` | `int` |
  - [ ] /fieldset
    - [ ] GET /{id}/fields (`CustomFieldsetsController@fields`) :: `DataTable<CustomField>`
    - [ ] GET /{id}/fields/{model} (`CustomFieldsetsController@fieldsWithDefaultValues`) :: `DataTable<CustomFieldWithDefaultValue>`
    - [ ] GET (`CustomFieldsetsController@index`) :: `DataTable<Fieldset>` (all, no params)
    - [ ] GET /{id} (`CustomFieldsetsController@show`) :: `Fieldset | StandardApiResponse<null>`
    - [ ] POST (`CustomFieldsetsController@store`) :: `StandardApiResponse<null | RawFieldset>`

        TODO

    - [ ] PUT /{id} (`CustomFieldsetsController@update`) :: `StandardApiResponse<null | RawFieldset>`

        Params same as POST.

    - [ ] DELETE /{id} (`CustomFieldsetsController@destroy`) :: `StandardApiResponse<null>`
  - [ ] /groups
    - [ ] GET (`GroupsController@index`) :: `DataTable<Group>`

        | param    | type     |
        |----------|----------|
        | `search` | `string`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | name | created_at | updated_at` (`created_at`)

    - [ ] POST (`GroupsController@store`) :: `StandardApiResponse<null | RawGroup>`

        TODO

    - [ ] PUT /{id} (`GroupsController@update`) :: `StandardApiResponse<null | RawGroup>`

        Params same as POST.
  - [ ] /hardware
    - [ ] GET /{id}/licenses (`AssetsController@licenses`) :: `DataTable<License>`
    - [ ] GET /audit/{audit} (`AssetsController@index`) :: `DataTable<Asset>`

        Same params as GET /hardware, but with:

        | param   | type          |
        |---------|---------------|
        | `audit` | `due|overdue` |

    - [ ] POST /audit (`AssetsController@audit`) :: `StandardApiResponse<null|{ asset_tag: string, note?: string, next_audit_date?: FormattedDateTime }>`

        | param             | type        |
        |-------------------|-------------|
        | `asset_tag`       | `string`    |
        | `location_id`     | `int`       |
        | `next_audit_date` | `date|null` |
        | `update_location` | `'1' | *`   |
        | `note`            | `string`    |

    - [ ] POST /{id}/checkout (`AssetsController@checkout`) :: `StandardApiResponse<CheckoutError>`

        | param               |                  |
        |---------------------|------------------|
        | `checkout_to_type`  | `CheckoutToType` |
        | `assigned_location` | `int`            |
        | `assigned_asset`    | `int`            |
        | `assigned_user`     | `int`            |
        | `expected_checkin`  | `date` (null)    |
        | `note`              | `string` (null)  |
        | `name`              | `string` (null)  |

    - [ ] POST /{id}/checkin (`AssetsController@checkin`) :: `StandardApiResponse<{asset: string}>`

        | param         | type     |
        |---------------|----------|
        | `name`        | `string` |
        | `location_id` | `int`    |
        | `status_id`   | `int`    |
        | `note`        | `string` |

    - [ ] GET (`AssetsController@index`) :: `DataTable<Asset>`

        | param    | type
        |----------|-------
        | `filter` | `JSONString` (WHAT)
        | `status_id` | `int`
        | `model_id`  | `int`
        | `category_id` | `int`
        | `location_id` | `int`
        | `rtd_location_id` | `int`
        | `supplier_id` | `int`
        | `assigned_to` | TODO
        | `assigned_type` | TODO
        | `company_id` | `int`
        | `manufacturer_id` | `int`
        | `depreciation_id` | `int`
        | `order_number` | `string`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `status` | `Deleted | Pending | RTD | Undeployable | Archived | Requestable | Deployed | int (status_id)`
        | `status_id` | `int`
        | `search` | `string`
        | `sort`   | Any custom field database column name OR `id | name | asset_tag | serial | model_number | last_checkout | notes | expected_checkin | order_number | image | assigned_to | created_at | updated_at | purchase_date | purchase_cost | last_audit_date | next_audit_date | warranty_months | checkout_counter | checkin_counter | requests_counter | model | category | manufacturer | company | location | rtd_location | status_label | supplier | assigned_to` (`created_at`)

    - [ ] PUT /{id} (`AssetsController@update`) :: `StandardApiResponse<null | RawAsset>`

        TODO

    - [ ] POST (`AssetsController@store`) :: `StandardApiResponse<null | RawAsset>`

        | param               | type
        |---------------------|---------------
        | `name`              | `string`
        | `serial`            | `string`
        | `company_id`        | `int`
        | `model_id`          | `int`
        | `order_number`      | `string`
        | `notes`             | `string`
        | `asset_tag`         | `string`
        | `status_id`         | `int` (0)
        | `warranty_months`   | TODO (null)
        | `purchase_cost`     | `float`
        | `purchase_date`     | `date` (null)
        | `assinged_to`       | TODO (null) -- bug?
        | `supplier_id`       | `int` (0)
        | `requestable`       | `boolean` (0)
        | `rtd_location_id`   | `int` (null)
        | `image_source`      | TODO
        | Dynamic Model-Based Custom Fields | various
        | `assigned_user`     | `int`
        | `asigned_asset`     | `int`
        | `assigned_location` | `int`
  - [ ] /imports
    - [ ] GET (`ImportController@index`) :: `Import[]`
    - [ ] GET /{id} (`ImportController@show`) -- missing in controller
    - [ ] PUT /{id} (`ImportController@update`) -- missing in controller
    - [ ] POST (`ImportController@store`) :: `StandardApiResponse<null> | ImportResponse`

      File upload. Accepted types:

      - `application/vnd.ms-excel`
      - `text/csv`
      - `text/plain`
      - `text/comma-separated-values`
      - `text/tsv`

    - [ ] DELETE /{id} (`ImportController@destroy`) :: `StandardApiResponse<null> | undefined`
    - [ ] POST /process/{id} (`ImportController@process`) :: `StandardApiResponse<null>`

        | param         | type
        |---------------|---------
        | `run-backup`  | Switch.
        | `import-type` | `asset | accessory | consumable | component | license | user`
  - [ ] /licenses
    - [ ] GET /{id}/seats (`LicensesController@seats`) :: `DataTable<LicenseSeat> | StandardApiResponse<null>`

        | param    | type
        |----------|------
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `department | *` (`id`)
        | `offset` | `int`
        | `limit`  | `int`

    - [ ] GET /selectlist (`LicensesController@selectlist`):: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`LicensesController@index`) :: `DataTable<License>`

        | param             | type
        |-------------------|------
        | `company_id`      | `int`
        | `name`            | `string`
        | `product_key`     | `string`
        | `order_number`    | `string`
        | `purchase_order`  | `string`
        | `license_name`    | `string`
        | `license_email`   | `string`
        | `manufacturer_id` | `int`
        | `supplier_id`     | `int`
        | `category_id`     | `int`
        | `depreciation_id` | `int`
        | `search`          | `string`
        | `offset`          | `int`
        | `limit`           | `int`
        | `order`           | `asc | *` (`desc`)
        | `sort`            | `manufacturer|supplier|company|id|name|purchase_cost|expiration_date|purchase_order|order_number|notes|purchase_date|serial|company|category|license_name|license_email|free_seats_count|seats` (`created_at`)

    - [ ] GET /{id} (`LicensesController@show`) :: `License`
    - [ ] PUT /{id} (`LicensesController@update`) TODO
    - [ ] POST (`LicensesController@store`) TODO
    - [ ] DELETE /{id} (`LicensesController@destroy`) :: `StandardApiResponse<null>`
  - [ ] /locations
    - [ ] GET (`LocationsController@index`) :: `DataTable<SnipeLocation>`

        | param    | type
        |----------|------
        | `search` | `string`
        | `offset` | `int`
        | `limit`  | `int`
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id|name|address|address2|city|state|country|zip|created_at|updated_at|manager_id|image|assigned_assets_count|users_count|assets_count|currency|parent|manager` (`created_at`)

    - [ ] GET /{id} (`LocationsController@show`) :: `SnipeLocation`
    - [ ] PUT /{id} (`LocationsController@update`) TODO
    - [ ] POST (`LocationsController@store`) TODO
    - [ ] DELETE /{id} (`LocationsController@destroy`) :: `StandardApiResponse<null>`
    - [ ] GET /{id}/users (`LocationsController@getDataViewUsers`) -- missing in controller
    - [ ] GET /{id}/assets (`LocationsController@getDataViewAssets`) -- missing in controller
    - [ ] GET /{id}/check (`LocationsController@show`) -- [ ] may be unnecessary
    - [ ] GET /{id}/selectlist (`LocationsController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |
  - [ ] /models
    - [ ] GET /selectlist (`AssetModelsController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [ ] GET (`AssetModelsController@index`) :: `DataTable<Model>`

        | param     | type
        |-----------|------------------
        | `status`  | present/absent for `onlyTrashed()`
        | `search`  | `string`
        | `offset`  | `int`
        | `limit`   | `int`
        | `order`   | `asc | *` (`desc`)
        | `sort`    | `id|image|name|model_number|eol|notes|created_at|manufacturer|requestable|assets_count` (`created_at`)

    - [ ] GET /{id} (`AssetModelsController@show`) :: `Model`
    - [ ] PUT /{id} (`AssetModelsController@update`) TODO
    - [ ] POST (`AssetModelsController@store`) TODO
    - [ ] DELETE /{id} (`AssetModelsController@destroy`) :: `StandardApiResponse<null>`
    - [ ] GET /{id}/assets (`AssetModelsController@assets`) :: `DataTable<Asset>`
  - [ ] /settings
    - [ ] GET /ldaptest (`SettingsController@ldapAdSettingsTest`) TODO
    - [x] GET /login-attempts (`SettingsController@showLoginAttempts`) :: `DataTable<LoginAttempt>`

        | param    | type
        |----------|------
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id | username | remote_ip | user_agent | successful | created_at` (`created_at`)
        | `offset` | `int` (0)
        | `limit`  | `int` (20)

    - [ ] POST /ldaptestlogin (`SettingsController@ldaptestlogin`) TODO
    - [ ] POST /slacktest (`SettingsController@slacktest`) :: `Message<SlackMessageStrings>`

        | param            | type            |
        |------------------|-----------------|
        | `slack_endpoint` | `string` (URL?) |
        | `slack_channel`  | `string`        |
        | `slack_botname`  | `string`        |

    - [ ] POST /mailtest (`SettingsController@ajaxTestEmail`) :: `Message<string>`
    - [ ] POST /purge_barcodes (`SettingsController@purgeBarcodes`) :: `Message<string>`
    - [ ] GET (`SettingsController@index`) -- TODO: missing in controller
    - [ ] GET /{id} (`SettingsController@show`) -- TODO: missing in controller
    - [ ] PUT /{id} (`SettingsController@update`) -- TODO: missing in controller
    - [ ] POST (`SettingsController@store`) -- TODO: missing in controller
  - [ ] /statuslabels
    - [ ] GET /assets (`StatuslabelsController@getAssetCountByStatusLabel`) :: `StatusLabelAssetCountObject`
    - [ ] GET /{id}/assetlist (`StatuslabelsController@assetlist`) :: `DataTable<Asset>`

        | param    | type       |
        |----------|------------|
        | `offset` | `int` (0)  |
        | `limit`  | `int` (50) |
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id|name` (`created_at`)

    - [ ] GET /{id}/deployable (`StatuslabelsController@checkIfDeployable`) :: `'1' | '0'`
    - [ ] GET (`StatuslabelsController@index`) :: `DataTable<StatusLabel>`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |
        | `offset` | `int`    |
        | `limit`  | `int`    |
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id|name|created_at|assets_count|color|default_label` (`created_at`)

    - [ ] GET /{id} (`StatuslabelsController@show`) :: `StatusLabel`
    - [ ] PUT /{id} (`StatuslabelsController@update`) TODO
    - [ ] POST (`StatuslabelsController@store`) TODO
    - [ ] DELETE /{id} (`StatuslabelsController@destroy`) :: `StandardApiResponse<null>`
  - [ ] /suppliers
    - [ ] GET /list (`SuppliersController@getDatatable`) -- TODO: missing in controller
    - [x] GET /selectlist (`SuppliersController@selectlist`) :: `SelectList`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

    - [x] GET (`SuppliersController@index`) :: `DataTable<Supplier>`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |
        | `offset` | `int`    |
        | `limit`  | `int`    |
        | `order`  | `asc | *` (`desc`)
        | `sort`   | `id|name|address|phone|contact|fax|email|image|assets_count|licenses_count|accessories_count|url` (`created_at`)

    - [x] GET /{id} (`SuppliersController@show`) :: `Supplier`
    - [ ] PUT /{id} (`SuppliersController@update`) TODO
    - [ ] POST (`SuppliersController@store`) TODO
    - [ ] DELETE /{id} (`SuppliersController@destroy`) :: `StandardApiResponse<null>` TODO: extra messages
  - [ ] /users
    - [ ] POST /two_factor_reset (`UsersController@postTwoFactorReset`)
    - [ ] GET /list/{status?} (`UsersController@getDatatable`)
    - [x] GET /{id}/assets (`UsersController@assets`) :: `DataTable<Asset>`
    - [x] GET /{id}/licenses (`UsersController@licenses`) :: `DataTable<License>`
    - [ ] POST /{id}/upload (`UsersController@postUpload`) TODO
    - [ ] PUT /{id} (`UsersController@update`) TODO
    - [ ] POST (`UsersController@store`) TODO
  - [ ] /reports
    - [ ] GET /activity (`ReportsController@index`) :: `DataTable<ActionLog>`

        | param         | type
        |---------------|------
        | `search`      | `string`
        | `target_type` | `AppModelString`
        | `target_id`   | `int`
        | `item_type`   | `AppModelString`
        | `item_id`     | `int`
        | `action_type` | `string` TODO enum
        | `uploads`     | present/absent
        | `sort`        | `id|created_at|target_id|user_id|accept_signature|action_type|note` (`created_at`)
        | `order`       | `asc | *` (`desc`)
        | `offset`      | `int` (0)
        | `limit`       | `int` (50)
  - [ ] /kits
    - [ ] GET (`PredefinedKitsController@index`) :: `DataTable<Kit>`

        | param    | type                       |
        |----------|----------------------------|
        | `search` | `string`                   |
        | `offset` | `int` (0)                  |
        | `limit`  | `int` (50)                 |
        | `order`  | `asc | *` (`desc`)         |
        | `sort`   | `id|name` (`assets_count`) |

    - [ ] GET /{id} (`PredefinedKitsController@show`) :: `Kit`
    - [ ] POST (`PredefinedKitsController@store`) :: `StandardApiResponse<null | RawKit>`

        | param  | type     |
        |--------|----------|
        | `name` | `string` |

    - [ ] PUT /{id} (`PredefinedKitsController@update`) :: `StandardApiResponse<null | RawKit>`

        Params same as POST.

    - [ ] DELETE /{id} (`PredefinedKitsController@destroy`) :: `StandardApiResponse<null>`
    - [ ] /{id}/licenses
      - [ ] GET (`PredefinedKitsController@indexLicenses`) :: `DataTable<KitElement>`

        | param    | type     |
        |----------|----------|
        | `search` | `string` |

      - [ ] POST (`PredefinedKitsController@storeLicense`) :: `StandardApiResponse<null | RawKit>`

        | param      | type  |
        |------------|-------|
        | `license`  | `int` |
        | `quantity` | `int` |

      - [ ] PUT /{license_id} (`PredefinedKitsController@updateLicense`) :: `StandardApiResponse<RawKit>`

        | param      | type  |
        |------------|-------|
        | `quantity` | `int` |

      - [ ] DELETE /{license_id} (`PredefinedKitsController@detachLicense`) :: `StandardApiResponse<RawKit>`
    - [ ] /{id}/models
      - [ ] GET (`PredefinedKitsController@indexModels`) :: `DataTable<KitElement>`
      - [ ] POST (`PredefinedKitsController@storeModel`) :: `StandardApiResponse<null | RawKit>`

        | param      | type  |
        |------------|-------|
        | `model`    | `int` |
        | `quantity` | `int` |

      - [ ] PUT /{model_id} (`PredefinedKitsController@updateModel`) :: `StandardApiResponse<RawKit>`

        | param      | type  |
        |------------|-------|
        | `quantity` | `int` |

      - [ ] DELETE /{model_id} (`PredefinedKitsController@detachModel`) :: `StandardApiResponse<RawKit>`
    - [ ] /{id}/accessories
      - [ ] GET (`PredefinedKitsController@indexAccessories`) :: `DataTable<KitElement>`
      - [ ] POST (`PredefinedKitsController@storeAccessory`) :: `StandardApiResponse<null | RawKit>`

        | param       | type  |
        |-------------|-------|
        | `accessory` | `int` |
        | `quantity`  | `int` |

      - [ ] PUT /{accessory_id} (`PredefinedKitsController@updateAccessory`) :: `StandardApiResponse<RawKit>`

        | param      | type  |
        |------------|-------|
        | `quantity` | `int` |

      - [ ] DELETE /{accessory_id} (`PredefinedKitsController@detachAccessory`) :: `StandardApiResponse<RawKit>`
    - [ ] /{id}/consumables
      - [ ] GET (`PredefinedKitsController@indexConsumables`) :: `DataTable<KitElement>`
      - [ ] POST (`PredefinedKitsController@storeConsumable`) :: `StandardApiResponse<null | RawKit>`

        | param        | type  |
        |--------------|-------|
        | `consumable` | `int` |
        | `quantity`   | `int` |

      - [ ] PUT /{consumable_id} (`PredefinedKitsController@updateConsumable`) :: `StandardApiResponse<RawKit>`

        | param      | type  |
        |------------|-------|
        | `quantity` | `int` |

      - [ ] DELETE /{consumable_id} (`PredefinedKitsController@detachConsumable`)
