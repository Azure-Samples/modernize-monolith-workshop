# eShopLite.StoreFx .NET 10 Upgrade Plan

## Goal

Upgrade `src/eShopLite.StoreFx` from ASP.NET MVC 5 on .NET Framework 4.8 to ASP.NET Core MVC on .NET 10 while preserving the existing user-visible behavior:

- Home page at `/`
- Products page at `/Home/Products`
- Stores page at `/Home/Stores`
- Product and store seed data
- Existing Bootstrap-based layout and static images

## Target State

- SDK-style ASP.NET Core web project using `Microsoft.NET.Sdk.Web`.
- Target framework `net10.0`.
- Minimal hosting model in `Program.cs`.
- ASP.NET Core MVC controllers and Razor views.
- Built-in ASP.NET Core dependency injection.
- EF Core 10 data access.
- Configuration in `appsettings.json`.
- Static file serving through ASP.NET Core middleware.
- No dependency on `System.Web`, `Global.asax`, MVC 5, Web.config transforms, binding redirects, or `packages.config`.

## Upgrade Strategy

Use a side-by-side migration rather than trying to directly retarget the existing Web Application project. The current project is tightly coupled to legacy ASP.NET Web Application MSBuild targets and `System.Web`, so a new ASP.NET Core project is the cleanest path.

Recommended project name: `eShopLite.StoreCore`.

Recommended namespace approach: preserve existing model and controller behavior first, then optionally rename namespaces after the migration is stable.

## Phase 1: Prepare Baseline

1. Confirm the current source project is `src/eShopLite.StoreFx/eShopLite.StoreFx.csproj`.
2. Record the routes and expected behavior:
   - `/` renders the home page.
   - `/Home/Products` renders seeded products.
   - `/Home/Stores` renders seeded stores.
3. Confirm the .NET 10 SDK is installed with `dotnet --info`.
4. If a legacy build baseline is required, build with Visual Studio MSBuild or Developer Command Prompt. Do not rely on `dotnet build` for the pre-migration Web Application project because it imports legacy WebApplication targets.

## Phase 2: Create The .NET 10 Project

1. Create a new ASP.NET Core MVC project under `src/eShopLite.StoreCore`.
2. Set the project file to use:
   - `Sdk="Microsoft.NET.Sdk.Web"`
   - `TargetFramework` = `net10.0`
   - `Nullable` = `enable`
   - `ImplicitUsings` = `enable`
3. Add required package references:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer` for LocalDB parity, or `Microsoft.EntityFrameworkCore.InMemory` for workshop/demo simplicity
   - `Newtonsoft.Json` only if existing JSON behavior requires it
4. Do not carry forward MVC 5 packages such as `Microsoft.AspNet.Mvc`, `Microsoft.AspNet.Razor`, `Microsoft.AspNet.WebPages`, `Microsoft.AspNet.Web.Optimization`, `WebGrease`, or `Antlr`.

## Phase 3: Migrate Hosting And Startup

1. Replace `Global.asax` and `Global.asax.cs` with `Program.cs`.
2. Configure services in `Program.cs`:
   - `builder.Services.AddControllersWithViews()`
   - EF Core `StoreDbContext`
   - `IStoreService` to `StoreService`
   - `IStoreDbContext` to the scoped `StoreDbContext`
3. Configure middleware in `Program.cs`:
   - HTTPS redirection
   - static files
   - routing
   - authorization, if needed
   - default controller route
4. Replace `RouteConfig.RegisterRoutes` with `app.MapDefaultControllerRoute()` or an equivalent route pattern.
5. Do not migrate `FilterConfig` unless custom filters are added later. The current project only registers MVC defaults.

## Phase 4: Migrate Controllers And Services

1. Copy `Controllers/HomeController.cs` into the new project.
2. Change MVC references from `System.Web.Mvc` to `Microsoft.AspNetCore.Mvc`.
3. Keep action names and return types compatible with MVC view rendering.
4. Copy `Services/StoreService.cs` into the new project.
5. Preserve `IStoreService.GetProducts()` and `IStoreService.GetStores()` behavior.
6. Keep constructor injection for `IStoreService` and `IStoreDbContext`.

## Phase 5: Migrate Data Access

1. Copy `Models/Product.cs` and `Models/StoreInfo.cs` into the new project.
2. Replace EF6 namespaces:
   - `System.Data.Entity` to `Microsoft.EntityFrameworkCore`
   - remove `System.Data.Entity.ModelConfiguration.Conventions`
3. Change `StoreDbContext` constructor to accept `DbContextOptions<StoreDbContext>`.
4. Replace `DbModelBuilder` with EF Core `ModelBuilder`.
5. Replace `DropCreateDatabaseIfModelChanges` seeding with one of these approaches:
   - EF Core `HasData` in `OnModelCreating`
   - startup seeding with a scoped `StoreDbContext`
   - EF Core migrations plus seed data
6. Add `SaveChanges()` to `IStoreDbContext` if seeding or future write behavior requires it.
7. Decide database provider:
   - Use SQL Server LocalDB to preserve the original connection string behavior.
   - Use InMemory if the migrated app is only intended for workshop demonstration.

## Phase 6: Migrate Configuration

1. Create `appsettings.json`.
2. Move the `StoreDbContext` connection string from `Web.config` into `ConnectionStrings` if using SQL Server.
3. Add standard ASP.NET Core logging configuration.
4. Remove obsolete configuration concepts:
   - binding redirects
   - CodeDOM compiler settings
   - EF6 provider sections
   - MVC 5 Razor host settings
   - Web.config transforms
5. Keep a minimal `Web.config` only if IIS hosting requires one after publish. Do not use it as the main application configuration source.

## Phase 7: Migrate Views And Static Assets

1. Copy existing Razor views into the new project.
2. Add `Views/_ViewImports.cshtml` with ASP.NET Core MVC tag helpers.
3. Keep `Views/_ViewStart.cshtml` if the layout path is unchanged.
4. Replace `_Layout.cshtml` bundling helpers:
   - Replace `@Styles.Render("~/Content/css")` with direct `<link>` tags.
   - Replace `@Scripts.Render("~/bundles/jquery")`, `@Scripts.Render("~/bundles/bootstrap")`, and `@Scripts.Render("~/bundles/modernizr")` with direct `<script>` tags.
5. Copy CSS, JavaScript, and image files into the ASP.NET Core static file layout.
6. Prefer `wwwroot` for static assets unless preserving the existing folder layout is required by the workshop.
7. Verify product images still resolve from the products page.

## Phase 8: Remove Legacy Infrastructure

After the ASP.NET Core project builds and runs, remove these from the migrated project scope:

- `Global.asax`
- `Global.asax.cs`
- `App_Start/RouteConfig.cs`
- `App_Start/FilterConfig.cs`
- `App_Start/BundleConfig.cs`
- `packages.config`
- MVC 5 package references
- Autofac MVC 5 integration
- EF6 package references
- `Views/Web.config`
- Web.config transforms

Keep the original `eShopLite.StoreFx` project intact until the migrated `eShopLite.StoreCore` project passes validation.

## Phase 9: Update The Solution

1. Add the new `eShopLite.StoreCore` project to `eShopLiteFx.sln`, or create a new solution if the workshop expects a renamed output.
2. Set the ASP.NET Core project as the startup project in IDE workflows.
3. Confirm `dotnet build` works from the solution or project path.
4. Confirm `dotnet run` works from the new project path.

## Phase 10: Validation

Run these checks before considering the upgrade complete:

1. `dotnet restore`
2. `dotnet build`
3. `dotnet run`
4. Browser smoke tests:
   - `/`
   - `/Home/Products`
   - `/Home/Stores`
5. Confirm the products page shows 9 seeded products.
6. Confirm the stores page shows 9 seeded stores.
7. Confirm Bootstrap styling loads.
8. Confirm product images load.
9. Confirm the app has no build warnings in modified projects.

## Acceptance Criteria

- The migrated project targets `net10.0`.
- The migrated project builds with `dotnet build`.
- The migrated app runs with `dotnet run`.
- The home, products, and stores routes render successfully.
- Seeded product and store data is available.
- Static CSS, JavaScript, and images load correctly.
- No MVC 5, `System.Web`, EF6, Autofac MVC 5, or `packages.config` dependencies remain in the migrated project.
- Obsolete Web.config-based application configuration is replaced by ASP.NET Core configuration.

## Suggested Task Breakdown

1. Create `eShopLite.StoreCore` ASP.NET Core MVC project targeting `net10.0`.
2. Port models, service, and controller.
3. Port EF6 data layer to EF Core 10.
4. Add `Program.cs` hosting, DI, routing, and middleware.
5. Port views and static assets.
6. Replace bundling helpers with static asset references.
7. Add `appsettings.json` configuration.
8. Update solution membership.
9. Build and fix compile errors.
10. Run smoke validation and fix runtime issues.

## Open Decisions

- Database provider: SQL Server LocalDB for parity, or InMemory for workshop simplicity.
- Project naming: keep `eShopLite.StoreFx` naming during migration, or rename to `eShopLite.StoreCore`.
- Static asset layout: preserve `Content`, `Scripts`, and `Images`, or move assets under `wwwroot`.
- Autofac: remove it, unless future requirements introduce complex container features.