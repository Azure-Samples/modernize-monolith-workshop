# 03-migrate-storefx-web-assets: Migrate StoreFx web assets and dependencies incrementally

Move web application capabilities from the Framework project into the new Core project in controlled increments, including configuration, middleware/pipeline behavior, MVC endpoints/views, and dependency adjustments required by package compatibility findings.

Execute System.Web adapter usage for transitional compatibility, resolve unsupported packages inline, review and remove binding redirects safely, and complete reference cleanup as migration converges.

**Done when**: Required web assets are migrated to the Core project, compatibility/package issues are resolved for the migration scope, legacy dependency bridges are reduced per plan, and migrated functionality builds and runs in the new project.
