---
applyTo: "tests/**/*.cs"
---

# Testing

## Test Structure

- **Follow the Arrange-Act-Assert pattern** with clear separation between Arrange, Act, and Assert.
- **Keep each test focused on one behavior or assertion concept.**
- Multiple assertions are acceptable when they validate different aspects of the same result.
- Separate different behaviors into separate tests so failures remain specific and easy to diagnose.

## Naming

- **Use descriptive test names following `MethodName_Scenario_ExpectedResult`.**
- Test names should clearly describe the behavior being verified.

## Test Design

- **Test observable behavior rather than implementation details.**
- **Keep tests independent and deterministic.**
- Avoid tests that depend on execution order or shared mutable state.
- **Do not use arbitrary delays such as `Task.Delay` to make asynchronous tests pass.**
