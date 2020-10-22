<p align="center"><img src="assets/location_tracking.svg?raw=true" width="350" alt="Logo"></p>

# Dime.Maps

![Build Status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/dimenics.dime-maps?branchName=master) ![Code coverage](https://img.shields.io/azure-devops/coverage/dimenicsbe/utilities/151/master) [![Dime.Maps package in Dime.Scheduler feed in Azure Artifacts](https://feeds.dev.azure.com/dimenicsbe/_apis/public/Packaging/Feeds/a7b896fd-9cd8-4291-afe1-f223483d87f0/Packages/0236d6de-7ac3-4a7d-8270-48e9c1d66c8e/Badge)](https://dev.azure.com/dimenicsbe/Utilities/_packaging?_a=package&feed=a7b896fd-9cd8-4291-afe1-f223483d87f0&package=0236d6de-7ac3-4a7d-8270-48e9c1d66c8e&preferRelease=true) [![Dime.Maps.Ptv package in Dime.Scheduler feed in Azure Artifacts](https://feeds.dev.azure.com/dimenicsbe/_apis/public/Packaging/Feeds/a7b896fd-9cd8-4291-afe1-f223483d87f0/Packages/8b64406c-23b3-43a0-928a-cd2a01fadd72/Badge)](https://dev.azure.com/dimenicsbe/Dime.Scheduler%20V2/_packaging?_a=package&feed=a7b896fd-9cd8-4291-afe1-f223483d87f0&package=8b64406c-23b3-43a0-928a-cd2a01fadd72&preferRelease=true)

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