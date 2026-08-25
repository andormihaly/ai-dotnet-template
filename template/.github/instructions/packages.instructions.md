---
applyTo: "**/*.csproj,Directory.Build.props,Directory.Packages.props,global.json"
---

# Package Management

## Package Versions

- **For `Microsoft.*` packages targeting .NET 10, use compatible 10.x versions.** Framework-related package versions should remain aligned with the target runtime.
- **Use EF Core 10.x and compatible 10.x database providers.**
- **For third-party packages, use a stable version that supports .NET 10.**
- **Prefer stable releases over preview, RC, or prerelease versions** unless the project explicitly requires preview functionality.

## Adding Packages

- **Prefer `dotnet add package <PackageName>` when adding NuGet dependencies.** Let NuGet resolve an appropriate compatible version rather than guessing version numbers.
- **Do not introduce a new package when the required functionality is already reasonably provided by .NET or an existing project dependency.**

## Version Verification

- **Verify package versions rather than guessing them.** Use NuGet tooling or NuGet.org when the appropriate version is uncertain.
- **Never downgrade an existing package** unless explicitly requested or required to resolve a known compatibility issue.
- **Preserve existing package versions when modifying unrelated functionality.**

## .NET 10 Alignment

- Target framework: `net10.0`.
- `Microsoft.*` and `System.*` framework-related packages should remain compatible with .NET 10.
- EF Core and its providers should use compatible 10.x versions.
- ASP.NET Core testing packages should remain compatible with .NET 10.
- Third-party packages should use stable versions that explicitly support .NET 10.
