# 🔄 Upgrade with .NET Upgrade Assistant

Let's upgrade our eShopLite application to modern .NET using the .NET Upgrade Assistant. 

The .NET Upgrade Assistant is a powerful tool available as both a Visual Studio extension and command-line interface that helps migrate .NET Framework, .NET Core, to the latest .NET version. 

![.NET Upgrade Assistant](./images/dotnet-upgrade-assistant.png)

The Upgrade Assistant features an analysis engine that scans your projects and dependencies, then generates detailed reports with upgrade recommendations. It helps you upgrade entire projects or specific components, like configuration files, and automatically detects and fixes potential incompatibilities.

The following use cases are supported by the extension:

### Supported project types

| Language Support | Project Types |
|------------------|---------------|
| **C# & Visual Basic** | ASP.NET, Azure Functions, WPF, Windows Forms, Class Libraries, Console Apps, Xamarin Forms, .NET MAUI, .NET Native UWP |

### Available upgrade paths

| From | To | Notes |
|------|----|----|
| .NET Framework | .NET | Full migration support |
| .NET Core | .NET | Version consolidation |
| Azure Functions v1-v3 | v4 isolated (net6.0+) | Modernized runtime |
| UWP | WinUI 3 | Windows app platform update |
| Previous .NET versions | Latest .NET | Always current |
| Xamarin Forms | .NET MAUI | Cross-platform evolution |

> **Note**: XAML transformations support namespace upgrades only. For comprehensive XAML changes, use Visual Studio 2022 v17.6+.


## 📋 What you'll do

This section covers:

⬆️ Understand the modernization process  
🛠️ Use .NET Upgrade Assistant  
🎯 Complete modernization from .NET Framework to .NET Core/.NET  
🔍 Analyze the modernization results  

## ⬆️ Understanding the modernization process

When modernizing a codebase with the .NET Upgrade Assistant, several key activities are involved:

- **Project analysis and scanning**: The tool includes an analysis engine that scans your projects and their dependencies to identify upgrade opportunities and potential incompatibilities
- **Automated project format conversion**: Upgrades projects from the .NET Framework project format to the latest .NET SDK project format automatically
- **NuGet package cleanup and optimization**: Analyzes package references and removes unnecessary dependencies while ensuring proper package versions for the target framework
- **Target framework migration**: Changes the target framework moniker (TFM) from .NET Framework to the appropriate modern .NET version (such as net6.0 or net9.0)
- **Code transformation and namespace updates**: Performs source-specific code changes, updates namespaces, and migrates APIs to their modern equivalents
- **Configuration file migration**: Updates configuration files from older formats to newer types compatible with modern .NET
- **Analyzer integration**: Adds analyzers to the project that assist with completing the migration process and identifying remaining issues
- **Task list generation**: Creates TODO items in Visual Studio's Task List for manual migration tasks that require developer attention
- **Side-by-side or in-place upgrade options**: Offers flexibility to either create a copy of your project for migration or upgrade the existing project in place
- **Template and boilerplate file generation**: Adds or updates necessary template, config, and code files required for the target platform
- **Checking the work**: You may need to check the work or manually do adjustments to make sure everything works as you'd expect.

## 🛠️ Using .NET Upgrade Assistant

> 🪧**IMPORTANT**
>
> **Windows Path Length Limitation**: If you encounter NuGet package restore errors, this is likely due to Windows path length restrictions. To resolve this, copy the starter solution to a shorter path such as `C:\Dev` to ensure optimal performance during the upgrade process.

> 🪧**IMPORTANT**
>
> If you encounter an error similar to the followng while trying to debug:
> ![Screenshot of the nuget error stating cannot find csc.exe](./images/nuget-error.png)
> 
> Run the following command in the **NuGet Package Manager Console** (Open via the menu: **Tools > NuGet Package Manager > Package Manager Console**)
> 
> `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`

Let's start the migration process by running the Upgrade Assistant on our eShopLiteFx (.NET Framework) application.

1. Open our sample project in Visual Studio 2022.

1. Right-click on the solution in Solution Explorer and select **Upgrade**.

    ![.NET Upgrade Assistant in Visual Studio](./images/dotnet-upgrade-assistant-vs.png)

1. The Upgrade Assistant will give some options to how to upgrade the project, you can upgrade the entire project. We'll select the **side-by-side** upgrade.

    ![.NET Upgrade Assistant options](./images/dotnet-upgrade-assistant-options.png)

1. Then select **New Project** for the upgrade target. 

    ![.NET Upgrade Assistant create new project](./images/dotnet-upgrade-assistant-create-new-project.png)

1. Give it a name, for example **eShopLite.StoreCore**. You can leave the **Project template** as **ASP.NET Core MVC**.

    ![.NET Upgrade Assistant create new project name](./images/dotnet-upgrade-assistant-create-new-project-name.png)

1. Select **.NET 9.0** for the target framework if you have that installed. If not select **.NET 8**.

    ![.NET Upgrade Assistant target](./images/dotnet-upgrade-assistant-target.png)

1. The Upgrade Assistant will start analyzing the project and will give you a report with the summary of the changes it needs to make to complete the migration. Click **Finish** to run the migration.

    ![.NET Upgrade Assistant report](./images/dotnet-upgrade-assistant-report.png)

    ![.NET Upgrade Assistant applying changes](./images/dotnet-upgrade-assistant-applying-changes.png)

1. Once the migration is complete click the **Done** button. Now any communications coming to the new .NET application will be proxied from the new .NET 9 application through to the existing .NET Framework application. However, you will need to upgrade some other parts of the code, like the controllers, views, and some individual classses. You can click on the individual links **Upgrade Controller**, **Upgrade Class** and **Upgrade View** to perform those upgrades.

    ![.NET Upgrade Assistant migration complete](./images/dotnet-upgrade-assistant-migration-complete.png)

    ![.NET Upgrade Assistant endpoints](./images/dotnet-upgrade-assistant-endpoints.png)

1. If you click on any of those links, you'll see a list of controllers, views, and other components that could be upgraded. Click **Upgrade Controller** and then select **eShopLite.StoreFx.Controllers.HomeController**. (Keep everything checked below it.)

    ![.NET Upgrade Assistant controllers](./images/dotnet-upgrade-assistant-controllers.png)

    ![.NET Upgrade Assistant upgrade UI](./images/dotnet-upgrade-assistant-upgrade-ui.png)

1. Click **Upgrade Selection** and the Assistant will go through and upgrade the controller. A report will appear with success, skipped, and failures.

1. Now select **Upgrade > Class** from the dropdown on the top menu bar of the assistant.

    ![Screenshot showing the menubar for upgrading classes](./images/upgrade-class-dropdown.png)

1. One by one, go through and select all of the data classes to upgrade them.

    ![Screenshot of the data classes that need to be upgraded](./images/dotnet-upgrade-assistant-classes.png)

1. After this, please copy and paste the scripts and the images folder from the old project to the new project, as the Upgrade Assistant does not copy these files automatically.

With these steps, you have partially modernized the eShopLite .NET Framework application to a new .NET Core project. However, there are still some manual steps to complete the migration, let's continue with them.

## 🎯 Complete modernization from .NET Framework to .NET Core/.NET

After running the Upgrade Assistant, you will have a new project in your solution that is based on .NET Core/.NET. However, there are still some manual steps to complete the migration:


#### 📁 How to Apply the Updated Files
1. Make sure your solution builds after the Upgrade Assistant run (baseline migrated project present).
2. Create a backup (optional) of your current upgraded project folder (e.g. `eShopLite.StoreCore`).
3. From `./UpdatedSample`, copy over the changed files (see list below) into your upgraded project.
4. Restore packages and build.
5. Run and verify functionality matches expectations.

#### 🗂️ Key Files You Will Replace (or Add) and What Changed
| File | Change Summary |
|------|----------------|
| `Program.cs` | Converted to minimal hosting model, added service registrations (DbContext, Store/Data services), ensured database seeding logic. |
| `eShopLite.StoreCore.csproj` | Updated TargetFramework, cleaned legacy package refs, added modern EF Core + tooling, removed obsolete references. |
| `Data/StoreDbContext.cs` | Introduced EF Core DbContext with seeding (Products + Stores) replacing prior in-memory / legacy data access patterns. |
| `Services/StoreService.cs` | Namespace + dependency injection adjustments; updated to async patterns where applicable. |
| `Controllers/HomeController.cs` | Updated usings, namespace, action return types to align with ASP.NET Core conventions. |
| `Views/Shared/_Layout.cshtml` | Updated script + style references (bootstrap bundle, latest jquery), removed obsolete WebForms-era references. |
| `wwwroot/` assets | Moved images, scripts, css into proper static web root instead of legacy `Content/` + `Scripts/` layout. |
| `appsettings.json` | Added structured configuration placeholder for future persistence (if moving from in-memory). |
| `Models/*` | JSON serialization attributes. |

> If a file does not exist in your current upgraded project, add it. If it exists, overwrite it with the version from the StartSample unless you have intentional differences.

#### 🧪 Post-Copy Validation Checklist
- `dotnet restore` succeeds
- `dotnet build` succeeds
- App runs and product list renders
- Images load from `wwwroot`
- EF Core seeding creates expected sample data

#### 🛠 Optional: Generate an EF Core Migration (If Using a Real Provider)
If you later switch from InMemory to SQLite or SQL Server:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Now, you should be able to run the application and see the migrated eShopLite.StoreCore application running on .NET Core/.NET. If you wish, you could delete the old eShopLiteFx project, as it is no longer needed.

![eShopLite.StoreCore running](./images/eshoplite-storecore-running.png)

>**Note**: For the complete migration for the sample, look at the [eShopLite.StoreCore](../../3-modernize-with-github-copilot/StartSample) folder, which contains the fully migrated project.

---

## ✅ Wrap-up

By the end of this section, you should have:

🔹 Successfully migrated your application to modern .NET  
🔹 Understanding of common migration patterns  
🔹 A working modern .NET application  

[← Previous: Upgrade .NET Applications](../README.md) | [Next: Modernize with GitHub Copilot →](../../3-modernize-with-github-copilot/README.md)
