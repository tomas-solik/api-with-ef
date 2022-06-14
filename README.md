# Code first and entity framework with migrations
.NET 6 API with Entity framework code first demo

To use migrations:
dotnet tool install --global dotnet-ef
dotnet ef database drop

In project folder:
dotnet ef migrations add InitialCreate
