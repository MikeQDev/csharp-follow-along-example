# C# Example

Follow-along with the C# Fundamentals Course from PluralSight

## Usage

Running: `dotnet run --project src/GradeBook/`

Testing: `cd test/GradeBook.Tests/ && dotnet test && cd -`

## Notes

When writing test cases, had to reference main GradeBook project with `dotnet add reference ../../src/GradeBook/`, which updated `GradeBook.Tests.csproj`

A `solution` can hold multiple `projects`, which can hold multiple `namespaces`
