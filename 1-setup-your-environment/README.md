# Setting up your environment

This workshop is designed to help you modernize .NET applications. 

Everything from modernizing code from .NET Framework to a modern .NET, getting all that code ready for the cloud with microservices and .NET Aspire, and even adding in a sprinkling of AI.

But before we get to all that we need to install some tools.

![.NET Upgrade Tool](./images/Microsoft.VisualStudio.Services.Icons.png)

## 📝 Tooling and frameworks

For the rest of this workshop you're going to need some tooling and frameworks that you may or may not already have.

The workshop is broken up into 2 parts:

- Part 1: Modernizing .NET Framework code into modern .NET
- Part 2: Preparing for the cloud

We'll provide starter solutions for each part - so if you want to jump right into Part 2 on preparing for the cloud, you can skip installing all the stuff needed for Part 1.

## Requirements all-up

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) : The latest version of the .NET SDK that you'll need for development.
- [Visual Studio](https://visualstudio.microsoft.com/vs/) with the web workload installed.

## Requirements for part 1 - modernizing code

- [.NET 4.8 Framework](https://dotnet.microsoft.com/download/dotnet-framework/net48): A version of the .NET Framework that the existing application for this workshop is currently using.
- [.NET Upgrade Assistant](https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-overview): A tool to help you upgrade your .NET applications.
- [.NET Upgrade Assistant Copilot](https://learn.microsoft.com/en-us/dotnet/core/porting/github-copilot-app-modernization-install#visual-studio-extension): This copilot extension will assist you in the migration process by providing suggestions and automating some tasks.
- [SQL Express](https://www.microsoft.com/en-us/download/details.aspx?id=104781&lc=1033&msockid=3bf02f53610f677810c73afb608a66da): A lightweight version of SQL Server for local development and testing.
- [GitHub Copilot Pro](https://github.com/features/copilot): Optional, as you can read through the [update with GitHub Copilot](../2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md) section.

## Requirements part 2 - modernizing for the cloud

- [Docker Desktop](https://docs.docker.com/desktop/)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) with [Azure Container Apps extension](https://learn.microsoft.com/cli/azure/azure-cli-extensions-list)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Azure subscription](https://signup.azure.com/signup) - this is optional.
 
## 📚 Installing the upgrade assistants

Let's walk through installing the upgrade assistants. The instructions are the same for whether you want to install the **.NET Upgrade Assistant** or the **GitHub Copilot app modernization** - you only have to change what you search for.

1. Open **Visual Studio**
1. Go to the menu bar and select **Extensions > Manage Extensions**.
1. Select the **Browse** tab and search for `.NET Upgrade Assistant` or `GitHub Copilot App Modernization`
1. Click the **Install** button to install the extension.

   ![Visual Studio Installation](./images/visual-studio-manage-extensions.png)
   

1. Close Visual Studio to install the extension
   - Once the extension finishes downloading, close Visual Studio to automatically start the installation.

1. A window will appear prompting to install the the extension, click **Install**.

   ![Modify Installation](./images/install-prompt.png)
   

### Validation

1. Open Visual Studio and check if the extension is enabled by going to **Extensions > Manage Extensions > Installed** and you should see the extension's name.
1. Or right-click on any .NET or .NET Framework project in **Solution Explorer** and check for an **Upgrade** menu item.

---
[← Back to the overall workshop](../README.md) | [Next: Upgrade .NET applications →](../2-upgrade-dotnet/README.md)