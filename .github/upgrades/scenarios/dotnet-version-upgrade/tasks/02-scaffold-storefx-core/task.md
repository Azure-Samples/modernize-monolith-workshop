# 02-scaffold-storefx-core: Scaffold ASP.NET Core side-by-side host for StoreFx

Create the new ASP.NET Core project alongside the existing ASP.NET Framework application and configure reverse-proxy routing needed for incremental migration. The scaffold must preserve the legacy app as the active implementation while enabling Core-hosted routing and future endpoint cutover.

This task focuses on project creation and baseline host/proxy wiring only; no business feature migration occurs here.

**Done when**: A new ASP.NET Core side-by-side project exists, the solution builds with scaffold changes, and baseline host/proxy behavior validates successfully.
