# eShopLite.StoreFx Modernization Assessment Plan

## Scope

Assess `src/eShopLite.StoreFx` for modernization from ASP.NET MVC 5 on .NET Framework 4.8 to ASP.NET Core MVC on .NET 10.

## Current State

- Project type: legacy ASP.NET Web Application project using non-SDK-style MSBuild.
- Target framework: .NET Framework 4.8.
- Web framework: ASP.NET MVC 5 with `System.Web` hosting.
- Startup model: `Global.asax` plus `App_Start` classes for routing, filters, and bundling.
- Dependency injection: Autofac with `Autofac.Mvc5` integration.
- Data access: Entity Framework 6 with `DbContext`, `DbModelBuilder`, and `DropCreateDatabaseIfModelChanges` seed initialization.
- Configuration: `Web.config`, config transforms, assembly binding redirects, CodeDOM compiler settings, and EF configuration sections.
- Package management: `packages.config` and direct assembly references.

## Key Modernization Findings

1. This is not a direct retargeting exercise. The `System.Web` and MVC 5 dependencies require an ASP.NET Core migration.
2. The business logic is small and clean: one MVC controller, one service, two model types, and simple data retrieval.
3. The highest-risk changes are framework infrastructure changes: hosting, routing, configuration, Razor setup, bundling, and EF migration.
4. Autofac is not required for the current dependency graph; built-in ASP.NET Core dependency injection should be sufficient.
5. The views are mostly portable, but `_Layout.cshtml` uses `System.Web.Optimization` helpers that must be replaced.
6. The current project does not build with `dotnet build` because it imports legacy Visual Studio WebApplication targets.
7. The local machine has .NET SDK 10.0.300 and ASP.NET Core runtime 10.0.8 installed, so it is ready for the target framework once the project is converted.

## Recommended Target Architecture

- SDK-style project using `Microsoft.NET.Sdk.Web`.
- Target framework `net10.0`.
- ASP.NET Core MVC with minimal hosting in `Program.cs`.
- Built-in dependency injection registrations for `IStoreService` and `IStoreDbContext`.
- EF Core 10 for data access.
- `appsettings.json` for application configuration.
- Static files served through ASP.NET Core middleware.
- Razor `_ViewImports.cshtml` for common namespaces and tag helpers.

## Proposed Migration Steps

1. Create or convert to an SDK-style ASP.NET Core web project targeting `net10.0`.
2. Replace `Global.asax`, `RouteConfig`, `FilterConfig`, and `BundleConfig` with `Program.cs` middleware and endpoint routing.
3. Replace `System.Web.Mvc` controller references with `Microsoft.AspNetCore.Mvc`.
4. Register services with ASP.NET Core built-in DI:
   - `IStoreService` to `StoreService`
   - `StoreDbContext`
   - `IStoreDbContext` to the scoped `StoreDbContext` instance
5. Migrate EF6 code to EF Core 10:
   - Replace `System.Data.Entity` with `Microsoft.EntityFrameworkCore`.
   - Replace `DbModelBuilder` with `ModelBuilder`.
   - Replace EF6 initializer seeding with EF Core `HasData`, migrations, or startup seeding.
6. Move connection strings and app settings from `Web.config` to `appsettings.json`.
7. Remove obsolete Web.config infrastructure:
   - binding redirects
   - CodeDOM compiler settings
   - MVC 5 Razor view configuration
   - EF6 config sections
8. Replace MVC 5 bundling helpers in `_Layout.cshtml` with static CSS and JavaScript references, or introduce an ASP.NET Core-compatible asset pipeline.
9. Add `_ViewImports.cshtml` with ASP.NET Core MVC tag helpers.
10. Validate by building the `net10.0` project, running the app, and checking these routes:
    - `/`
    - `/Home/Products`
    - `/Home/Stores`

## Validation Plan

- Confirm `dotnet --info` reports a .NET 10 SDK.
- Build the migrated project with `dotnet build`.
- Run the migrated app with `dotnet run`.
- Smoke test the home, products, and stores pages in a browser.
- Confirm static assets load correctly.
- Confirm seeded product and store data appears.
- Fix all build warnings in modified projects before considering the migration complete.

## Risks And Decisions

- Decide whether to use EF Core SQL Server for parity with the original LocalDB connection string or EF Core InMemory for workshop/demo simplicity.
- Decide whether to preserve namespace names for minimal code churn or rename from `eShopLite.StoreFx` to a target `StoreCore` namespace.
- Decide whether to remove Autofac entirely or keep Autofac through ASP.NET Core integration. Current code does not require Autofac.
- If a pre-migration legacy build is required, use Visual Studio MSBuild or a Developer Command Prompt because `dotnet build` cannot build this legacy Web Application project as-is.

## Assessment Verdict

Proceed with modernization to .NET 10 as an ASP.NET Core MVC migration. The codebase is small and suitable for a focused migration. The main work is replacing legacy ASP.NET infrastructure with ASP.NET Core equivalents while preserving controller, service, model, and view behavior.