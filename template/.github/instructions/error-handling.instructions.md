---
applyTo: "src/**/*.cs"
---

# Error Handling

## HTTP Errors

- **Use ProblemDetails for HTTP error responses.** Keep error responses consistent and machine-readable.
- **Do not return bare strings or ad-hoc error objects from API endpoints.**

## Exception Handling

- **Handle unhandled exceptions at the application boundary using centralized exception handling.**
- **Do not catch `Exception` in application code unless operating at an appropriate top-level boundary.**
- **Do not catch and rethrow exceptions without adding meaningful context or handling.**
- **Let unexpected exceptions propagate to the centralized exception handler rather than swallowing them.**

## Boundary Validation

- **Validate untrusted data at system boundaries**, including API input, external service responses, file input, and configuration.
- **Avoid redundant validation deep inside internal implementation code when the input has already been validated at the boundary.**
