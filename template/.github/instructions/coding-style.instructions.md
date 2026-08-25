---
applyTo: "**/*.cs"
---

# C# Coding Style

## File and Member Organization

- **One type per file.** The file name must match the type name exactly.
- **Order members consistently:** constants, fields, constructors, properties, public methods, private methods.

## Types and Design

- **Use primary constructors for dependency injection.**
- **Use records for DTOs and value objects.**
- **Seal classes that are not designed for inheritance.**
- **Prefer `internal` by default and use `public` only when required.** Keep the public API surface minimal.

## Expressions and Patterns

- **Prefer pattern matching over complex if-else chains** when it improves readability.

## Async

- **Use the `Async` suffix for asynchronous methods** returning `Task` or `ValueTask`.

## Naming

- **Use PascalCase** for types, namespaces, methods, properties, and public members.
- **Use camelCase** for local variables and parameters.
