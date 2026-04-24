# Workshop Update Summary — Review Report

**Date:** April 20, 2026  
**Squad:** Head of the Class (Charlie, Arvid, Darlene, Simone)  
**Status:** Paused for review — all commits local, nothing pushed

---

## Commits (oldest → newest)

| # | SHA | Message | Scope |
|---|-----|---------|-------|
| 1 | `14929d4` | chore: bump .NET 9→10 and Aspire SDK 9.4.0→13.2.2 across all modules | 31 csproj + 4 READMEs |
| 2 | `fb4046f` | docs: fix Context7→microsoft.docs.mcp references in Module 4 | 1 README |
| 3 | `a4482ec` | docs: add Copilot Modernization framing (Module 3) and Aspire prose updates (Modules 5-6) | 3 READMEs |
| 4 | `5590e33` | docs: fix Module 8 code samples, model name, and add MEAI framing | 1 README |

---

## Module-by-Module Changes

### Module 1 — Setup Your Environment
**File:** `1-setup-your-environment/README.md`
- Updated SDK link from `.NET 9 SDK` → `.NET 10 SDK` (URL updated to `/dotnet/10.0`)

### Module 2A — Upgrade with GitHub Copilot Modernization
**File:** `2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/README.md`
- 4 prose updates: `.NET 9` → `.NET 10` references in explanatory text
- **csproj bumped:** `eShopLite.StoreCore` — `net9.0` → `net10.0`
- ⚠️ `.NET Framework 4.8 starter project left untouched` (intentional — it's the upgrade exercise starting point)

### Module 2B — Upgrade with .NET Upgrade Assistant
**File:** `2-upgrade-dotnet/2-upgrade-with-dotnet-upgrade-assistant/README.md`
- 3 prose updates: `.NET 9` → `.NET 10` references
- **csproj bumped:** `eShopLite.StoreCore` — `net9.0` → `net10.0`
- ⚠️ `.NET Framework 4.8 starter project left untouched` (intentional — same reason)

### Module 3 — Modernize with GitHub Copilot
**File:** `3-modernize-with-github-copilot/README.md`
- **NEW SECTION:** "How GitHub Copilot Modernization Works" — explains the 3-stage workflow (Assessment → Planning → Execution)
- Listed 7 built-in modernization scenarios (namespace migration, DI, async, DB access, Blazor, JSON, EF)
- Added `> [!TIP]` callout after modernization prompt about built-in scenarios
- Added `> [!NOTE]` callout about Blazor conversion being a built-in scenario
- 5 prose updates: `.NET 9` → `.NET 10` references
- **csproj bumped:** `eShopLite.StoreCore` — `net9.0` → `net10.0`

### Module 4 — Refactor into Microservices
**File:** `4-refactor-into-microservices/README.md`
- **5 stale tool references fixed:** Changed `context7` / `Context7` MCP server references → `microsoft.docs.mcp` / `Microsoft Learn MCP server`
  - Line 53: Tool name in prompt
  - Line 62: Tool name in prompt
  - Line 73: Tool name in prompt
  - Line 116: Tool name in prompt
  - Line 123: Tool name in prompt
- **csproj bumped:** `eShopLite.StoreCore` — `net9.0` → `net10.0`

### Module 5 — Add .NET Aspire
**File:** `5-add-dotnet-aspire/README.md`
- Reframed Aspire description from "Since .NET 8, it includes the **new** .NET Aspire stack" → ".NET Aspire, introduced with .NET 8 and now a **mature part of the .NET 10 ecosystem**"
- **5 csproj files bumped:** All `net9.0` → `net10.0`

### Module 6 — Add Redis Caching
**File:** `6-add-redis-caching/README.md`
- **Typo fix:** `application..NET Aspire` → `application. .NET Aspire` (missing space after period)
- **5 csproj files bumped:** All `net9.0` → `net10.0`, Aspire hosting packages `9.x` → `13.2.2`

### Module 7 — Deploy to ACA with azd
**File:** `7-deploy-to-aca-with-azd/README.md`
- ⚠️ **NOT YET UPDATED** — identified issue: false claim about GitHub Actions CI/CD coverage
- **5 csproj files bumped:** All `net9.0` → `net10.0`, Aspire hosting packages `9.x` → `13.2.2`

### Module 8 — Add AI Capabilities
**File:** `8-add-ai-capabilities/README.md`
- **Header updated:** "Azure.AI.Inference" → "Microsoft.Extensions.AI (MEAI)" in section header
- **Typo fix:** "four our" → "for our"
- **NEW bullet:** Added MEAI explanation in architecture section — describes the abstraction layer for swapping AI providers
- **Code fix:** Removed double closing parenthesis `));` → `);`
- **Model name fix:** `openai/o3-mini` → `gpt-4o-mini` (matches EndSample code)
- **Placeholder fix:** `{temperature}` → `0.7f`, `{max_tokens}` → `500` (actual values)
- **5 csproj files bumped:** All `net9.0` → `net10.0`, Aspire hosting packages `9.x` → `13.2.2`

---

## csproj Version Bumps (31 files)

All eligible `.csproj` files across modules 2–8 received:
- `<TargetFramework>net9.0</TargetFramework>` → `<TargetFramework>net10.0</TargetFramework>`
- Aspire SDK packages: `9.4.0` → `13.2.2` (where applicable)

**Packages updated:**
- `Aspire.AppHost.Sdk`
- `Aspire.Hosting.AppHost`
- `Aspire.Hosting.Redis`
- `Aspire.Hosting.PostgreSQL`
- `Aspire.StackExchange.Redis.OutputCaching`
- `Npgsql.EntityFrameworkCore.PostgreSQL`

**NOT touched (by design):**
- `2-upgrade-dotnet/2-upgrade-with-ghcp-modernization-app/StartSample/src/eShopLite.StoreFx/` — .NET Framework 4.8 (upgrade exercise starting point)
- `2-upgrade-dotnet/2-upgrade-with-dotnet-upgrade-assistant/StartSample/src/eShopLite.StoreFx/` — .NET Framework 4.8 (upgrade exercise starting point)

---

## Remaining Work

| Priority | Module | Issue | Status |
|----------|--------|-------|--------|
| 🟡 Medium | Module 7 | False claim about GitHub Actions CI/CD coverage in README | Not started |

---

## How to Review

```bash
# See all commits
git log --oneline 38827da..HEAD

# See all file changes (excluding .squad scaffolding)
git diff --stat 38827da..HEAD -- ':!.squad'

# Review a specific module's README changes
git diff 38827da..HEAD -- 3-modernize-with-github-copilot/README.md

# Review all csproj changes
git diff 38827da..HEAD -- '*.csproj'

# Undo everything if needed
git reset --hard 38827da
```
