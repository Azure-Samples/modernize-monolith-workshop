# Project Context

- **Owner:** Jeff Fritz
- **Project:** Modernize your monolith workshop — 8-module full-day workshop upgrading .NET Framework monolith to modern .NET with microservices, .NET Aspire, Azure Container Apps, and AI.
- **Stack:** C#, .NET Framework → .NET, Blazor, ASP.NET Core Web API, .NET Aspire, Docker, Azure Container Apps, azd, GitHub Copilot, GitHub Actions, Bicep, Azure AI
- **Created:** 2026-04-20

## Learnings

- **GitHub Copilot Modernization GA:** Released Sep 22, 2025 (Java + .NET). Runs in VS, VS Code, CLI, GitHub.com. Three-stage workflow: Assessment → Planning → Execution.
- **Tool Capabilities:** 6 scenarios (.NET version upgrade, SDK-style conversion, Newtonsoft upgrade, SqlClient, Azure Functions, Semantic Kernel). 30+ built-in upgrade skills (EF6→EF Core, WCF→CoreWCF, OWIN→middleware, etc.).
- **State Management:** `.github/upgrades/{scenarioId}/` folder structure enables resumable, cross-IDE upgrades. Assessment.md, upgrade-options.md, plan.md, tasks.md, execution-log.md.
- **Workshop Terminology Outdated:** "GitHub Copilot Upgrade Assistant" → "GitHub Copilot modernization" / `@Modernize` (VS) / `@modernize-dotnet` (VS Code). Tool names changed post-preview.
- **Module 2 Gaps:** Missing Assessment workflow explanation, flow modes (Automatic/Guided), scenario inventory, IDE flexibility (VS Code path). Target is .NET 9; tool supports .NET 10+.
- **Module 3 Gaps:** Long manual prompts (namespace, DI, Newtonsoft, EF, Blazor) can be replaced by built-in scenarios/skills. Module 3 architecture modernization largely overlaps tool's built-in capabilities.
