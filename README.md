# Common Shop - WebAPI Gateway

![Open issues](https://img.shields.io/github/issues/weisong0908/common-shop-webapi-gateway)
![Last commit](https://img.shields.io/github/last-commit/weisong0908/common-shop-webapi-gateway)

![active releases](https://github.com/weisong0908/common-shop-webapi-gateway/workflows/active%20releases/badge.svg)

## About This Project

This is the web API gateway for an imaginary e-commerce website called "**Common Shop**". It is built with .NET 5.

CICD is implemented with Github Actions and the swagger documentation of the web API gateway is hosted [here](https://common-shop-webapi.tengweisong.com/swagger/index.html).

## Getting Started

This is a .NET 5 project written in C#. To build this project simply clone this repository, restore nuget packages, and build.

### Restore nuget packages

```
dotnet restore
```

### Compiles and run the application

```
dotnet run
```

### Compiles for production

```
dotnet build
```

### Dockerise for deployment (Optional)

```
docker build --tag common-shop-webapi-gateway .
```
