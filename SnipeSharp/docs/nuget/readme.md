# SnipeSharp

A .NET wrapper for the Snipe IT API written (poorly) in C#.

## Before You Dive In

The goal of this project is to give easy access to all endpoints of the Snipe IT API via C#.  With that said, this build is currently a rough demo. Most of the endpoints work as expected but plan on things breaking or not working 100%.

This project was built to support my own needs.  As such features are being worked on in the order I personally need them.  However, if you want a feature or find a bug please open an issue. 

Final note, this is my first C# project of this scale.  I'm not up on all the best practices.  If you see something I've done that should be done differently, I encourge you to let me know. 

### Prerequisites

```
A Working Install of Snipe IT V4+
```

## Usage

```csharp
SnipeItApi snipe = new SnipeItApi {
    Token = "XXXXXXXX",
    Uri = new Uri("http://xxxxx.com/api/v1")
};
```

Each endpoint has its own manager assigned to the SnipeItApi object.  Example, SnipeItApi.Assets 

Each endpoint has a common set of actions. Additional methods for each endpoint are made available as extensions in the EndPointExtensions class.

##### Common Actions
Return all objects at this end point
```csharp
snipe.Assets.GetAll()
```

Or, in a generic form:
```csharp
snipe.GetEndPoint<T>().GetAll()
```

Find all objects matching certain filtering criteria 
```csharp
snipe.GetEndPoint<T>().FindAll(ISearchFilter filter)
```

Find first object matching search criteria
```csharp
snipe.GetEndPoint<T>().FindOne(ISearchFilter filter)
```

Get object with ID
```csharp
snipe.GetEndPoint<T>().Get(int Id)
```

Search for object with given name
```csharp
snipe.GetEndPoint<T>().Get(string name)
```

Create an object
```csharp
snipe.GetEndPoint<T>().Create(T item)
```

Update an object
```csharp
snipe.GetEndPoint<T>().Update(T item)
```

Delete an object
```csharp
snipe.GetEndPoint<T>().Delete(int id)
```

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

Update an Asset
```csharp
var asset = snipe.Assets.Get("Loaner1");
asset.Serial = "1i37dpc3k";
snipe.Assets.Update(asset);
```

Get all assets from made by a certain manufacturer
```csharp
var filter = new AssetSearchFilter {
    Manufacturer = snipe.ManufacturerManager.Get("Lenovo")
};

var result = snipe.Assets.FindAll(filter);
```
