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
- **Version Bump Sprint (2026-04-20):** Coordinated with Darlene to update 31 csproj files (.NET 9→10, Aspire 9.4.0→13.2.2) while leaving Module 2 .NET Framework 4.8 starter projects untouched. Zero breaking changes. Version jump from 9.x to 13.x reflects Aspire deprecation cycle with .NET 10 GA.
- **Aspire README Content Update (2026-04-20):** Updated prose in Module 5 and 6 READMEs to reflect Aspire as mature/established (no longer "new"). Fixed Module 6 typo. Verified all code snippets (AddProject, WithReference, WaitFor, AddRedis, AddRedisOutputCache) remain valid for Aspire 13.2.2 / .NET 10—no API breaking changes. Aspire 13 is latest stable for .NET 10; Aspire 9.5 was initial .NET 10 support release.
