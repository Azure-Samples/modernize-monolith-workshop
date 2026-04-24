# 🤖 Modernize with GitHub Copilot

By using the upgrade assistants from Chapter 2, our application is now running on .NET 10. But it may not be using best practices or design patterns.

In this chapter, we will focus on modernizing our application using GitHub Copilot, which will assist us in refactoring the codebase, improving architecture, and enhancing overall performance.

## 📋 What you'll do

This section explores:

🚀 AI-powered code modernization using **GitHub Copilot Modernization**  
💡 GitHub Copilot best practices
🔧 Automated refactoring suggestions  
📈 Improving code quality with AI assistance

## 🔍 Prerequisites

Before starting, ensure you have:

- GitHub Copilot installed and activated in Visual Studio
- **GitHub Copilot Modernization** extension installed in Visual Studio

### Choose Your Starting Point

> ⚠️ **Important: Starting Sample Selection**
> 
> **If you completed Module 2B (GitHub Copilot Modernization upgrade):** You can continue with your upgraded code. Your Module 2B output should be running on .NET 10 with SQLite and Blazor components—perfect for modernization tasks in this module.
>
> **If you completed Module 2A (Traditional .NET Upgrade Assistant) or want a consistent baseline:** Use the fresh sample in **`3-modernize-with-github-copilot/StartSample`**. This ensures you have a stable, known starting point regardless of your Module 2 path. The StartSample is a post-upgrade .NET 10 codebase ready for architectural modernization.
>
> **Either path works.** Choose based on whether you want to keep your Module 2B progress or start fresh with a standardized baseline.

### Check GitHub Copilot agent mode

First, verify that the **upgrade_dotnet** tool is enabled in GitHub Copilot's Agent Mode:

1. Open Visual Studio and navigate to your solution
1. Open the GitHub Copilot chat window and switch to **Agent** mode
1. Click the icon that looks like a wrench and a screwdriver.
1. Ensure the **upgrade_dotnet** tool enabled

![GitHub Copilot Agent Mode](./images/copilot-agent-mode.png)

## How GitHub Copilot Modernization Works

GitHub Copilot's modernization tool follows a structured three-stage workflow: **Assessment → Planning → Execution**. First, it analyzes your codebase to identify upgrade opportunities and technical debt. Next, it creates a prioritized, step-by-step plan with proper dependency ordering. Finally, it implements changes incrementally, keeping your build green between steps.

The tool includes built-in scenarios for common modernization tasks:
- **Namespace cleanup** — Corrects inconsistent or outdated namespace declarations
- **Dependency injection migration** — Converts legacy service patterns to modern DI
- **Async/await patterns** — Refactors synchronous code to async best practices
- **Database modernization** — Migrates between database providers (e.g., SQL Express → SQLite)
- **Blazor conversion** — Transforms ASP.NET MVC/Web Forms to Blazor components
- **JSON serialization** — Migrates Newtonsoft.Json to System.Text.Json
- **EF6 → EF Core** — Upgrades Entity Framework to the modern ORM

You can run the tool in **Automatic mode** (hands-off execution) or **Guided mode** (step-by-step with approval gates). For project-specific patterns, you can create custom upgrade skills in `.github/skills/`.

## Starting the modernization process

Let's start the modernization by invoking the GitHub Copilot **upgrade_dotnet** tool. The tool's **Assessment** stage will analyze your solution for upgrade opportunities, then the **Planning** stage produces a prioritized plan (framework version gaps, architectural layering, dependency injection, async/await usage, nullability, analyzers) aligned with current .NET coding standards. Finally, the **Execution** stage applies the changes incrementally, keeping builds and tests green between steps.

1. **Right-click on your solution** in Solution Explorer
1. Select **"Upgrade with Copilot"** from the context menu or use the default **Copilot Chat**

![Upgrade with Copilot Menu](./images/upgrade-with-copilot-menu.png)

3. When prompted to select a version or provide context, do not select a version. Because we did already the migration in the previous section, here, we are aiming to modernize the application architecture and codebase.

4. Paste the following comprehensive modernization request:

```plaintext
I am working on a project that has recently been upgraded from .NET Framework to .NET 10. I need help modernizing the architecture and refactoring the codebase to align with .NET 10 best practices. Please assist with the following tasks:

Namespace and Naming Consistency
Scan the entire solution for inconsistent or outdated namespace declarations. Identify and correct naming inconsistencies in classes, methods, and files. Apply consistent naming conventions throughout the codebase. The steps will be: Namespace and Naming Consistency, Fix Namespace Consistency - Models

Architecture Modernization
Refactor legacy architectural patterns to modern .NET 10 standards. Introduce dependency injection using Microsoft.Extensions.DependencyInjection. Replace obsolete or deprecated APIs with .NET 10-compatible alternatives. The steps will be: Modernize Data Layer with SQLite, Modernize Service Layer, Fix Controller Namespace and Modernize, Modernize Program.cs with .NET 10 Best Practices, Update Views to Handle Async Operations and New Namespaces, Create Error View

Database Migration
Replace the existing SQLExpress database with SQLite. Update connection strings and DbContext configuration to support SQLite. Migrate schema and seed data from SQLExpress to SQLite. Ensure all SQL queries are compatible with SQLite syntax. The steps will be: Update Configuration with SQLite Connection String, Create the database, Build and Test the Application
```

![Copilot Modernization Request](./images/copilot-modernization-request.png)

> 💡 **TIP**
>
> The modernization tool has built-in scenarios for many of these tasks (namespace cleanup, DI migration, database modernization, Blazor conversion). The prompt above provides guidance and context, but the tool may also suggest additional modernization opportunities based on its assessment of your codebase.

> 🪧**IMPORTANT**
>
> If the request stops in the middle of a task, you can always ask Copilot to continue by saying "continue" or "please continue."

## 📝 Modernization steps

GitHub Copilot will guide you through several modernization phases:

### 1️⃣ Namespace and naming consistency

Because of the older namespace structure from .NET Framework, we need to ensure that all namespaces and naming conventions are consistent in our application. For example, our models may have namespaces like `eShopLite.StoreFx.Models` instead of `eShopLite.StoreCore.Models`.

To achieve this, we added steps to Copilot analyze your codebase and suggest namespace corrections, before accepting any changes, please follow these steps:

- Review suggested namespace changes, you can accept or modify them as needed.
- Accept modifications to align with .NET 10 conventions and packages, such as going from `Newtonsoft.Json` to `System.Text.Json`.
- Ensure all models follow consistent naming patterns

![Fix Namespace Models](./images/fix-namespace-models.png)

### 2️⃣ Architecture modernization

#### Modernize data layer with SQLite

We are transitioning from SQL Express using InMemory to SQLite, thus using a real database for persistence. Copilot will help transition from SQL Express to SQLite:

- Update Entity Framework Core packages
- Configure SQLite provider
- Adjust connection strings

![SQLite Migration](./images/sqlite-migration.png)

![SQLite Program.cs](./images/sqlite-program.png)

![SQLite Configuration](./images/sqlite-configuration.png)

#### Dependency injection, async/await, modern routing

Transform services to use modern dependency injection patterns and update controllers with async/await patterns and modern routing:

![Service Layer Modernization](./images/service-layer-modernization.png)

#### 3️⃣ Database migration

Copilot should automatically handle the database migration to SQLite, but if it doesn't, you can follow these steps:

1. Open a terminal in your project directory
2. Run the following commands:

```bash
cd eShopLite.StoreCore
dotnet ef migrations add InitialCreate
```

3. Now, build and run the application to ensure the database is created and seeded correctly.

## 🔧 Troubleshooting common issues

### YARP errors

If you encounter YARP (Yet Another Reverse Proxy) errors:
- Ask Copilot to remove YARP references from your project
- These are typically not needed for this application

### Missing images

If product images don't appear after modernization:
- Ask Copilot to reorganize static files within the `wwwroot` folder
- Ensure image paths are correctly referenced

![Image Organization](./images/image-organization.png)

## 🎯 Build and test

After completing all modernization steps:

1. Build the solution to ensure no compilation errors
1. Run the application and verify all functionality
1. Check that:
   - Database operations work with SQLite
   - All pages load correctly
   - Images and static content display properly
   - Async operations complete successfully

![Modernized Application Running](./images/modernized-app-running.png)

## 4️⃣ Convert to Blazor pages

Great, now we are ready continuing our modernization journey by converting the existing ASP.NET MVC pages to Blazor components. 

> 💡 **NOTE**  
> Blazor conversion is one of the tool's built-in scenarios. While the manual prompt below gives you hands-on control, you can also explore the tool's automated Blazor conversion approach by right-clicking the project and selecting "Upgrade with Copilot" → selecting "Blazor conversion."

Use the following prompt to guide Copilot:

```plaintext
Convert the existing ASP.NET MVC pages to Blazor components. This includes:

Convert all existing pages to use Blazor (preferably Blazor Server or Blazor WebAssembly, depending on suitability).
Remove all non-Blazor pages and ensure routing is correctly configured.
Ensure all media (images, videos, etc.) are correctly referenced and rendered in the new Blazor components.
Fix issues where the page renders blank or fails to load due to routing or layout problems.
```

![Blazor Migration](./images/blazor-migration.png)

Copilot will convert the MVC pages to Blazor components, ensuring that all functionality is preserved and adding some new features.

> Note: If you encounter any issues with the Blazor migration, you can ask Copilot to help troubleshoot specific problems, such as missing components or routing errors.

This is our final page:

![Blazor Final Page](./images/blazor-final-page.png)

![Blazor Final Page Store](./images/blazor-final-page-store.png)

![Blazor Final Page locations](./images/blazor-final-page-locations.png)


## ✅ Verification

By the end of this section, you should have:

🔹 Leveraged GitHub Copilot for code improvements  
🔹 Applied modern coding patterns  
🔹 Enhanced application performance and maintainability  

---
[← Previous: Upgrade .NET Applications](../2-upgrade-dotnet/README.md) | [Next: Refactor into Microservices →](../4-refactor-into-microservices/README.md)