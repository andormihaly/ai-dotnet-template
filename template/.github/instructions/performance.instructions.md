---
applyTo: "src/**/*.cs"
---

# Performance

## Async Patterns

- **Always propagate `CancellationToken` through the call chain.** Dropped tokens mean cancelled requests continue consuming server resources.
- **Async all the way — no `.Result` or `.Wait()`.** Avoid sync-over-async patterns.
- **Prefer `TimeProvider` over `DateTime.Now` / `DateTime.UtcNow`.** `TimeProvider` is injectable and testable, while direct static time access makes time-sensitive logic harder to test.

## Resource Management

- **Use `IHttpClientFactory` instead of directly creating `HttpClient` instances.** The factory manages handler lifetimes, connection pooling, and DNS changes.

## Caching

- **Prefer `HybridCache` over directly using `IMemoryCache` or `IDistributedCache` when application caching is required.** `HybridCache` provides a unified caching abstraction with stampede protection and support for multi-level caching.

## High-Throughput Code

- **Consider `ValueTask<T>` for high-throughput paths that frequently complete synchronously.** Prefer `Task<T>` for general-purpose asynchronous code where the allocation benefit does not justify the additional complexity.
