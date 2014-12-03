using System.Data.Entity;

namespace Elmah.Contrib.EntityFramework
{
	public class ElmahContext : DbContext
	{
		private readonly string _tableName;

		public ElmahContext(string nameOrConnectionString)
			: this(nameOrConnectionString, "ELMAH_Error")
		{
		}

		public ElmahContext(string nameOrConnectionString, string tableName)
			: base(nameOrConnectionString)
		{
			_tableName = tableName;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ElmahError>().ToTable(_tableName);

			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<ElmahError> ElmahErrors { get; set; }
	}
}