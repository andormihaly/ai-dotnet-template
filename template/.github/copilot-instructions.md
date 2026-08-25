# AI-Ready .NET

## Project Overview

AI-Ready .NET is a backend-only .NET 10 project based on Clean Architecture.

The project is designed for AI-assisted software development with GitHub Copilot.

## Architecture

The solution follows Clean Architecture and consists of four projects:

- `AiDotNet.Api` — ASP.NET Core Web API, controllers, application entry point, and composition root.
- `AiDotNet.Application` — application logic, features, interfaces, configuration, and application-level abstractions.
- `AiDotNet.Domain` — domain model and core business rules.
- `AiDotNet.Infrastructure` — infrastructure implementations, persistence, and external services.

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
