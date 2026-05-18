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

**Context:** After updating all csproj files from Aspire 9.4.0 → 13.2.2 and .NET 9 → .NET 10, Module 5 & 6 README prose still framed Aspire as "new" (referring to its .NET 8 debut).

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

### 9. Module 2B → Module 3 Transition Clarity

**Status:** Implemented | **Date:** 2026-04-24  
**Agent:** Darlene (Content Developer)

**Context:** Workshop attendees completing Module 2B (GitHub Copilot Modernization upgrade) have working .NET 10 code with Blazor components and SQLite. Module 3 provides a fresh `StartSample` baseline. The instructions were ambiguous about which to use.

**Decision:** Added explicit guidance in Module 3 Prerequisites explaining both valid paths:

1. **Continue with Module 2B output** — Your code is already upgraded; proceed directly to architectural modernization.
2. **Use Module 3's StartSample baseline** — Fresh, consistent starting point; ideal if you completed Module 2A or want standardized state.

**Rationale:**
- **Learner agency:** Both paths are valid; let attendees choose based on their learning flow preference.
- **Clarity reduces friction:** Explicit "either works" statement removes decision anxiety.
- **Acknowledges module overlap:** GitHub Copilot Modernization covers both upgrade AND modernization; some tasks may overlap (OK, per existing notes).

**Implementation:** Modified **3-modernize-with-github-copilot/README.md** Prerequisites section with decision tree and "Either works" normalization.

**Files Modified:**
- `3-modernize-with-github-copilot/README.md` (Prerequisites section, ~8 lines)

**Impact:**
- User impact: High (removes learner confusion)
- Dev impact: Low (documentation only)

---

### 10. GitHub Copilot Product Naming Directive

**Status:** Implemented | **Date:** 2026-04-24  
**By:** Jeffrey T. Fritz (via Copilot)

**Directive:** GitHub renamed the product this month to simply "GitHub Copilot Modernization"; use that product name in workshop updates.

**Rationale:** User request — official product naming alignment

**Implementation:** Standardized terminology across all workshop README files:
- Replaced "GitHub Copilot Upgrade Assistant" with "GitHub Copilot Modernization"
- Updated product reference links and descriptions throughout Modules 1–3
- Ensured consistency in learner-facing documentation

**Files Modified:**
- 1-setup-your-environment/README.md
- 2-upgrade-dotnet/README.md
- 2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md
- 3-modernize-with-github-copilot/README.md
- README.md (pending final wording review)

**Impact:** Learners now see official product name throughout workshop; reduces confusion about tooling identity.

---

### 11. Priority 4: Built-in Scenarios Reference — Research & Implementation

**Status:** Completed | **Date:** 2026-05-04  
**Agents:** Arvid (Research), Darlene (Content)

#### Arvid's GitHub Copilot Modernization scenario UI research

**Scope:** How learners actually access and invoke built-in GitHub Copilot Modernization capabilities in Visual Studio.

**Exact findings from Microsoft docs:**

1. **Entry points:** In Visual Studio, documented entry points are **right-click > Modernize** or **Copilot Chat + `@Modernize`**
   - The .NET upgrade article: in Visual Studio, start by either right-clicking the solution or project in **Solution Explorer** and selecting **Modernize**, or opening **GitHub Copilot Chat** and typing `@Modernize`. Then, **tell the agent what to upgrade or migrate**.
   - Visual Studio 17.14 release notes confirm both launch methods.

2. **No documented scenario picker UI for .NET modernization**
   - Current .NET docs consistently describe the flow as: start the modernization agent, then describe the goal in natural language.
   - The only documented picker is the **agent picker** in Copilot Chat.
   - Concepts/reference docs say you do **not** need to memorize scenario names because the agent discovers relevant scenarios automatically.

3. **Target specific capabilities via natural language**
   - Users ask for the outcome in chat; the agent maps that request to the right scenario and/or skills.
   - Example prompts: "Upgrade my solution to .NET 10", "Help me upgrade from EF6 to EF Core", "Upgrade from Newtonsoft.Json"
   - Skills load automatically when relevant code is detected, and can also be invoked by request.

4. **Taxonomy correction: scenarios vs skills**
   - **Official .NET scenarios** (currently documented):
     1. .NET version upgrade
     2. SDK-style conversion
     3. Newtonsoft.Json upgrade
     4. SqlClient upgrade
     5. Azure Functions upgrade
     6. Semantic Kernel to Agents
   - **30+ built-in skills** including EF6→EF Core, MVC DI, MVC routing, OWIN, WCF/CoreWCF, and related upgrade tasks
   - Module 3's prior list mixed scenarios and skills incorrectly; Blazor conversion, namespace cleanup, and database modernization were not found as named official scenarios

5. **Right-click Modernize vs Copilot Chat: same agent, different entry point**
   - **Right-click > Modernize:** convenience launch from Solution Explorer, naturally scoped to selected project/solution
   - **Copilot Chat + `@Modernize`:** conversational route; clearest for requesting specific upgrade focus, asking what scenarios are available, reviewing status, switching modes
   - No documented functional difference in capability between entry points

6. **Automatic vs Guided mode**
   - **Automatic:** agent moves through assessment, planning, execution without stopping at each boundary unless blocked
   - **Guided:** agent pauses after assessment, after planning, and at key decision points for review
   - Users can switch modes mid-session by saying **"pause"**, **"switch to guided"**, or **"continue"**

7. **Current naming and GA status**
   - .NET docs prefer **GitHub Copilot modernization** (lowercase 'm')
   - VS docs reference **GitHub Copilot app modernization** (older phrasing)
   - GA as of Sep 22, 2025 (both Java and .NET IDEs)
   - Visual Studio includes as optional component (17.14+)

**Recommendation:** Workshop prose should prefer **GitHub Copilot modernization**, noting some URLs still contain **app modernization**.

---

#### Darlene's Module 3 README updates (Scenarios & entry points)

**Context:** Module 3 README incorrectly framed scenarios as a UI picker and listed items (Blazor conversion, namespace cleanup) not found as official scenarios in Microsoft docs.

**Changes Made:**
1. Updated Module 3 prerequisite: noted VS 2022 17.14+ requirement as optional component
2. Replaced inaccurate "built-in scenarios" list with doc-backed two-entry-point guidance
3. **New section:** Official scenarios vs built-in skills comparison table
   - **Official scenarios:** .NET version upgrade, SDK-style conversion, Newtonsoft→STJ, SqlClient upgrade, Azure Functions upgrade, Semantic Kernel to Agents
   - **Workshop-relevant skills:** EF6→EF Core, MVC dependency injection, Newtonsoft→System.Text.Json
4. Clarified: no scenario picker UI; learners describe desired outcome in natural language
5. Added Guided vs Automatic mode guidance, with Guided recommended for workshop
6. Added example prompts learners can copy into chat
7. Updated Blazor note to avoid implying menu-based scenario picker

**File Modified:** `3-modernize-with-github-copilot/README.md` (~200 words, extensive rewrite with accuracy corrections)

**Rationale:**
- Arvid's research exposed gaps between workshop framing and actual product docs
- Table format separates official scenarios from built-in skills for learner clarity
- Example prompts lower friction for workshop attendees unfamiliar with agent interaction
- Guided mode recommendation aligns with workshop pedagogy (reflective practice)

---

### 12. Priorities 5–8: Content Improvements for Learner Clarity

**Status:** Completed | **Date:** 2026-05-04  
**Agent:** Darlene (Content Developer)

**Summary:** Implemented four content improvements across three files to enhance learner clarity, navigation, and IDE flexibility. All edits support the core workshop narrative: clear guidance, better transitions, and accessibility across tools.

#### Priority 5: Guided vs. Automatic Mode Comparison Table
**File:** `3-modernize-with-github-copilot/README.md`

**What changed:**
- Replaced the brief TIP box (lines 67–69) with a structured comparison section
- Added intro explaining two workflow modes
- Created a 3-column table comparing Guided and Automatic modes on three dimensions:
  - How it works
  - Best for
  - Switch to it (commands)
- Added recommendation callout: "For this workshop, use **Guided** mode so you can inspect each stage and learn"

**Why:**
Learners benefit from seeing mode options side-by-side. The table format is scannable and decision-friendly without being verbose. The recommendation gives clear guidance for this workshop context.

---

#### Priority 6: Custom Skills (Advanced) Section
**File:** `3-modernize-with-github-copilot/README.md`

**What changed:**
- Added new section `### 🛠️ Custom Skills (Advanced)` after the "Example prompts" list
- Explained that custom skills live in `.github/skills/` and are markdown-based patterns
- Included example use case (database wrapping, service layers)
- Wrapped in a "Learn More" TIP box pointing to official documentation
- Clearly labeled as "optional and out of scope for this workshop"

**Why:**
Learners may wonder if they can extend Copilot's modernization capability. This section acknowledges that feature without overwhelming the workshop scope. It's a "learn more" pointer, not a tutorial.

---

#### Priority 7: Module 2B → Module 3 Flow Clarity
**File:** `2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md`

**What changed:**
- Added `## ➡️ What's Next` section before the final `---` separator
- Explains that Module 3 deepens the modernization work (architecture, patterns, Blazor conversion)
- Includes TIP about fresh StartSample option in Module 3 vs. continuing with upgraded code
- Links back to Module 3's "Choose Your Starting Point" section

**Why:**
Learners complete Module 2B and need to know what comes next and how their output connects. The TIP addresses a common question: "Can I keep my code, or should I start fresh?" This reduces friction and uncertainty at module boundaries.

---

#### Priority 8: IDE Flexibility Note & Extension→Built-in Update
**File:** `1-setup-your-environment/README.md`

**What changed:**

**Change A (after line 25):**
- Added IDE Flexibility callout box
- Clarifies that workshop targets **Visual Studio 2022 (17.14+)** for deepest integration
- Acknowledges VS Code support via `@Modernize` in Copilot Chat
- Notes that some visual features (context menu, plan editor) may differ but core workflow is the same
- Encourages choice: "Choose the IDE you're most comfortable with"

**Change B (line 31):**
- Updated GitHub Copilot Modernization description from "This extension" to "Built into Visual Studio 2022 17.14+ as an optional component"
- Changed URL from `...modernization-install#visual-studio-extension` to `...modernization/install` (cleaner, more authoritative link)
- Updated language to reflect it's now built-in, not an add-on extension

**Why:**
The GitHub Copilot Modernization tool was recently integrated into VS 2022 17.14+ as a built-in optional component, not an external extension. This was a major change from the install model. The IDE flexibility note removes the implicit assumption that Visual Studio is the only option, making the workshop more inclusive. Learners using VS Code deserve acknowledgment and guidance on their workflow.

---

**Learner Impact:**
- **Clearer decision-making:** Guided vs. Automatic mode table helps learners choose the right workflow
- **Reduced scope anxiety:** Custom Skills section manages expectations without excluding advanced learners
- **Better module transitions:** Module 2B→3 callout reduces friction and answers common next-step questions
- **More inclusive:** IDE flexibility note welcomes VS Code users and clarifies the install story

**Technical Notes:**
All edits were surgical, non-breaking changes to existing files. No files were deleted or restructured. The changes integrate seamlessly with existing content and maintain consistent tone, formatting, and callout style.

---

### 13. Module 9 WinForms Migration Architecture

**Status:** Adopted | **Date:** 2026-05-11  
**Agents:** Charlie (Lead), Arvid (.NET Dev), Darlene (Content)

#### Charlie's Module 9 Architecture Decision

**Context:** eShopLite workshop currently covers monolith-to-microservices modernization (Modules 1–8: web, services, orchestration, deployment, AI). A realistic modernization story usually includes internal back-office tools still running as legacy desktop apps.

**Decision:** Add Module 9 as a standalone desktop client modernization module.

**Module Name:** `9-migrate-winforms`

**Narrative:** Position the WinForms admin tool as the "last legacy operational client" in the eShopLite estate—complementing web modernization, not replacing it. Story arc:
- Modules 2–3: Upgrade the web monolith from .NET Framework 4.8 to .NET 10
- Modules 4–8: Refactor into microservices, add Aspire orchestration, deploy to cloud, add AI
- Module 9: Modernize the internal admin desktop tool that operations depends on

**StartSample Design:**
- Name: `eShopLite.Admin.WinFormsFx`
- Target: .NET Framework 4.8
- Style: Old-style .csproj, packages.config, App.config
- Features: Product CRUD, read-only order viewer
- Data: EF6 + LocalDB style persistence
- Intention: Preserve legacy patterns authentically

**CompleteSample Design:**
- Name: `eShopLite.Admin.WinForms`
- Target: net10.0-windows (SDK-style)
- Style: appsettings.json, Generic Host + DI, EF Core + SQLite
- Features: Same product CRUD, order viewer (same UI)
- Architecture: Async services, modern config, testable layer separation
- Intention: Show realistic post-migration modernization (not just "compile and ship")

**Tooling Strategy:**
1. **.NET Upgrade Assistant first** — handles mechanical lift (project conversion, framework migration, designer preservation)
2. **GitHub Copilot Modernization second** — handles post-upgrade cleanup (async patterns, DI, service extraction, modern logging)

**Aspire Integration:** Keep standalone. Desktop modernization is orthogonal to cloud orchestration. Optional: add a stretch goal to point the WinForms app at Aspire-hosted APIs.

**Data Model Reuse:**
- **Product:** Reuse existing eShopLite Product contract (`Id`, `Name`, `Description`, `Price`, `ImageUrl`) from Modules 5–6
- **Order:** Add lightweight `Order` and `OrderLineItem` models locally (no upstream changes needed)

**Teaching Objectives:**
1. Project system modernization (WinForms-specific: designers, resources, fonts)
2. Configuration migration (App.config → appsettings.json)
3. Data access modernization (EF6 → EF Core, LocalDB → SQLite)
4. Async patterns in desktop apps
5. Dependency injection in Windows Forms
6. Using AI-assisted tools for post-migration cleanup

**Key WinForms-Specific Challenges to Surface:**
- Designer file preservation and partial class integrity
- Resource and image handling post-migration
- Project file syntax changes (.NET Framework → SDK-style)
- Configuration binding changes
- Data access layer migration
- Threading and UI responsiveness
- Desktop-specific DI patterns

**Rationale:**
- Completes the eShopLite modernization narrative (web + services + cloud + desktop)
- Shows that modernization applies to all client types, not just web
- Teaches realistic desktop migration with both mechanical and engineering phases
- Provides authentic sample of legacy WinForms code worth upgrading

---

#### Arvid's WinForms Migration Patterns Research

**Research Scope:** Validate Module 9 architecture against existing codebase and identify key migration challenges.

**Findings:**

1. **Existing eShopLite Data Model:**
   - Products service (Modules 5–6) exposes `Product` model: `id`, `name`, `description`, `price`, `imageUrl`
   - Products API endpoints: `GET /api/products/`, `GET /api/products/{id}` (read-only)
   - Store app consumes via `ProductApiClient`
   - No Orders service found in Modules 4–6

2. **Module 9 Prototype Shape:**
   - **StartSample:** `9-migrate-winforms/StartSample/eShopLite.AdminFx/`
     - .NET Framework 4.8, old-style .csproj, packages.config, App.config
     - HttpClient + Newtonsoft.Json, classic event handlers
   - **CompleteSample:** `9-migrate-winforms/CompleteSample/eShopLite.Admin/`
     - net10.0-windows, SDK-style .csproj, appsettings.json
     - Generic Host + DI + IHttpClientFactory, System.Text.Json

3. **Key Migration Challenges:**
   - **Project system conversion:** old-style → SDK-style, explicit file includes → implicit compile items
   - **Configuration migration:** App.config → appsettings.json + IOptions binding
   - **WinForms UI review:** default font changes can cause layout drift
   - **Windows-only targeting:** must use `net10.0-windows` with `UseWindowsForms`
   - **Package/API modernization:** direct carry-forward needs cleanup even if app compiles

4. **Breaking Changes Worth Teaching:**
   - API obsoletions in .NET 10 WinForms
   - StatusStrip render mode default (now System)
   - System.Drawing exception behavior (OutOfMemoryException → ExternalException)
   - MenuItem/ContextMenu naming ambiguity (WPF/WinForms mixing)
   - HtmlElement.InsertAdjacentElement parameter rename

5. **Package Migration Mappings:**
   | Legacy | Modern |
   | --- | --- |
   | packages.config | SDK-style PackageReference |
   | Newtonsoft.Json | System.Text.Json |
   | System.Data.SqlClient | Microsoft.Data.SqlClient |
   | direct HttpClient | IHttpClientFactory |
   | ConfigurationManager + App.config | IOptions binding |

6. **Upgrade Assistant vs Manual Work:**
   - **Usually automated:** project conversion, TFM update, package analysis, diagnostics
   - **Usually manual:** designer validation, layout drift fixes, config pattern changes, architecture decisions

**Recommendation:** Both samples built and tested. Ready for learner documentation.

---

#### Darlene's Module 9 README Structure

**Scope:** Develop learner-facing documentation for Module 9 WinForms migration.

**Content Architecture:**
1. Title and intro (narrative: "last legacy client")
2. What you'll do (learning path)
3. Why this admin app matters (portfolio context)
4. Prerequisites (SDKs, tools)
5. StartSample overview (identity, features, legacy patterns)
6. Migration steps (baseline → Upgrade Assistant → repair → modernize config/data → GitHub Copilot Modernization cleanup)
7. Common issues / troubleshooting
8. Verification checklist
9. What you accomplished
10. Optional next steps (Aspire API bridge)

**Key Authoring Decisions:**
- Anchor story around "last legacy client" theme
- Surface manual work clearly (what tools automate vs. what requires engineering)
- Use before/after code snippets for csproj, config, HTTP patterns
- Explain local-only behavior (no backend write APIs)
- Test guidance against actual samples

**Status:** Authoring in progress; samples provide source of truth for step accuracy.

---

**Impact Summary:**
- Adds coherent desktop modernization story to workshop
- Surfaces WinForms-specific migration challenges not covered by web/cloud modules
- Teaches realistic post-migration modernization (not just "compile and ship")
- Completes eShopLite narrative arc: monolith → web services → cloud orchestration → internal desktop tooling

---

## Governance

- All meaningful changes require team consensus
- Document architectural decisions here
- Keep history focused on work, decisions focused on direction
