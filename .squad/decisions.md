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

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
