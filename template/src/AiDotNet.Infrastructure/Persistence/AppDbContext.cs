using Microsoft.EntityFrameworkCore;

namespace AiDotNet.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
