# Upgrade Options — eShopLiteFx

Assessment: 1 .NET Framework web project (net48, non-SDK-style), high complexity, 15 binding redirect issues, and package compatibility findings.

## Strategy

### Upgrade Strategy
Single-project .NET Framework upgrade has no dependency graph tiers, so an atomic upgrade is the default.

| Value | Description |
|-------|-------------|
| **All-at-Once** (selected) | Upgrade the project in one atomic pass. |
| Top-Down | Upgrade app entry points first and consolidate libraries later. |

## Project Structure

### Project Approach
The project is an ASP.NET Framework web app (System.Web), so migration approach selection is required.

| Value | Description |
|-------|-------------|
| **Side-by-side** (selected) | Create a new ASP.NET Core project and migrate incrementally while the old app stays live. |
| In-place rewrite | Replace the Framework web project in one pass. |

## Compatibility

### Unsupported Packages
Assessment surfaced package compatibility issues for the target TFM and a resolution policy is needed.

| Value | Description |
|-------|-------------|
| **Resolve Inline** (selected) | Research and resolve incompatible packages during the same upgrade task. |
| Defer Resolution | Use temporary stubs and create follow-up replacement tasks. |
| Compatibility Mode | Keep framework reference assemblies and suppress compatibility warnings as a last resort. |

### System.Web Adapters
System.Web usage is present and side-by-side migration is selected.

| Value | Description |
|-------|-------------|
| **Use System.Web Adapters** (selected) | Add compatibility shims to support incremental migration from System.Web APIs. |
| Direct Migration to ASP.NET Core APIs | Replace all System.Web usage immediately with native ASP.NET Core APIs. |

## Modernization

### Assembly Binding Redirects
Assessment found 15 binding redirect issues, so these should be reviewed before removal.

| Value | Description |
|-------|-------------|
| Remove Binding Redirects | Remove redirects directly because .NET modern runtime does not use them. |
| **Document and Review Before Removing** (selected) | Inventory and review redirects first, then remove safely. |

### Nullable Reference Types
Target framework supports nullable, but this migration is already high-risk and should stay focused.

| Value | Description |
|-------|-------------|
| **Leave Disabled** (selected) | Keep nullable disabled during migration and enable later in a dedicated effort. |
| Enable Nullable Reference Types | Enable nullable now and address warnings as part of this upgrade. |
