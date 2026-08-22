# Architecture

## Project Dependencies

- `Domain` must not reference any other project.
- `Application` may reference only `Domain`.
- `Infrastructure` may reference only `Application`.
- `Api` may reference `Application` and `Infrastructure`.
- Do not introduce project references that violate these dependency boundaries.

## Layer Responsibilities

- `Domain` contains domain models and core business rules. It must not contain infrastructure or framework-specific concerns.
- `Application` contains application logic, use cases, interfaces, and application-level configuration.
- `Infrastructure` contains implementations for persistence, external services, and other infrastructure concerns.
- `Api` is the application entry point and composition root. Keep business logic out of controllers.

## Persistence

- **Do not introduce a generic repository pattern over EF Core.** Use `DbContext` directly unless a concrete use case justifies an additional abstraction.
