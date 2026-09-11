# AI-Ready .NET

An AI-ready .NET 10 backend template built around Clean Architecture and
designed for AI-assisted development with either GitHub Copilot or
Claude Code.

The template provides a production-oriented starting point for ASP.NET
Core APIs together with project instructions, reusable development
skills, specialized agents, and semantic .NET code navigation through
Roslyn MCP.

## Key Features

-   .NET 10 and ASP.NET Core Web API
-   Clean Architecture with explicit layer boundaries
-   GitHub Copilot or Claude Code configuration selected when creating
    the project
-   AI project instructions and path-specific development rules
-   Reusable skills for .NET, architecture, testing, security, Azure,
    observability, data access, and related development tasks
-   Specialized development agents
-   Roslyn-based semantic code navigation through `DotNet.RoslynMcp`
-   Microsoft Learn MCP integration
-   Entity Framework Core foundation
-   FluentValidation
-   OpenTelemetry instrumentation
-   OpenAPI and Scalar API reference
-   Central package management
-   Architecture tests for layer dependency rules
-   Global exception handling and Problem Details
-   Injectable `TimeProvider` for time-dependent code

## Architecture

Generated projects use four application layers plus architecture tests:

``` text
src/
├── <ProjectName>.Api
├── <ProjectName>.Application
├── <ProjectName>.Domain
└── <ProjectName>.Infrastructure

tests/
└── <ProjectName>.ArchitectureTests
```

### API

The ASP.NET Core host and composition root.

Responsibilities include:

-   HTTP endpoints and controllers
-   application startup
-   dependency registration composition
-   OpenAPI / Scalar
-   exception handling
-   HTTP logging
-   OpenTelemetry

### Application

Contains application-level behavior and abstractions.

The template includes locations for:

-   features
-   interfaces
-   configuration
-   application core components
-   FluentValidation validators

Application depends on Domain but remains independent of Infrastructure
and API.

### Domain

Contains the core domain model and shared domain abstractions.

The template provides:

-   `BaseEntity`
-   `AuditableEntity`

Domain has no dependency on Application, Infrastructure, or API.

### Infrastructure

Contains implementations of external and persistence concerns.

The initial structure includes:

-   Entity Framework Core
-   `AppDbContext`
-   persistence configuration and migrations
-   infrastructure services
-   `IAppDbContext` implementation
-   `TimeProvider` registration

Infrastructure depends on Application but remains independent of API.

### Architecture Tests

`NetArchTest.Rules` verifies the intended dependency direction between
layers.

The included tests ensure that:

-   Domain does not depend on Application, Infrastructure, or API
-   Application does not depend on Infrastructure or API
-   Infrastructure does not depend on API

## AI-Assisted Development

The template can be generated for one AI coding environment at a time:

-   `copilot` --- GitHub Copilot
-   `claude` --- Claude Code

The selected mode receives its own instructions, skills, agents, and MCP
configuration. The unused AI configuration is excluded from the
generated project.

This keeps the generated repository focused and avoids maintaining two
active AI instruction systems inside the same project.

## Instructions

The AI layer contains project-wide and specialized development guidance
covering areas such as:

-   architecture
-   coding style
-   error handling
-   package management
-   performance
-   security
-   testing
-   agent usage

The instructions define project constraints and conventions while
detailed technical guidance is kept in reusable skills.

## Skills

The template contains reusable skills that can be loaded when relevant
to a development task.

Current areas include:

-   Clean Architecture and project structure
-   modern C# and async programming
-   dependency injection
-   Entity Framework Core
-   configuration
-   error handling
-   logging
-   testing with xUnit, NUnit, and MSTest
-   HTTP client usage and resilience
-   LINQ
-   authentication and security review
-   OpenAPI and Scalar
-   OpenTelemetry and Application Insights
-   caching and messaging
-   SQL review and optimization
-   Docker and container publishing
-   .NET Aspire
-   Azure architecture and deployment
-   cloud design patterns
-   Microsoft documentation and code references

Skills are intended to provide focused technical knowledge without
making the global project instructions unnecessarily large.

## Agents

The template includes specialized agents for focused engineering tasks:

-   Build Error Resolver
-   Code Reviewer
-   C# / .NET Janitor
-   DevOps Engineer
-   .NET Architect
-   EF Core Specialist
-   Performance Analyst
-   Security Auditor
-   Test Engineer

Agents can combine their specialized role with relevant skills and
available MCP tools.

## Roslyn MCP

The generated project is configured to use `DotNet.RoslynMcp`, a
Roslyn-based MCP server for semantic analysis of the loaded .NET
solution.

Instead of relying only on repository-wide text search, an AI coding
agent can use semantic information about the solution to perform more
targeted discovery.

The MCP integration supports areas such as:

-   symbol discovery and source lookup
-   references, callers, implementations, and overrides
-   type hierarchy and file structure
-   project information and dependencies
-   call graphs
-   semantic code search
-   ASP.NET endpoint discovery
-   dependency injection registration discovery

The goal is to reduce unnecessary repository scanning and give AI agents
structured information about the actual .NET code model.

The template also configures the Microsoft Learn MCP server for access
to Microsoft technical documentation.

## Creating a Project

### 1. Install the template locally

From the repository directory:

``` bash
dotnet new install ./template
```

To reinstall a locally modified version:

``` bash
dotnet new uninstall AiDotNet.Template
dotnet new install ./template
```

### 2. Create a project

GitHub Copilot:

``` bash
dotnet new ai-dotnet -n MyProject --ai copilot
```

Claude Code:

``` bash
dotnet new ai-dotnet -n MyProject --ai claude
```

The template uses `AiDotNet` as its source name, so project names,
namespaces, project references, and the solution name are replaced with
the name supplied through `-n`.

## Generated Project Structure

A generated project follows this general structure:

``` text
MyProject/
├── .github/ or AI files for Claude Code
├── .mcp.json
├── src/
│   ├── MyProject.Api/
│   ├── MyProject.Application/
│   ├── MyProject.Domain/
│   └── MyProject.Infrastructure/
├── tests/
│   └── MyProject.ArchitectureTests/
├── Directory.Build.props
├── Directory.Packages.props
├── MyProject.slnx
└── .editorconfig
```

The exact AI-specific files depend on the selected `--ai` option.

## MCP Prerequisite

The Roslyn MCP configuration expects the `dotnet-roslyn-mcp` command to
be available on the machine.

For local development of `DotNet.RoslynMcp`, install its packaged .NET
tool before starting the AI coding client.

The generated MCP configuration automatically points the server at the
generated `.slnx` solution.

## Build and Test

Build the complete solution:

``` bash
dotnet build
```

Run the tests:

``` bash
dotnet test
```

## Included Backend Foundation

The API project is preconfigured with:

-   controllers
-   HTTPS redirection
-   authorization middleware
-   global exception handling
-   Problem Details
-   HTTP logging
-   OpenAPI
-   Scalar
-   OpenTelemetry tracing
-   OpenTelemetry metrics

The Application layer automatically registers FluentValidation
validators from its assembly.

Infrastructure registers the EF Core `AppDbContext`, exposes it through
`IAppDbContext`, and provides `TimeProvider.System` through dependency
injection.

The template deliberately leaves the concrete database provider and
connection setup to the generated application rather than forcing a
persistence technology choice.

## Central Package Management

Package versions are managed centrally through
`Directory.Packages.props`.

Projects reference packages without repeating version numbers, keeping
dependency versions consistent across the solution.

## Design Principles

The template is intentionally opinionated about engineering structure
while remaining flexible about application-specific technology choices.

Its main principles are:

-   preserve Clean Architecture dependency boundaries
-   keep the starting project small and understandable
-   prefer built-in .NET capabilities where appropriate
-   avoid unnecessary abstractions and speculative infrastructure
-   keep AI context concise and task-focused
-   load specialized AI guidance only when relevant
-   use semantic code intelligence where it improves accuracy and
    context efficiency
-   keep infrastructure choices replaceable
-   provide a foundation rather than a prebuilt application

## Requirements

-   .NET 10 SDK
-   GitHub Copilot or Claude Code, depending on the selected template
    mode
-   `DotNet.RoslynMcp` installed as a .NET tool to use Roslyn MCP
    integration

## Template Metadata

-   Template name: `AI-Ready .NET`
-   Template identity: `AiDotNet.Template`
-   Short name: `ai-dotnet`
-   Author: Andor Mihaly
-   Target framework: `net10.0`
