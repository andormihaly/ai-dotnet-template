# Security

## Secrets

- **Never hardcode secrets in source code.** Secrets must be stored and accessed through secure configuration sources.
- **Prefer Azure Key Vault for secrets in both local development and deployed environments.**
- **For local development, prefer Azure CLI authentication (`az login`) with `DefaultAzureCredential` to access Azure Key Vault.** Avoid storing Azure credentials locally when developer identity can be used instead.
- **For deployed Azure environments, prefer Managed Identity for accessing Azure Key Vault.** Avoid client secrets when workload identity can be used.
- **Never commit secrets or credential files.** Files containing real credentials, tokens, connection strings, or other sensitive values must not be committed to source control.

## Input Validation

- **Validate all external input at system boundaries.** API endpoints, message handlers, file uploads, and other external inputs are trust boundaries. Validate input before it reaches application or domain logic.
- **Use parameterized queries.** Never construct SQL queries by concatenating untrusted input.

## Authentication and Authorization

- **Make authorization intent explicit on every controller or endpoint.** Use `[Authorize]` or `[AllowAnonymous]` rather than relying on ambiguous authentication behavior.
- **Use explicit CORS origins in production.** Never use unrestricted origins such as `AllowAnyOrigin()` in production.

## Logging

- **Do not log secrets, credentials, access tokens, refresh tokens, API keys, or other sensitive authentication data.**
- **Avoid logging PII.** Only log personal data when there is a concrete operational requirement and appropriate protection is in place.
