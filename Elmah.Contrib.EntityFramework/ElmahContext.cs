using System.Data.Entity;

namespace Elmah.Contrib.EntityFramework
{
    public class ElmahContext : DbContext
    {
        public ElmahContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElmahError>().ToTable("ELMAH_Error");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ElmahError> Errors { get; set; }
    }
}