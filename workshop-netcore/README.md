# Lab 1 - Adding .NET Aspire to an existing .NET Core application and enabling service discovery

In this lab, you will add the .NET Aspire library to an existing .NET Core application and enable service discovery. We'll be using a scaled down version of the [eShop .NET Aspire reference app](https://github.com/dotnet/eshop) called eShopLite.

## Part 1 - Running the eShopLite application

First let's run the eShopLite application to see what it looks like before adding Aspire.

1. Get the repository root.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Navigate to Lab 1.

    ```bash
    cd "$REPOSITORY_ROOT/Labs/Lab 1 - Add Aspire and Service Discovery"
    ```

1. Build the solution.

    ```bash
    dotnet restore && dotnet build
    ```

1. Run the Product API app.

    ```bash
    dotnet watch run --project ./Products
    ```

1. Run the store app in another terminal.

    ```bash
    dotnet watch run --project ./Store
    ```

1. Two web browsers will open, one for the **Products** project and one for the **Store** project. The products browser will show a JSON representation of all the products. The store browser will show a web page, click on the **Products** link to see the products displayed.

    ![eShopLite](images/eshoplite-products.png)

1. Stop both apps by typing `CTRL`+`C` in the terminal.

The **Products** project is a backend service that provides a list of products. The **Store** project is a frontend web application that displays the products from the **Products** project. Both of these can be thought of as microservices and it's easy to imagine adding additional microservices to the application, for example a **Cart** microservice.

## What is .NET Aspire?

A cloud-native application is a web application built from small microservices, which make use of common services such as messaging queues to communicate or caches to optimize performance. Cloud-native applications are proven and widely implemented but they can be difficult to architect and build. .NET 8 includes the new .NET Aspire stack, which makes it easier to build cloud-native applications by providing service discovery, common components in NuGet packages, and simple tools for both coding and monitoring apps.

It helps solve some of the common challenges in building cloud-native applications by providing tooling for:

* Orchestration - clearly specify the projects, containers, and services that make up your application. .NET Aspire can then use service discovery to find and connect these services.
* Components - many projects need common components like data storage, caching, and messaging. .NET Aspire provides a standard interface that your application can use to access these components regardless of the underlying implementation.
* Dashboard - the .NET Aspire dashboard lets you monitor all the services that compose your application in one place. Including console logs, structured logs, traces, and metrics.

Let's add in .NET Aspire to the eShopLite application with an eye towards enabling service discovery.

## Adding .NET Aspire to the eShopLite application

1. Make sure you're still in Lab 1.

    ```bash
    cd "$REPOSITORY_ROOT/Labs/Lab 1 - Add Aspire and Service Discovery"
    ```

1. Add two .NET Aspire projects - `eShopLite.AppHost` and `eShopLit.ServiceDefaults`.

    ```bash
    dotnet new aspire-apphost -n eShopLite.AppHost
    dotnet new aspire-servicedefaults -n eShopLite.ServiceDefaults
    ```

1. Add `eShopLit.ServiceDefaults` to existing `Products` and `Store` app as a reference.

    ```bash
    dotnet add ./Products reference ./eShopLite.ServiceDefaults
    dotnet add ./Store reference ./eShopLite.ServiceDefaults
    ```

1. Add both `Products` and `Store` app to `eShopLite.AppHost` as references.

    ```bash
    dotnet add ./eShopLite.AppHost reference ./Products
    dotnet add ./eShopLite.AppHost reference ./Store
    ```

1. Add both `eShopLite.AppHost` and `eShopLit.ServiceDefaults` to solution.

    ```bash
    dotnet sln add ./eShopLite.AppHost
    dotnet sln add ./eShopLite.ServiceDefaults
    ```

The **AppHost** and **ServiceDefaults** projects are the core of every .NET Aspire application. The **AppHost** project is the entry point and is responsible for acting as the orchestrator. The **ServiceDefaults** project contains the default configuration for the application. These configurations are reused across all the projects in your solution.

Both projects are now part of the Aspire orchestration. Here's a recap of all the changes that happened, some of which were done automatically by the tooling, when adding .NET Aspire to the solution:

* An AppHost project is added. The project contains the orchestration code. It becomes the entry point for your app and is responsible for starting and stopping your app. It also manages the service discovery and connection string management.
* A ServiceDefaults project is added. The project configures OpenTelemetry, adds default health check endpoints, and enables service discovery through HttpClient.
* The solution's default startup project has now become to AppHost.
* Dependencies on the projects enrolled in orchestration are added to the AppHost project.
* The .NET Aspire Dashboard is added to your solution, which enables shortcuts to access all the project endpoints in your solution.
* The dashboard adds logs, traces, and metrics for the projects in your solution.

Now we need to make sure that the **Store** can discover the **Products** backend URL through .NET Aspire's service discovery.

## Enabling service discovery

Service discovery is a way for developers to use logical names instead of physical addresses (IP address and port) to refer to external services. So instead of having to know the IP address and port of the **Products** backend, the **Store** can refer to it by its logical name, for example `products`.

1. Make sure you're still in Lab 1.

    ```bash
    cd "$REPOSITORY_ROOT/Labs/Lab 1 - Add Aspire and Service Discovery"
    ```

1. Open the `AppHost.cs` file from the **eShopLite.AppHost** project.
1. Add the following code lines between `var builder = DistributedApplication.CreateBuilder(args);` and `builder.Build().Run();`

    ```csharp
    var builder = DistributedApplication.CreateBuilder(args);

    // 👇👇👇 Add 👇👇👇
    var products = builder.AddProject<Projects.Products>("products");

    builder.AddProject<Projects.Store>("store")
           .WithReference(products)
           .WaitFor(products);
    // 👆👆👆 Add 👆👆👆

    builder.Build().Run();
    ```

   > This is naming the **Products** project as `products` so that it can be referred to by that name from other projects in the solution.
   >
   > Now when **Store** needs to invoke **Products**, it can refer to it by the logical name `products`. In other words, the URL of the **Products** backend is now `http://products`.

1. Open the `Program.cs` file from the **Products** project.
1. Add the following code lines just above `var app = builder.Build();`.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    builder.AddServiceDefaults();
    // 👆👆👆 Add 👆👆👆

    var app = builder.Build();
    ```

1. Add the following code lines just above `app.Run();`.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    app.MapDefaultEndpoints();
    // 👆👆👆 Add 👆👆👆

    app.Run();
    ```

1. Open the `Program.cs` file from the **Store** project.
1. Add the following code lines just above `var app = builder.Build();`.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    builder.AddServiceDefaults();
    // 👆👆👆 Add 👆👆👆

    var app = builder.Build();
    ```

1. Add the following code lines just above `app.Run();`.

    ```csharp
    // 👇👇👇 Add 👇👇👇
    app.MapDefaultEndpoints();
    // 👆👆👆 Add 👆👆👆

    app.Run();
    ```

1. Open the `appsettings.json` file from the **Store** project and remove those lines.

    ```jsonc
    {
      "DetailedErrors": true,
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",

      // 👇👇👇 Remove 👇👇👇
      "ProductEndpoint": "http://localhost:5228",
      "ProductEndpointHttps": "https://localhost:7130"
      // 👆👆👆 Remove 👆👆👆
    }
    ```

1. Replace the code lines.

    ```csharp
    // Before
    builder.Services.AddHttpClient<ProductService>(c =>
    {
        var url = builder.Configuration["ProductEndpoint"] ?? throw new InvalidOperationException("ProductEndpoint is not set");

        c.BaseAddress = new(url);
    });

    // After
    builder.Services.AddHttpClient<ProductService>(c =>
    {
        c.BaseAddress = new("https+http://products");
    });
    ```

   > The **Products** backend is now referred as `products` because the **AppHost** project has already orchestrated it.

.NET Aspire integration has now been completed. Let's run the dashboard app.

## Exploring .NET Aspire dashboard

1. Make sure Docker Desktop is up and running
1. Make sure you're still in Lab 1.

    ```bash
    cd "$REPOSITORY_ROOT/Labs/Lab 1 - Add Aspire and Service Discovery"
    ```

1. Run the command to open the application.

    ```bash
    dotnet watch run --project ./eShopLite.AppHost
    ```

1. The Aspire dashboard appears.

    ![Aspire Dashboard](images/aspire-dashboard.png)

   > **NOTE**: You may be asked to enter an authentication token to access to the dashboard.
   >
   > ![.NET Aspire dashboard login](./images/login.png)
   >
   > The token can be found in the terminal console. Copy and paste it to the field and click "Log in".
   >
   > ![.NET Aspire dashboard access token](./images/console-token.png)

1. Click on the endpoint for the **store** project in the dashboard.
1. A new tab appears with the same eShopLite application, but now the **Products** backend is being called through service discovery.
1. Stop all apps by typing `CTRL`+`C` in the terminal

---

[<- Labs](../README.md) | [Lab 2 - Add Redis caching to the app ->](/Labs/Lab%202%20-%20Caching%20and%20Dashboard/README.md)