# 🔄 Migrate with .NET Upgrade Assistant

Let's update our eShopLite application to modern .NET using the .NET Upgrade Assistant. 

The .NET Upgrade Assistant is a powerful tool available as both a Visual Studio extension and command-line interface that helps migrate .NET Framework, .NET Core, or older .NET projects to the latest .NET version. 

![.NET Upgrade Assistant](./images/dotnet-upgrade-assistant.png)

Featuring an analysis engine that scans your projects and dependencies, generating detailed reports with upgrade recommendations that allow you to modernize entire projects or specific components like configuration files, while automatically detecting and fixing potential incompatibilities.

The following uses are supported by the extension:

### Supported Project Types

| Language Support | Project Types |
|------------------|---------------|
| **C# & Visual Basic** | ASP.NET, Azure Functions, WPF, Windows Forms, Class Libraries, Console Apps, Xamarin Forms, .NET MAUI, .NET Native UWP |

### Available Upgrade Paths

| From | To | Notes |
|------|----|----|
| .NET Framework | .NET | Full migration support |
| .NET Core | .NET | Version consolidation |
| Azure Functions v1-v3 | v4 isolated (net6.0+) | Modernized runtime |
| UWP | WinUI 3 | Windows app platform update |
| Previous .NET versions | Latest .NET | Always current |
| Xamarin Forms | .NET MAUI | Cross-platform evolution |

> **Note**: XAML transformations support namespace upgrades only. For comprehensive XAML changes, use Visual Studio 2022 v17.6+.


## 📋 What You'll Do

This section covers:

⬆️ Understanding the migration process  
🛠️ Using .NET Upgrade Assistant  
🎯 Converting from .NET Framework to .NET Core/.NET  
🔍 Analyzing migration results  

## 📚 Instructions

*Detailed migration instructions will be added here.*

## ✅ Verification

By the end of this section, you should have:

🔹 Successfully migrated your application to modern .NET  
🔹 Understanding of common migration patterns  
🔹 A working modern .NET application  

---
[← Previous: Setup Environment](../1-setup-your-environment/README.md) | [Next: Modernize with GitHub Copilot →](../3-modernize-with-github-copilot/README.md)