namespace FinalProjectCSharpTrybe.Context
{
    using FinalProjectCSharpTrybe.Models;
    using Microsoft.EntityFrameworkCore;

    public class SQLServerContext: DbContext, IContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Post>? Posts { get; set; }

        public SQLServerContext(DbContextOptions<SQLServerContext> options): base(options)
        { }
        public SQLServerContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var DbServer = Environment.GetEnvironmentVariable("DbServer") ?? "127.0.0.1";
                var DbPort = Environment.GetEnvironmentVariable("DbPort") ?? "1433";
                var Database = Environment.GetEnvironmentVariable("Database") ?? "Tryitter";
                var DbUser = Environment.GetEnvironmentVariable("DbUser") ?? "SA";
                var DbPassword = Environment.GetEnvironmentVariable("Password") ?? "database#2022";
                                
                optionsBuilder.UseSqlServer(@$"
                    Server={DbServer};
                    Database={Database};
                    User={DbUser};
                    Password={DbPassword};
                    TrustServerCertificate=True;
                ");
            }
        }

    }
}