# Project Context

- **Owner:** Jeff Fritz
- **Project:** Modernize your monolith workshop — 8-module full-day workshop upgrading .NET Framework monolith to modern .NET with microservices, .NET Aspire, Azure Container Apps, and AI.
- **Stack:** C#, .NET Framework → .NET, Blazor, ASP.NET Core Web API, .NET Aspire, Docker, Azure Container Apps, azd, GitHub Copilot, GitHub Actions, Bicep, Azure AI
- **Created:** 2026-04-20

## Learnings

- **Workshop Version Lock:** All 8 modules reference .NET 9 — single largest update needed. Affects 30+ csproj files, prompts, SDK links, screenshots. ✅ **RESOLVED** (Arvid, Darlene)
- **Module 4 Critical Issue:** Context7 → Microsoft Docs MCP migration incomplete — prompts still reference Context7 while config.json shows Microsoft Docs. Actively confusing for attendees. ✅ **RESOLVED** (Darlene)
- **Module Flow Overlap:** Modules 2B and 3 both use "Upgrade with Copilot" UI but for different purposes (framework upgrade vs. post-upgrade modernization). Distinction poorly explained.
- **Blazor Conversion Scope:** Module 3's Blazor conversion overlaps with Module 4's Blazor Web App migration. Attendees doing both modules will be confused.
- **MCP Server Fragility:** `sequentialthinking` MCP server requires Docker. May be fragile for workshop delivery.
- **Module Consistency Gap:** Modules 7 and 8 have CompleteSample/EndSample outputs but Modules 3–6 have only StartSample. No consistent validation point for most modules.

### Copilot App Modernization Integration (2026-04-20 → 2026-04-24)

**Status:** Analysis documented; roadmap extracted. Ready for Sprint 1 implementation.

**Assessment Summary:**
- **Good News:** Modules 2B and 3 already demonstrate end-to-end Copilot App Modernization. No fundamental restructuring needed.
- **Terminology Gap:** Mixed naming ("GitHub Copilot Upgrade Assistant" vs. "GitHub Copilot App Modernization" vs. "upgrade_dotnet" MCP tool). Learners may not recognize they're using GA tooling. ✅ **Priority 1**
- **Assessment Phase Visibility:** Module 2B mentions "analysis" but doesn't explain what the Assessment stage discovers or how to inspect results. ✅ **Priority 2**
- **Three-Stage Workflow:** Workflow described step-by-step but stages (Assessment → Planning → Execution) not explicitly named or structured. ✅ **Priority 3**
- **Built-in Scenarios:** Module 3 mentions scenarios in prose but doesn't show how to access them in the UI or when to use each. ✅ **Priority 4**
- **Guided vs. Automatic Mode:** No mention of mode selection or risk management implications. ✅ **Priority 5**
- **Custom Skills:** Mentioned briefly in Module 3 but not explained or linked to resources. ✅ **Priority 6**
- **Module 2B → 3 Transition:** Module 3 provides fresh StartSample; learners confused about when to use it vs. Module 2B output. ✅ **Priority 7**
- **IDE Flexibility:** Modules assume Visual Studio; no mention of VS Code. ✅ **Priority 8**

**8-Priority Roadmap:**
1. **Immediate:** Terminology standardization (low effort, high clarity impact)
2. **Sprint 1:** Assessment phase visibility + 3-stage workflow headings (medium effort, core understanding)
3. **Sprint 1:** Guided/Automatic mode explanation (low effort, risk awareness)
4. **Sprint 2:** Built-in scenarios table + custom skills reference (medium effort, advanced features)
5. **Sprint 2:** Module 2B → 3 transition clarity (low effort, workflow continuity)
6. **Backlog:** IDE flexibility note (low effort, inclusivity)
