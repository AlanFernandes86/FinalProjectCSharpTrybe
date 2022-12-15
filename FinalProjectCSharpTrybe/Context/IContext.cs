using Microsoft.EntityFrameworkCore;
using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Context
{
    public interface IContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Post>? Posts { get; set; }

        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
