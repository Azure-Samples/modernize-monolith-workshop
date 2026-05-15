# 🖥️ Migrate a WinForms Application

> 🎓 **Optional Capstone Module** — This module is a bonus chapter for teams with desktop applications in their portfolio. The core workshop concludes with Module 8.

Modernizing eShopLite does not stop at the storefront. In this optional capstone, you will migrate **the last legacy client in the eShopLite estate**: a WinForms-based internal admin tool that still supports day-to-day operations.

This module takes approximately **45-60 minutes**.

## 📋 What You'll Learn

In this module, you will learn how to:

- migrate a **WinForms** app from **.NET Framework 4.8** to **.NET 10**
- convert an old-style project file to **SDK-style** with `UseWindowsForms=true`
- handle **designer files, resources, and layout drift** after migration
- replace **App.config** and manual object creation with **appsettings.json**, **Generic Host**, and **dependency injection**
- modernize HTTP and serialization code with **IHttpClientFactory** and **System.Text.Json**
- use **GitHub Copilot** and **GitHub Copilot App Modernization** to clean up migrated code without changing the user experience

## 🧭 Why This Module Matters

Real modernization work includes more than websites and APIs. Many teams still rely on internal back-office tools for catalog management, support, fulfillment, and operations.

Module 9 closes that gap. The public-facing eShopLite experience is modernized, but the operations team still depends on a legacy desktop app. This module shows how to modernize that client while preserving the workflow people already know.

## ✅ Prerequisites

Before you begin, make sure you have:

- **Visual Studio 2022 or later** with the **.NET desktop development** workload installed
- the **.NET 10 SDK** installed
- the **.NET Framework 4.8 Developer Pack** installed
- the eShopLite **Products API** running on `https://localhost:7102/` if you want live product data during the exercise

> ‼️ **IMPORTANT**
>
> This module is **Windows-only**. Your migrated project must target `net10.0-windows` and include `<UseWindowsForms>true</UseWindowsForms>`.

## 🧪 StartSample Overview

The **StartSample** is a .NET Framework 4.8 WinForms admin application used by eShopLite staff.

- **Solution:** `9-migrate-winforms\StartSample\eShopLiteAdminFx.sln`
- **Project:** `eShopLite.AdminFx`
- **UI:** `MenuStrip`, `StatusStrip`, `TabControl`, `DataGridView`, and modal edit dialogs
- **Features:** product list, add/edit/delete workflow, and a read-only orders view
- **Legacy patterns:** old-style `.csproj`, `packages.config`, `App.config`, direct `HttpClient`, `Newtonsoft.Json`, and manual dependency wiring in `Program.cs`

The companion **CompleteSample** shows the migrated end state:

- **Solution:** `9-migrate-winforms\CompleteSample\eShopLiteAdmin.sln`
- **Project:** `eShopLite.Admin`
- **Target:** `net10.0-windows`
- **Patterns:** SDK-style project, `appsettings.json`, Generic Host, DI, `IHttpClientFactory`, and `System.Text.Json`

## 📚 Instructions

### Step 1: Run the legacy app and establish a baseline

1. Open **Visual Studio 2022**.
2. Open `9-migrate-winforms\StartSample\eShopLiteAdminFx.sln`.
3. Restore packages if Visual Studio prompts you to do so.
4. Press **F5** to run the application.
5. Explore both tabs:
   - **Products**: refresh the grid, add a product, edit a product, and delete a product
   - **Orders**: confirm the read-only order list loads from `Data\orders.json`
6. Note the legacy implementation details before you change anything:
   - settings come from `App.config`
   - services are created manually in `Program.cs`
   - HTTP calls use `new HttpClient()` directly
   - JSON uses `Newtonsoft.Json`

> **Note**
>
> In the current workshop modules, the Products API is read-only. Product create/update/delete operations still update the app's **local working copy**, so you can validate the desktop workflow even when the backend does not expose write endpoints yet.

### Step 2: Let tooling handle the mechanical migration

Your goal in this step is to get from an old-style WinForms project to a **building .NET 10 WinForms project**.

Microsoft now recommends **GitHub Copilot App Modernization** for guided modernization workflows. You can still use **.NET Upgrade Assistant** if you want a more traditional project-conversion experience.

#### Option A: Use .NET Upgrade Assistant

1. Run Upgrade Assistant against `eShopLite.AdminFx.csproj`.
2. Choose the project conversion flow that updates the project to modern .NET.
3. Target **`net10.0-windows`**.
4. Let the tool convert `packages.config` entries into **PackageReference** where possible.
5. Build immediately after conversion so you can capture migration errors while the changes are fresh.

#### Option B: Use GitHub Copilot App Modernization

1. Open the StartSample in Visual Studio.
2. Start **GitHub Copilot App Modernization**.
3. Let it run through **Assessment → Planning → Execution**.
4. Accept the project-system changes needed to move the app to **.NET 10**.
5. Build the project and review the remaining WinForms-specific issues.

A successful mechanical migration typically changes the project file shape from this:

```xml
<!-- Before -->
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Newtonsoft.Json" />
  </ItemGroup>
  <ItemGroup>
    <None Include="packages.config" />
  </ItemGroup>
</Project>
```

To this:

```xml
<!-- After -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net10.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Hosting" Version="10.0.0" />
    <PackageReference Include="Microsoft.Extensions.Http" Version="10.0.0" />
  </ItemGroup>
</Project>
```

### Step 3: Fix WinForms-specific migration issues

Once the project builds, do a WinForms-focused cleanup pass.

1. Open each form in the designer and confirm it still renders correctly.
2. Check every `.Designer.cs` file for:
   - missing event hookups
   - broken `InitializeComponent()` code
   - control names that no longer match the code-behind
3. Verify that content files such as `Data\orders.json` still copy to the output folder.
4. Compare the migrated UI with the original app and look for:
   - font or spacing changes
   - tab layout drift
   - toolbar or `StatusStrip` rendering differences
5. If a form is too damaged to fix confidently, compare it with the equivalent file in **CompleteSample**.

> ‼️ **IMPORTANT**
>
> Treat designer files carefully. Fix small issues surgically, but avoid large hand-written rewrites unless you have no other choice. The fastest path is usually: restore the designer to a buildable state, then verify the layout visually.

Also keep these .NET 10 WinForms migration topics in mind:

- `StatusStrip` now uses the **System** render mode by default
- some APIs are now obsolete and should be replaced during cleanup
- `System.Drawing` behavior changed in some failure paths, so exception handling may need review

### Step 4: Modernize configuration and app startup

After the project is running on .NET 10, replace the legacy startup and configuration patterns.

In the .NET Framework app, `Program.cs` manually reads `App.config` and constructs services directly:

```csharp
var settings = LoadSettings();
var productApiClient = new ProductApiClient(settings.ProductsApiBaseUrl, settings.ProductsApiTimeoutSeconds);
var orderRepository = new OrderRepository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.OrdersFilePath));

Application.Run(new MainForm(productApiClient, orderRepository, settings));
```

In the modernized app, move those responsibilities into **Generic Host**, configuration, and DI:

```csharp
ApplicationConfiguration.Initialize();

var builder = Host.CreateApplicationBuilder();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services
    .Configure<AdminOptions>(builder.Configuration.GetSection("Admin"))
    .AddSingleton(sp => sp.GetRequiredService<IOptions<AdminOptions>>().Value)
    .AddSingleton<OrderRepository>()
    .AddSingleton<MainForm>();

builder.Services.AddHttpClient<ProductApiClient>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<AdminOptions>>().Value;
    client.BaseAddress = new Uri(options.ProductsApiBaseUrl, UriKind.Absolute);
    client.Timeout = TimeSpan.FromSeconds(options.ProductsApiTimeoutSeconds);
});

using var host = builder.Build();
Application.Run(host.Services.GetRequiredService<MainForm>());
```

Move your settings from `App.config`:

```xml
<appSettings>
  <add key="ProductsApiBaseUrl" value="https://localhost:7102/" />
  <add key="ProductsApiTimeoutSeconds" value="10" />
  <add key="OrdersFilePath" value="Data\orders.json" />
</appSettings>
```

To `appsettings.json`:

```json
{
  "Admin": {
    "ProductsApiBaseUrl": "https://localhost:7102/",
    "ProductsApiTimeoutSeconds": 10,
    "OrdersFilePath": "Data\\orders.json"
  }
}
```

### Step 5: Modernize data access and HTTP code

This sample focuses on modernizing the client-side data access patterns that are common in WinForms apps:

- `Newtonsoft.Json` → `System.Text.Json`
- direct `new HttpClient()` wiring → `IHttpClientFactory`
- manual settings objects → options binding
- synchronous, tightly coupled plumbing → cleaner async service calls

For example, the legacy client fetches products like this:

```csharp
var json = await _httpClient.GetStringAsync("api/products/").ConfigureAwait(false);
var products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
```

The modernized client uses `HttpClientFactory`-backed services and `System.Text.Json` helpers:

```csharp
var products = await httpClient.GetFromJsonAsync<List<Product>>(
    "api/products/",
    SerializerOptions,
    cancellationToken) ?? [];
```

And instead of writing JSON through `StreamWriter` plus `JsonConvert.SerializeObject`, the modernized app persists its local working copy like this:

```csharp
await using var stream = File.Create(_cacheFilePath);
await JsonSerializer.SerializeAsync(stream, products, SerializerOptions, cancellationToken);
```

### Step 6: Use GitHub Copilot for cleanup

Now that the app runs on .NET 10, use **GitHub Copilot** to help with the manual polish work that migration tools do not finish for you.

Good cleanup targets for this module include:

- simplifying event handlers and expression-bodied members
- improving async flows without freezing the UI thread
- extracting service logic out of forms
- tightening nullability and modern C# usage
- removing leftover compatibility code from the initial migration

Useful prompt ideas:

- `Review this migrated WinForms form and suggest safe .NET 10 cleanup changes without redesigning the UI.`
- `Convert this legacy JSON and HttpClient code to System.Text.Json and IHttpClientFactory.`
- `Help me modernize this WinForms Program.cs to use Generic Host and DI.`

### Step 7: Verify functional parity

Before you compare your work with **CompleteSample**, verify that the migrated app still behaves like the original.

## ✅ Verification Checklist

Use this checklist when your migration is complete:

- [ ] The app launches successfully on **.NET 10**
- [ ] The project targets **`net10.0-windows`** and includes `<UseWindowsForms>true</UseWindowsForms>`
- [ ] The **Products** grid loads from the Products API or the local cache
- [ ] Add, edit, and delete actions work in the desktop workflow
- [ ] The **Orders** tab loads sample order data correctly
- [ ] `appsettings.json` is copied to the output folder and read successfully
- [ ] `Data\orders.json` and other local data files load correctly
- [ ] Forms still open in the WinForms designer without broken partial classes
- [ ] The layout remains usable after the migration with no major font or spacing regressions

## 🩹 Troubleshooting

### Designer drift or broken forms

- Rebuild the solution first.
- Open the form in the designer and look for control-name mismatches.
- Compare the designer file with **CompleteSample** if event wiring or resource references are missing.

### Missing packages after migration

- Make sure all `packages.config` dependencies were converted or replaced.
- Prefer supported modern packages over carrying forward old compatibility packages unchanged.

### The app builds but the UI looks different

- Review fonts, anchoring, docking, and autoscaling behavior.
- Pay special attention to `StatusStrip`, toolbars, and grid layout.

### The app does not run on macOS or Linux

- That is expected. WinForms on modern .NET is still **Windows-only**.

### Products do not save back to the API

- That is expected in the current workshop flow.
- The desktop app keeps a **local working copy** so you can still validate CRUD behavior while the API remains read-only.

## 🎯 What You Accomplished

By finishing this module, you practiced the real-world work of desktop modernization:

- moving a WinForms app from **.NET Framework 4.8** to **.NET 10**
- converting a legacy project system to modern SDK-style conventions
- repairing designer and resource issues that migration tools cannot fully solve
- introducing **configuration**, **dependency injection**, and **modern HTTP patterns** into a desktop app
- using **GitHub Copilot App Modernization** and **GitHub Copilot** to accelerate both the first migration pass and the cleanup that follows

You now have a repeatable pattern for modernizing internal desktop tools without forcing a full UI rewrite.

## 🚀 Optional Next Steps

If you want to keep going after this module:

- point the admin app at APIs running under your **Aspire** environment from earlier modules
- move more form logic into dedicated services
- add stronger validation and logging
- evolve the local data workflow into a fuller database-backed admin experience

---
[← Previous: Add AI Capabilities](../8-add-ai-capabilities/README.md) | [🎉 Workshop Complete! Back to Main →](../README.md)
