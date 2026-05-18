# Team Decisions & Roadmap

## Copilot Modernization Integration (Module 2B)

**Section 1.1: Documentation & Learning Experience**

### Priority 1: Module 2B Intro Narrative
- **Status:** Complete
- **Outcome:** Pedagogical framework established; learning objectives, prerequisites, and cognitive scaffolding documented
- **Date:** 2026-04-20

### Priority 2: Assessment Phase Visibility  
- **Status:** ✅ Complete (2026-05-04)
- **Outcome:** Assessment Phase section added to README explaining what Copilot analyzes and where results appear
- **Agent:** Darlene (Content Developer)
- **Scope:** Reduces learner uncertainty about tool behavior

### Priority 3: Three-Stage Workflow Documentation
- **Status:** ✅ Complete (2026-05-04)
- **Outcome:** Explicit workflow introduction (Assessment → Planning → Execution) added to README
- **Agent:** Darlene (Content Developer)
- **Combined with:** Priority 2 for coherent single update
- **Pedagogical Impact:** Gives learners mental scaffold before detailed steps

### Priority 4: Breaking Changes Explanation
- **Status:** Pending
- **Scope:** Deep-dive section on .NET 10 breaking changes with before/after code examples
- **Target:** Module 2B README or separate guide

### Priority 5: Migration Path Clarity
- **Status:** Pending
- **Scope:** Explicit mapping of upgrade stages to learner actions
- **Dependencies:** Priorities 2–3 foundation

### Priority 6: Hands-On Lab Integration
- **Status:** Pending
- **Scope:** Guided exercises for learners to practice upgrade workflow

### Priority 7: Visual Assets
- **Status:** Pending
- **Scope:** Workflow diagram, assessment checklist graphics

### Priority 8: Community Feedback Loop
- **Status:** Pending
- **Scope:** Learner feedback collection and content iteration mechanism

---

---

## NuGet & Aspire SDK Standardization

**Status:** ✅ Complete (2026-05-11)  
**Agent:** Arvid  
**Decision:** Standardize modern workshop samples on Aspire 13.3.0 and aligned package lines (EF Core 10.0.7, Extensions 10.5.0)  
**Scope:** 31 net10.0 csproj files across Modules 2–8 samples and complete samples  
**Rationale:** Latest stable Aspire 13.3.0 compatible with .NET 10; dependency packages moved to current .NET 10 release lines  
**Validation:** All 9 solutions build cleanly post-update  
**Cross-reference:** `.squad/orchestration-log/2026-05-11T17-18-arvid.md`

---

## Module 7 Aspire CLI Deployment Modernization

**Status:** ✅ Complete (2026-05-11)  
**Agent:** Arvid  
**Decision:** Rewrite Module 7 from legacy azd-driven deployment to Aspire CLI publish pattern  
**Changes:**
- Add `Aspire.Hosting.Azure.AppContainers` 13.3.0 to AppHost
- Add `builder.AddAzureContainerAppEnvironment("env")` to AppHost.cs
- Rewrite README around: `aspire add azure-appcontainers`, `aspire deploy`, `aspire describe`, `aspire export`, `aspire destroy`
- Remove stale azd/manifest-analysis artifacts

**Rationale:** Current Aspire guidance supports Azure Container Apps deployment directly from AppHost. Aspire CLI covers the learner journey: adding deployment support, deploying interactively, inspecting resources, exporting diagnostics, tearing down. Avoids deprecated scaffolding (azure.yaml, azd infra gen, generated manifests).  
**Validation:** Build verified; Aspire CLI docs reviewed  
**Cross-reference:** `.squad/orchestration-log/2026-05-11T17-18-arvid.md`

---

## Product Terminology: Aspire Branding Simplification

**Status:** ✅ Complete (2026-05-11)  
**Agent:** Darlene  
**Decision:** Rename ".NET Aspire" → "Aspire" across all documentation  
**Scope:** 70+ instances across 11 READMEs and squad files  
**Rationale:** User directive (Jeff Fritz, 2026-05-11T13:16:53-04:00) — product branding simplified  
**Cross-reference:** `.squad/orchestration-log/2026-05-11T17-18-darlene.md`

---

## Content Review: Module 1–3 Learner-Facing Issues (Simone QA)

**Status:** ⚠️ Identified, Pending Fixes (2026-05-11)  
**Reviewer:** Simone (Tester/QA)  
**Scope:** `1-setup-your-environment/README.md`, `2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md`, `3-modernize-with-github-copilot/README.md`

**Assessment:** Direction of updates is good; workflow clarity improved. However, learner-facing accuracy issues identified:

**❌ FAIL (Blocking):**
1. **Installation walkthrough contradiction** (1-setup-your-environment, lines 46–69)
   - Says "Manage Extensions" and "Upgrade" menu; docs say "Visual Studio Installer" component and "Modernize" entry
   - **Action:** Split instructions: Manage Extensions for Upgrade Assistant, VS Installer for Copilot modernization
2. **VS Code agent name mismatch** (1-setup-your-environment, line 29)
   - Says `@Modernize`; docs say `@modernize-dotnet`
   - **Action:** Update to current registered agent name
3. **Menu terminology outdated** (2-upgrade-dotnet, lines 49–52)
   - Step 1 says "Upgrade with GitHub Copilot"; current docs use "Modernize"
   - **Action:** Update to current menu label
4. **Assessment-vs-plan workflow gap** (2-upgrade-dotnet, lines 89–115)
   - Jumps from analysis to plan editing; should show assessment.md first, then plan.md workflow
   - **Action:** Separate stages explicitly
5. **Broken link** (3-modernize-with-github-copilot, lines 89–93)
   - `https://learn.microsoft.com/dotnet/core/porting/github-copilot-app-modernization/custom-skills` returns 404
   - **Action:** Replace with valid doc or remove
6. **Blazor section ambiguity** (3-modernize-with-github-copilot, lines 215–231)
   - "Convert to Blazor pages" doesn't branch for Module 2B continuation path (already has Blazor)
   - **Action:** Add conditional: skip/validate if from Module 2B, execute if from Module 3 StartSample

**⚠️ WARN (Non-blocking):**
- MS Learn URL style inconsistent (mixed `/en-us/` and locale-less)
- Module 2B "What's Next" wording clashes with Module 3 Blazor coverage messaging
- Module 3 "upgrade_dotnet" tool naming not reinforced elsewhere

**Recommendation:** Do not consider workshop ready for delivery until FAIL issues are resolved.  
**Cross-reference:** `.squad/decisions/inbox/simone-content-review.md`

---

## Decision History

**2026-05-11** – NuGet standardization, Module 7 deployment modernization, branding refresh, content review findings captured
- Cross-references: `.squad/orchestration-log/2026-05-11T17-18-*.md`, `.squad/log/2026-05-11T17-18-aspire-updates.md`

**2026-05-04** – Priorities 2 & 3 combined and completed by Darlene (Content Developer)
- Rationale: Pedagogically related updates; combined delivery more effective than separate patches
- Cross-reference: `.squad/orchestration-log/2026-05-04T13-56-45Z-darlene.md`

**2026-04-24** – Scribe orchestration established

**2026-04-20** – Copilot Modernization roadmap initiated; Priority 1 completed
