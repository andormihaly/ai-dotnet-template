# AI-Ready .NET

## Project Overview

AI-Ready .NET is a backend-only .NET 10 project based on Clean Architecture.

The project is designed for AI-assisted software development with GitHub Copilot.

## Architecture

The solution follows Clean Architecture and consists of four projects:

- `Api` — ASP.NET Core Web API, controllers, application entry point, and composition root.
- `Application` — application logic, features, interfaces, configuration, and application-level abstractions.
- `Domain` — domain model and core business rules.
- `Infrastructure` — infrastructure implementations, persistence, and external services.

### Dependency Rules

- `Domain` has no project dependencies.
- `Application` depends only on `Domain`.
- `Infrastructure` depends only on `Application`.
- `Api` depends on `Application` and `Infrastructure`.
- Respect project boundaries when adding new functionality.

## Development Guidelines

- Use modern .NET and C# practices.
- Follow the existing architecture and project boundaries.
- Keep changes focused on the requested task.
- Do not modify unrelated code without a clear reason.
- Do not introduce new dependencies without a clear reason.
- Follow existing naming and coding conventions.
- Explain the rationale behind non-obvious architectural decisions.

## Planning

- Plan before implementing non-trivial changes.
- Clarify architectural decisions before writing code.
- If implementation reveals that the current approach is incorrect, stop and re-plan rather than forcing the original approach.
- Keep plans proportional to the complexity of the task.

## Verification

- Verify changes before considering a task complete.
- Build the solution after code changes.
- Run relevant tests when tests exist.
- Verify that the implementation satisfies the requested behavior.
- Clearly state anything that could not be verified.

## Problem Solving

- Investigate and resolve errors encountered while performing the requested task when the cause can be determined reliably.
- Fix root causes rather than applying workarounds that hide the problem.
- Keep fixes within the scope of the requested task.
- Do not make unrelated changes solely to make a build or test pass.
- Ask for clarification when resolving the problem requires assumptions about requirements or architecture.

## Simplicity

- Prefer simple, maintainable solutions over unnecessary abstractions.
- Do not introduce abstractions, patterns, or infrastructure without a concrete need.
- Implement for current requirements rather than speculative future requirements.
- Reuse existing project patterns before introducing new ones.

## AI Development

The repository provides an AI-assisted development layer built around instructions, skills, specialized agents, and MCP tools.

Keep AI instructions concise and use the appropriate component instead of placing detailed technical guidance in this file.

### Instructions

Instructions define concise development constraints that apply globally or to specific paths.

- Follow `.github/copilot-instructions.md` at all times.
- Follow applicable path-specific instructions under `.github/instructions/*.instructions.md`.
- Keep instructions concise and focused on constraints that should always apply within their scope.
- Put detailed or task-specific technical guidance in skills rather than instructions.

### Skills

Skills provide reusable technical or domain-specific knowledge and procedures.

- Skills live under `.github/skills/<skill-name>/SKILL.md`.
- Use skills only when they are relevant to the current task.
- Keep skills concise, practical, and include rationale for their recommendations.

### Agents

Agents provide specialized roles for specific development tasks.

- Custom agents live under `.github/agents/*.agent.md`.
- Delegate tasks to specialized agents when their expertise matches the task.
- Agents may use relevant skills and available MCP tools to perform their responsibilities.
- Keep agent responsibilities focused and respect their defined boundaries.

### MCP

MCP servers provide tools that extend AI capabilities with structured access to development tools, project information, or external systems.

- Prefer MCP tools when they provide more reliable or structured information than manual inspection.
- Use only MCP tools relevant to the current task.
- Prefer concise, targeted tool results over loading unnecessary context.

## Context Guidelines

- Keep project-level instructions concise.
- Do not duplicate detailed guidance that belongs in path-specific instructions, skills, or agents.
- Prefer loading specialized context only when it is relevant to the current task.
- Keep AI context token-conscious.

## Roslyn MCP Code Navigation

Use the `dotnet-roslyn` MCP server as the preferred source of semantic information about the loaded .NET solution.

- Prefer Roslyn MCP over grep, globbing, repository-wide text search, or broad source-file reads when the task is about C# symbols, usages, implementations, callers, inheritance, dependencies, project structure, ASP.NET endpoints, or dependency injection.
- Start with the smallest semantic query that can answer the discovery question. Use MCP results to narrow the scope before reading source.
- Treat successful MCP discovery as a replacement for equivalent repository-wide discovery. Do not repeat the same lookup with grep, glob, text search, or broad file reads.
- Wait for MCP discovery results before deciding which source files need to be read. Do not launch equivalent repository discovery in parallel with the MCP call.
- Read source only when implementation details are still needed or when a file must be modified. Prefer targeted member/source retrieval or a file outline before reading a full file.
- For project configuration, dependencies, endpoints, and DI registrations, prefer the corresponding Roslyn MCP capability before manually inspecting `.csproj`, `Directory.*.props`, controller registrations, `Program.cs`, or DI extension files.
- Before changing a shared symbol, public API, abstraction, endpoint, dependency, or architectural boundary, use semantic impact analysis where relevant.
- Do not force MCP usage when the required code is already known and present in context, or when MCP cannot answer the question precisely.
- Keep MCP usage sequential and purposeful: semantic discovery → targeted source inspection when needed → modification → verification.
- Avoid redundant tool calls. Once a trustworthy MCP result answers a question, reuse it instead of rediscovering the same information.
- Prefer semantic information from Roslyn MCP when it can answer a codebase question more precisely than repository inspection.
- Use information already obtained from MCP to guide subsequent exploration and avoid unnecessary or redundant context gathering.
- Keep repository exploration proportional to the task: inspect only the additional source or configuration needed to understand or implement the change.
The goal is not to call every MCP tool. The goal is to use Roslyn semantics whenever they reduce ambiguity, repository scanning, or unnecessary context consumption.

