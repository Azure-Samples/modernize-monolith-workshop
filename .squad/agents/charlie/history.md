# Project Context

- **Owner:** Jeff Fritz
- **Project:** Modernize your monolith workshop — 8-module full-day workshop upgrading .NET Framework monolith to modern .NET with microservices, .NET Aspire, Azure Container Apps, and AI.
- **Stack:** C#, .NET Framework → .NET, Blazor, ASP.NET Core Web API, .NET Aspire, Docker, Azure Container Apps, azd, GitHub Copilot, GitHub Actions, Bicep, Azure AI
- **Created:** 2026-04-20

## Learnings

- **Workshop Version Lock:** All 8 modules reference .NET 9 — single largest update needed. Affects 30+ csproj files, prompts, SDK links, screenshots.
- **Module 4 Critical Issue:** Context7 → Microsoft Docs MCP migration incomplete — prompts still reference Context7 while config.json shows Microsoft Docs. Actively confusing for attendees.
- **Module Flow Overlap:** Modules 2B and 3 both use "Upgrade with Copilot" UI but for different purposes (framework upgrade vs. post-upgrade modernization). Distinction poorly explained.
- **Blazor Conversion Scope:** Module 3's Blazor conversion overlaps with Module 4's Blazor Web App migration. Attendees doing both modules will be confused.
- **MCP Server Fragility:** `sequentialthinking` MCP server requires Docker. May be fragile for workshop delivery.
- **Module Consistency Gap:** Modules 7 and 8 have CompleteSample/EndSample outputs but Modules 3–6 have only StartSample. No consistent validation point for most modules.
