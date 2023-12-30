<div align="center"><img src="assets/logo.png" alt="Logo"></div>

<div align="center">
<h1> Turtle Route </h1>
</div>

## Introduction

This is a project that supports the map functionalities in Dime.Scheduler. Most notably, the geocoding service is essential to the performance of the map as it eliminates the need for ad-hoc geocoding.

## Getting Started

- You must have Visual Studio 2019 Community or higher.
- The dotnet cli is also highly recommended.

## About this project

The Dime.Maps project holds the contracts whereas Dime.Maps.Ptv is an implementation of the geocoding service using PTV XLocate.

## Installation

Use the package manager NuGet to install Dime.Maps and Dime.Maps.Ptv:

```cli
dotnet add package Dime.Maps
dotnet add package Dime.Maps.Ptv
```

## Usage

``` csharp
using Dime.Maps;

PtvGeocoder api = new PtvGeocoder(_url, _user, _token);
GeoCoordinate? address =  await api.GeocodeAsync("Schaliënhoevedreef", "20T", "2800", "Mechelen", "", "BE");
```

## Contributing

![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)

Pull requests are welcome. Please check out the contribution and code of conduct guidelines.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)