# USDA.NET
.NET client for USDA APIs

## Usage
```csharp
using USDA.NET.Food;

var searchOptions = new SearchOptions{Q="dr pepper"};
var searchResult = await _classUnderTest.SearchAsync(searchOptions, new PaginationOptions());
var firstSearchItem = searchResult.List.Item.Single(x => x.Ndbno == "45255203");
```

## Releasing an upgraded NuGet package
 - Update PackageVersion in USDA.NET.csproj
 - `dotnet pack -c Release src/USDA.NET/USDA.NET.csproj`
 - Upload src/USDA.NET/bin/Release/USDA.NET.*.nupkg to [NuGet](https://www.nuget.org/packages/manage/upload)

## References
 - [USDA documentation](https://ndb.nal.usda.gov/ndb/doc/index)
