Sample Project ASP.NET Core with ElasticSearch 
==============================================

Project using an API ASP.NET Core MVC 1.1 
to connect to ElasticSearch using NEST library.

Includes a three layer app with three projects:

- Web Api
- Business
- Data access

It also includes sample Fiddler sessions and sample json data files at the root of the repository.

Nest can be installed using [Nuget](https://www.nuget.org/packages/Nest)
or with

```
dotnet add Project.csproj package NEST
```