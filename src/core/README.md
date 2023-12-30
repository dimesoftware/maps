<div align="center">
<h1> Turtle Route </h1>
</div>

This is a project that supports the map functionalities in Dime.Scheduler. Most notably, the geocoding service is essential to the performance of the map as it eliminates the need for ad-hoc geocoding.

## Installation

Use the package manager NuGet to install Dime.Maps and Dime.Maps.Ptv:

```cli
dotnet add package TurtleRoute
```

## Usage

``` csharp
using TurtleRoute;

 Geocoder api = new("MYTOKEN");
 GeoCoordinate? address = await api.GeocodeAsync("Katwilgweg", "2", "2050", "Antwerpen", "", "BE");
```

## Contributing

![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)

Pull requests are welcome. Please check out the contribution and code of conduct guidelines.

## Local development

- You must have Visual Studio 2022 Community or higher.
- The dotnet cli is also highly recommended.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)