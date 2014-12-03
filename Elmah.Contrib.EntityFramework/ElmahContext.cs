using System.Data.Entity;

namespace Elmah.Contrib.EntityFramework
{
	public class ElmahContext : DbContext
	{
		private readonly string _tableName;

		static ElmahContext()
		{
			Database.SetInitializer(new NullDatabaseInitializer<ElmahContext>());
		}

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
			modelBuilder.Configurations.Add(GetConfiguration());
		}

		protected virtual EntityTypeConfiguration<ElmahError> GetConfiguration()
		{
			return new ElmahErrorConfiguration(_tableName);
		}

		public virtual DbSet<ElmahError> ElmahErrors { get; set; }
	}
}