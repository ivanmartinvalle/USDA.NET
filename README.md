# USDA.NET
.NET client for USDA APIs

## Installation
```sh
dotnet add package USDA.NET --version 0.0.1-beta # or latest version
```

## Usage
```csharp
using USDA.NET.Food;

using (var compositionClient = new FoodCompositionClient(APIKey))
{


	var searchResult = await compositionClient.SearchAsync(new SearchOptions
	{
	    SearchTerm = "dr pepper"
	});

	var result = await compositionClient.ReportAsync(new ReportOptions
	{
		NDBNumbers = new List<string>
		{
			searchResult.List.Item.First().NDBNumber
		}
	});
}
```

## Releasing an upgraded NuGet package
 - Update PackageVersion in USDA.NET.csproj
 - `dotnet pack -c Release src/USDA.NET/USDA.NET.csproj`
 - Upload src/USDA.NET/bin/Release/USDA.NET.*.nupkg to [NuGet](https://www.nuget.org/packages/manage/upload)

## References
 - [USDA documentation](https://ndb.nal.usda.gov/ndb/doc/index)
