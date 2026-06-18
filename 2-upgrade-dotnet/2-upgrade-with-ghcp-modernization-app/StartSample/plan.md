# .NET Version Upgrade Plan

## Overview

**Target**: Migrate `src/eShopLite.StoreFx/eShopLite.StoreFx.csproj` from ASP.NET Framework (`net48`) to modern .NET (`net10.0`) using a side-by-side web migration path.
**Scope**: Single legacy web application with classic project format, System.Web usage, package compatibility work, and binding redirect cleanup.

### Selected Strategy
**All-At-Once** — All planned modernization work is organized as one coordinated upgrade flow.
**Rationale**: The solution scope is a single .NET Framework web project, so dependency-tier sequencing is unnecessary, while side-by-side tasks provide safer migration execution.

## Tasks

### 01-prerequisites: Validate upgrade toolchain and migration prerequisites

Confirm the environment and repository are ready for migration before changing application structure. This includes validating .NET SDK support for the target framework, ensuring assessment artifacts are in place, and confirming branch/state readiness for a side-by-side migration path.

This task also establishes the baseline inputs for scaffold and migration work, including the selected upgrade options (System.Web adapters, inline package resolution, and binding redirect review mode).

**Done when**: Required SDK/tooling prerequisites are validated, upgrade inputs are confirmed from scenario artifacts, and the project is ready to begin scaffold operations.

---

### 02-scaffold-storefx-core: Scaffold ASP.NET Core side-by-side host for StoreFx

Create the new ASP.NET Core project alongside the existing ASP.NET Framework application and configure reverse-proxy routing needed for incremental migration. The scaffold must preserve the legacy app as the active implementation while enabling Core-hosted routing and future endpoint cutover.

This task focuses on project creation and baseline host/proxy wiring only; no business feature migration occurs here.

**Done when**: A new ASP.NET Core side-by-side project exists, the solution builds with scaffold changes, and baseline host/proxy behavior validates successfully.

---

### 03-migrate-storefx-web-assets: Migrate StoreFx web assets and dependencies incrementally

Move web application capabilities from the Framework project into the new Core project in controlled increments, including configuration, middleware/pipeline behavior, MVC endpoints/views, and dependency adjustments required by package compatibility findings.

Execute System.Web adapter usage for transitional compatibility, resolve unsupported packages inline, review and remove binding redirects safely, and complete reference cleanup as migration converges.

**Done when**: Required web assets are migrated to the Core project, compatibility/package issues are resolved for the migration scope, legacy dependency bridges are reduced per plan, and migrated functionality builds and runs in the new project.

---

### 04-final-validation: Validate upgraded solution and capture post-upgrade actions

Run full solution validation for the migrated state, including build verification, relevant tests, and upgrade consistency checks against the chosen target framework and options. Capture any remaining manual follow-ups (such as eventual old project retirement timing) as post-upgrade guidance.

This task confirms that the migration output is stable and ready for continued development/deployment on the upgraded stack.

**Done when**: Solution validation passes for upgraded artifacts, no blocking upgrade issues remain unresolved, and post-upgrade follow-up items are documented.
