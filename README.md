# USDA.NET
.NET client for USDA APIs

## Usage
```csharp
using USDA.NET.Food;

var searchOptions = new SearchOptions{Q="dr pepper"};
var searchResult = await _classUnderTest.SearchAsync(searchOptions, new PaginationOptions());
var firstSearchItem = searchResult.List.Item.Single(x => x.Ndbno == "45255203");
```

## References
 - [USDA documentation](https://ndb.nal.usda.gov/ndb/doc/index)
