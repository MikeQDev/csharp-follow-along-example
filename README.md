# C# Example

Follow-along with the C# Fundamentals Course from PluralSight

## Usage

Running: `dotnet run --project src/GradeBook/`

Testing: `dotnet test`

## Notes

When writing test cases, had to reference main GradeBook project with `dotnet add reference ../../src/GradeBook/`, which updated `GradeBook.Tests.csproj`

A `solution` can hold multiple `projects`, which can hold multiple `namespaces`

Create a solution: `dotnet new sln && dotnet sln add src/GradeBook/GradeBook.csproj && dotnet sln add test/GradeBook.Tests/GradeBook.Tests.csproj`

`struct` types is a value type (bool, int, etc.), classes as reference type

Private variables start with lowercase, public variables start with uppercase

Instead of explicitly closing streams that implement IDisposable, wrap them in a using block like so: `using(StreamReader file = new($"./{Name}.gradebook")){ ... }` ; GC will clean the resource once execution leaves the scope
