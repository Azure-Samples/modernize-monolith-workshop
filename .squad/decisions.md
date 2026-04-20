# Squad Decisions

## Active Decisions

### 1. Workshop Content Audit & Modernization Strategy

**Status:** Documented | **Date:** 2026-04-20

**Charlie's Assessment:** All 8 modules require version updates and strategic improvements.
- **Module 1–8:** Comprehensive review with module-by-module issues, cross-cutting concerns, priority ranking
- **Key Finding:** Single largest update is .NET 9 → .NET 10 migration (affects 30+ csproj files, prompts, links, screenshots)
- **Secondary Issues:** Aspire SDK versioning, Context7/Microsoft Docs MCP half-migration, Module overlap (2B/3 Copilot UI, 3/4 Blazor conversion)
- **Recommended Action:** 8-step plan: Fix Module 4 (immediate), .NET 10 & Aspire updates (Sprint 1), Copilot tool depth (Sprint 2), screenshot refresh (Sprint 3)

**Arvid's Tool Gap Analysis:** GitHub Copilot Modernization tool has evolved significantly; workshop teaching is outdated.
- **Tool Status:** GA as of Sep 22, 2025 (both Java and .NET)
- **Three-Stage Workflow:** Assessment → Planning → Execution, with .NET 10 support and custom skills capability
- **Module 2 Gaps:** Outdated terminology ("GitHub Copilot Upgrade Assistant" → "GitHub Copilot modernization" / `@Modernize`), missing Assessment workflow explanation, no Guided/Automatic mode docs, no IDE flexibility
- **Module 3 Gaps:** Manual long prompts replace built-in scenarios (Newtonsoft→STJ, EF6→EF Core, etc.); can be streamlined significantly
- **Recommended Action:** 12 prioritized updates, top 5 being terminology, three-stage workflow, .NET 10 target, scenarios reference table, Module 3 streamlining

**Decision:** Accept both assessments as work-ready. Prioritize immediate Module 4 fix (Context7 confusion), then tackle Modules 2–3 comprehensively in Sprint 1 for .NET 10 and Copilot tool alignment.

### 2. .NET 10 and Aspire 13.2.2 Version Bump

**Status:** Executed | **Date:** 2026-04-20  
**Agent:** Arvid (.NET Developer)

**What Changed:**
1. **TargetFramework:** `net9.0` → `net10.0` across 31 csproj files (modules 2–8)
2. **Aspire.AppHost.Sdk:** `9.4.0` → `13.2.2` (latest stable)
3. **Aspire NuGet packages:** All `9.4.0` references updated to `13.2.2`
   - Aspire.Hosting.AppHost
   - Aspire.Hosting.Redis
   - Aspire.Hosting.PostgreSQL
   - Aspire.StackExchange.Redis.OutputCaching
   - Aspire.Npgsql.EntityFrameworkCore.PostgreSQL
   - ServiceDefaults Microsoft.Extensions.* Aspire packages

**What Was NOT Changed:**
- Module 2 .NET Framework projects (eShopLite.StoreFx.csproj) remain on .NET Framework 4.8 (starter point for upgrade exercise)

**Verification:**
- Zero `net9.0` TargetFramework references remain
- Zero `9.4.0` Aspire version references remain
- .NET Framework 4.8 projects confirmed untouched

**Note:** Aspire versioning jumped from 9.x to 13.x with .NET 10 release cycle (9.x line deprecated as of April 2026).

### 3. README.md .NET 9→10 Prose Updates

**Status:** Complete | **Date:** 2026-04-20  
**Agent:** Darlene (Content Developer)

**Summary:** Updated 13 prose references from ".NET 9" to ".NET 10" across 4 README files (Modules 1, 2A, 2B, 3). Surgical prose-only changes; no code blocks or csproj examples modified.

**Files Updated:**
1. 1-setup-your-environment/README.md (1 update)
2. 2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md (4 updates)
3. 2-upgrade-dotnet/2-upgrade-with-dotnet-upgrade-assistant/README.md (3 updates)
4. 3-modernize-with-github-copilot/README.md (5 updates)

**Verification:**
- Grep confirms zero `.NET 9` and `net9.0` references in updated README files
- Grep confirms 13 `.NET 10` and `net10.0` references correctly applied
- No unintended changes to .NET Framework references
- No changes to external resource links or code blocks

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
