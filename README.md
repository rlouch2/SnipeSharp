# SnipeSharp

A .NET wrapper for the Snipe IT API written (poorly) in C# for C# and PowerShell.

> ## Notes for users of this fork
>
> Disregard the prereqs and installation below. You need the .NET Core SDK, version 3 or higher.
> VS Code tasks are provided for build and testing.
>

## Before You Dive In

The goal of this project is to give easy access to all endpoints of the Snipe IT API via C# and PowerShell. With that said, this build is currently a rough demo. Most of the endpoints work as expected but plan on things breaking or not working 100%.

This project was built to support my own needs. As such, features are being worked on in the order I personally need them. However, if you want a feature or find a bug please open an issue. 

If you see something we've done that should be done differently, we encourage you to let us know.

### Prerequisites

```
A Working Install of Snipe IT V4.6.15+
```

## Installation

```
nuget install SnipeSharp
```

## Usage

```csharp
SnipeItApi snipe = new SnipeItApi {
    Token = "XXXXXXXX",
    Uri = new Uri("http://xxxxx.com/api/v1")
};
```

> ```powershell
> PS C:\> Connect-SnipeIT -Token "XXXXXXXX" -Uri "http://xxxxx.com/api/v1"
> ```

Each endpoint has its own manager assigned to the SnipeItApi object.  Example, SnipeItApi.Assets 

Each endpoint has a common set of actions. Additional methods for each endpoint are made available as extensions in the EndPointExtensions class.

##### Common Actions
Return all objects at this end point
```csharp
snipe.Assets.GetAll()
```

> ```powershell
> PS C:\> Get-Asset
> ```

Or, in a generic form:
```csharp
snipe.GetEndPoint<T>().GetAll()
```

Find all objects matching certain filtering criteria 
```csharp
snipe.GetEndPoint<T>().FindAll(ISearchFilter filter)
```

> ```powershell
> PS C:\> Find-Asset @filter
> ```

Find first object matching search criteria
```csharp
snipe.GetEndPoint<T>().FindOne(ISearchFilter filter)
```

Get object with ID
```csharp
snipe.GetEndPoint<T>().Get(int Id)
```

> ```powershell
> PS C:\> Get-Asset $Id
> ```

Search for object with given name
```csharp
snipe.GetEndPoint<T>().Get(string name)
```

Create an object
```csharp
snipe.GetEndPoint<T>().Create(T item)
```

> ```powershell
> PS C:\> New-Asset @properties
> ```

Update an object
```csharp
snipe.GetEndPoint<T>().Update(T item)
```

> ```powershell
> PS C:\> Set-Asset @properties
> ```

Delete an object
```csharp
snipe.GetEndPoint<T>().Delete(int id)
```

> ```powershell
> PS C:\> Remove-Asset $Id
> ```

## Examples

Create a new asset
```csharp
var asset = new Asset {
    Name = "Loaner1",
    AssetTag = "12345678",
    Model = snipe.Models.Get("Lenovo"),
    Status = snipe.StatusLabels.Get("Ready to Deploy"),
    Location = snipe.Locations.Get("Maine")
};

snipe.Assets.Create(asset);
```

> ```powershell
> PS C:\> New-Asset -Name "Loaner1" -AssetTag 12345678 -Model Lenovo -Status "Ready to Deploy" -Location Maine
> ```

Update an Asset
```csharp
var asset = snipe.Assets.Get("Loaner1");
asset.Serial = "1i37dpc3k";
snipe.Assets.Update(asset);
```

> ```powershell
> PS C:\> Set-Asset -Name "Loaner1" -NewSerial "1i37dpc3k"
> ```

Update an asset with a Custom Field
```csharp
var asset = snipe.Assets.Get("BurnerPhone-1234");
asset.CustomFields["_snipeit_imei_number_37"] = "01-234567-890123-4"
snipe.Assets.Update(asset);
```

> ```powershell
> PS C:\> Set-Asset -Name "BurnerPhone-1234" -CustomField @{ "_snipeit_imei_number_37" = "01-234567-890123-4" }
> ```

Get all assets from made by a certain manufacturer
```csharp
var filter = new AssetSearchFilter {
    Manufacturer = snipe.Manufacturers.Get("Lenovo")
};

var result = snipe.Assets.FindAll(filter);
```

> ```powershell
> PS C:\> Find-Asset -Manufacturer Lenovo
> ```
## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](./SnipeSharp/tags).

## Authors

* **Matthew 'Barry' Carey** - *Initial work* - [BarryCarey](https://github.com/barrycarey)
* **Christian LaCourt** - *Cleaning, Refactoring, and PowerShell* [cofl](https://github.com/cofl)

See also the list of [contributors](./SnipeSharp/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* [Snipe](https://github.com/snipe) - https://snipeitapp.com
