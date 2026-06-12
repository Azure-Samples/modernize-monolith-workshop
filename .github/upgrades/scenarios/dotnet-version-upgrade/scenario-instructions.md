# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0
- **Scope**: src/eShopLite.StoreFx/eShopLite.StoreFx.csproj

## Source Control
- **Source Branch**: main
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## User Preferences
### Execution Style
- Save a copy of the generated assessment report in the solution folder (`StartSample`) when requested.
- Save a copy of generated planning artifacts in the solution folder (`StartSample`) when requested.

## Upgrade Options
**Source**: .github/upgrades/scenarios/dotnet-version-upgrade/upgrade-options.md

### Strategy
- Upgrade Strategy: All-at-Once

### Project Structure
- Project Approach: Side-by-side

### Compatibility
- Unsupported Packages: Resolve Inline
- System.Web Adapters: Use System.Web Adapters
  Skill: aspnet-system-web-adapters

### Modernization
- Assembly Binding Redirects: Document and Review Before Removing
- Nullable Reference Types: Leave Disabled

## Strategy
**Selected**: All-at-Once
**Rationale**: Single-project .NET Framework web migration with side-by-side approach selected; no multi-project dependency tiers to sequence.

### Execution Constraints
- Single atomic modernization flow anchored by scaffold then migrate for the web project.
- Side-by-side web tasks supersede in-place TFM conversion for the existing ASP.NET Framework project.
- Scaffold task must validate baseline Core host/proxy behavior before migration work starts.
- Old Framework web project remains live and deployable until migration validation is complete.
- Final cleanup and validation must complete before recommending removal of the old project.

### Side-by-Side Web Migration Constraints
- Scaffold task must complete and validate (builds, stub 200 response) before migrate starts.
- Old Framework project remains live and deployable throughout entire migrate phase.
- Migrate task will be broken into subtasks at execution time — load migrating-aspnet-framework-to-core skill.
- Libraries in migrate task scope are handled in dependency order before web layer assets.
- Reference cleanup (test projects, multi-targeting) is part of migrate, not a separate task.
- Old project is NOT deleted by the agent — documented as post-upgrade step for user.
