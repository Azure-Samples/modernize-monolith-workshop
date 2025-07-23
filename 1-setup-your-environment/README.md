# Welcome to the .NET Upgrade Workshop!

This workshop is designed to help you migrate your .NET applications to the latest versions of .NET. From .NET framework to .NET 9, this guide will provide you with the tools and knowledge you need to successfully complete your migration journey.

**ToDo: Add workshop art and branding.**

## 🔧 Setup Your Environment

 In this section, you'll prepare your development environment with all the necessary tools and prerequisites.

### 📝 Prerequisites

Before diving into the migration process, ensure you have the following prerequisites:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) : The latest version of the .NET SDK that you'll need for development.
- [.NET 4.8 Framework](https://dotnet.microsoft.com/download/dotnet-framework/net48) : A version of the .NET Framework that the existing application for this workshop is currently using.
- [.NET Upgrade Assistant Copilot](https://learn.microsoft.com/en-us/dotnet/core/porting/github-copilot-app-modernization-install#visual-studio-extension) : This extension will assist you in the migration process by providing suggestions and automating some tasks.
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Docker Desktop](https://docs.docker.com/desktop/)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) with [Azure Container Apps extension](https://learn.microsoft.com/cli/azure/azure-cli-extensions-list)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)


 Before you start, let's understand what is the application we're going to upgrade.

## 🏗️ App Overview

The application we will be working with is a sample .NET Framework app, which uses a monolith architecture for an e-commerce platform, called eShopLite. 

Which has (Placeholder for app description, features, etc.).

## 📋 What You'll Do

This section will guide you through setting up:

🔨 Development Environment
🔹 Install and configure the necessary tools

## 📚 Instructions

First, ensure you have the prerequisites installed. If not, [follow the links](#prerequisites) provided above to download and install them.

### Installing the .NET Upgrade Assistant Copilot
To install the .NET Upgrade Assistant Copilot extension for Visual Studio, follow these steps:


1. **Open Extension Manager**: 
   - Go to the menu bar and select `Extensions > Manage Extensions`.
    - Alternatively, you can use the shortcut `Ctrl+Q` and type `Extension Manager`.

2. **Search for .NET Upgrade Assistant**:
   - In the Extension Manager, select the `Browse` tab.
   - Enter `GitHub Copilot app modernization` into the search box.

3. **Install the Extension**:
   - Select `GitHub Copilot app modernization` from the search results.
   - Click the `Install` button.

4. **Close Visual Studio**:
   - Once the extension finishes downloading, close Visual Studio to automatically start the installation.

5. **Modify Installation**:
   - A prompt to install the GitHub Upgrade Assistant extension will appear.
   - Select `Modify` and follow the instructions to install the extension.

### Validation
* Open Visual Studio and check if the extension is enabled by going to `Extensions > Manage Extensions > Installed`.
* Right-click on any .NET or .NET Framework project in Solution Explorer and check for an Upgrade menu item.

## 🚀 Next Step

Placeholder for next step description, e.g., "Now that your environment is set up, you can proceed to the next section where you'll learn how to use the .NET Upgrade Assistant to migrate your application."


## ✅ Verification

By the end of this section, you should have:

🔹 A working development environment  
🔹 All required tools installed and configured  
🔹 Access to necessary services verified  

---
[← Back to Main Workshop](../README.md) | [Next: Migrate with .NET Upgrade Assistant →](../2-migrate-with-dotnet-upgrade-assistant/README.md)