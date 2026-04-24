# Squad Decisions

## Active Decisions

### 1. Workshop Content Audit & Modernization Strategy

**Status:** In Progress | **Date:** 2026-04-20

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

#### 1.1 Copilot App Modernization Integration — Priority Action Items

**Status:** Extracted for roadmap | **Date:** 2026-04-20 | **Source:** Charlie + Arvid analysis

**Priority 1: Terminology & Tool Naming Clarity**
- **Issue:** Mixed naming conventions confuse learners about the official GA tool
- **Action:** Standardize on "GitHub Copilot App Modernization" or `@Modernize` throughout Modules 2B and 3
- **Owner:** Darlene (Content)
- **Estimated effort:** Low (terminology sweep)

**Priority 2: Assessment Phase Visibility**
- **Issue:** Module 2B mentions "analysis" but doesn't explain what the Assessment stage discovers
- **Action:** Add section explaining Assessment phase output (what Copilot checks, where results appear)
- **Owner:** Darlene (Content)
- **Estimated effort:** Medium

**Priority 3: Three-Stage Workflow Documentation**
- **Issue:** Stages (Assessment → Planning → Execution) described step-by-step but not explicitly named
- **Action:** Add visual or explicit headings for each stage in Module 2B's "Getting Started"
- **Owner:** Darlene (Content)
- **Estimated effort:** Low

**Priority 4: Built-in Scenarios Reference**
- **Issue:** Module 3 mentions scenarios in prose but doesn't show how to access or invoke them
- **Action:** Add subsection with table/list of built-in scenarios and UI steps to select them
- **Owner:** Darlene (Content) + Simone (Testing)
- **Estimated effort:** Medium

**Priority 5: Guided vs. Automatic Mode**
- **Issue:** Only default flow shown; no mention of mode selection or risk management implications
- **Action:** Add sidebar/tip explaining both modes and when to use each
- **Owner:** Arvid (Technical) review + Darlene (Content)
- **Estimated effort:** Low

**Priority 6: Custom Skills Explanation**
- **Issue:** Module 3 briefly mentions "custom upgrade skills" without explanation
- **Action:** Add "Learn More" link and simple example (repo-specific pattern file)
- **Owner:** Arvid (Technical) + Darlene (Content)
- **Estimated effort:** Medium

**Priority 7: Module 2B → Module 3 Flow Clarity**
- **Issue:** Module 3 provides fresh StartSample; learners may be confused about whether to use Module 2B output
- **Action:** Add explicit guidance in Module 3 Prerequisites about when to use fresh vs. carried-over code
- **Owner:** Charlie (Lead decision) + Darlene (Content)
- **Estimated effort:** Low

**Priority 8: Troubleshooting & IDE Flexibility**
- **Issue:** Both modules assume Visual Studio; no mention of VS Code or other IDEs
- **Action:** Add note/link in Module 1 about supported IDEs and feature parity
- **Owner:** Arvid (Technical) + Darlene (Content)
- **Estimated effort:** Low

**Recommended Work Order:**
1. **Immediate:** Priority 1 (terminology standardization)
2. **Sprint 1:** Priorities 2–3 (Assessment phase, three-stage workflow)
3. **Sprint 1:** Priority 5 (Guided/Automatic mode)
4. **Sprint 2:** Priorities 4, 6 (scenarios table, custom skills reference)
5. **Sprint 2:** Priority 7 (Module 2B → 3 transition clarity)
6. **Backlog:** Priority 8 (IDE flexibility note)

### 2. Module 3: GitHub Copilot Modernization Tool Framing

**Status:** Implemented | **Date:** 2026-04-20  
**Agent:** Darlene (Content Developer)

**Context:** The GitHub Copilot Modernization tool went GA on September 22, 2025. Module 3's README referenced the tool but lacked context about its capabilities and 3-stage workflow (Assessment → Planning → Execution).

**Decision:** Add educational framing about the tool's capabilities while preserving the hands-on workshop experience. Do NOT replace existing manual prompts — they provide valuable learning through guided practice.

**Changes Made:**
1. **New Section:** "How GitHub Copilot Modernization Works" (after Prerequisites)
   - 3-stage workflow explanation (Assessment → Planning → Execution)
   - Built-in scenario list (namespace cleanup, DI migration, async/await, database modernization, Blazor conversion, JSON serialization, EF6→EF Core)
   - Automatic vs. Guided mode options
   - Custom skills capability (`.github/skills/`)

2. **Updated Intro Paragraph:** Made 3-stage workflow explicit in tool description

3. **Added TIP Box:** Notes that tool has built-in scenarios; manual prompt provides guidance but tool may suggest additional opportunities

4. **Added NOTE Box:** In Blazor Section, mentions Blazor conversion is a built-in scenario

**File Modified:** `3-modernize-with-github-copilot/README.md` — 4 surgical edits adding ~150 words

---

### 3. Module 4 README Context7 References - Fix

**Status:** Complete | **Date:** 2026-04-20  
**Agent:** Darlene (Content Developer)

**Summary:** Fixed all stale Context7 MCP server references in Module 4's README.md file. The `.mcp.json` config was already correctly updated to use `microsoft.docs.mcp`, but surrounding instructions and prompts still referenced the deprecated `context7` server.

**Changes Made:**
1. **Line 53:** Updated NOTE about deprecated server reference to acknowledge reference images may differ but direct to correct config
2. **Line 62:** Updated instruction in "Modernize Blazor Server App" section: `context7` → `microsoft.docs.mcp`
3. **Line 73:** Updated prompt in code block for Blazor migration: `context7` → `microsoft.docs.mcp`
4. **Line 116:** Updated instruction in "Separate microservices" section: `context7` → `microsoft.docs.mcp`
5. **Line 123:** Updated prompt in code block for microservices separation: `context7` → `microsoft.docs.mcp`

**Impact:** Users following Module 4 instructions now see consistent references to `microsoft.docs.mcp` throughout, aligning with actual MCP configuration provided.

---

### 4. .NET 10 and Aspire 13.2.2 Version Bump

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

---

### 5. Aspire Content Maturity Framing

**Status:** Complete | **Date:** 2026-04-20  
**Agent:** Arvid (.NET Developer)

**Context:** After updating all csproj files from Aspire 9.4.0 → 13.2.2 and .NET 9 → .NET 10, Module 5 & 6 README prose still framed .NET Aspire as "new" (referring to its .NET 8 debut).

**Decision:** Updated Module 5 & 6 README prose to reframe Aspire as mature/established while maintaining historical context.

**Changes Made:**
1. Reframed Aspire as "introduced with .NET 8 and now a mature part of the .NET 10 ecosystem"
2. Maintained historical context without erasing .NET 8 origin
3. Fixed Module 6 line 36 spacing issue

**Technical Verification:**
- Aspire versioning confirmed: Aspire 9.5 = initial .NET 10 support; Aspire 13 = latest stable (late 2025/early 2026)
- All code snippets verified against Aspire 13.x documentation
- `AddProject<T>`, `WithReference`, `WaitFor`, `AddRedis`, `AddRedisOutputCache` — all API stable, no breaking changes

**Files Modified:**
- `5-add-dotnet-aspire/README.md` (line 58)
- `6-add-redis-caching/README.md` (line 36)

---

### 6. Module 8 README Code Sample Alignment

**Status:** Implemented | **Date:** 2026-04-20  
**Agent:** Arvid (.NET Developer)

**Context:** Module 8's README code sample template (GitHub Models C# snippet in Step 1) had discrepancies from the actual EndSample implementation at `ChatbotService.cs`.

**Decision:** Aligned the README code sample to match the EndSample source of truth.

**Changes Made:**
1. **Model name:** Changed `"openai/o3-mini"` → `"gpt-4o-mini"` (EndSample uses gpt-4o-mini; o3-mini was leftover from template)
2. **Parameter values:** Replaced `{temperature}` and `{max_tokens}` placeholders with concrete values `0.7f` and `500` matching EndSample constants
3. **MEAI visibility:** Added Microsoft.Extensions.AI (MEAI) to architecture description; EndSample includes it as dependency and prompt mentions it (line 50)

**Rationale:**
- EndSample code is authoritative reference — README samples must match
- Unresolved template placeholders cause build errors for attendees
- MEAI is architecturally significant and deserves explicit mention

---

### 7. README.md .NET 9→10 Prose Updates

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

---

### 8. User Directive: Local Commits Only

**Status:** Documented | **Date:** 2026-04-20T11:04:54Z  
**By:** Jeff Fritz

**Directive:** Make local commits only, do NOT push anything to GitHub.
**Reason:** User request — captured for team memory

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
