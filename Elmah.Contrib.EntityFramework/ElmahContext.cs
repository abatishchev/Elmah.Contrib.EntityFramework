using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Elmah.Contrib.EntityFramework
{
	public class ElmahContext : DbContext
	{
		private readonly string _tableName;
		private readonly string _schemaName;

		static ElmahContext()
		{
			Database.SetInitializer(new NullDatabaseInitializer<ElmahContext>());
		}

		public ElmahContext(string nameOrConnectionString)
			: this(nameOrConnectionString, "ELMAH_Error", "dbo")
		{
		}

		public ElmahContext(string nameOrConnectionString, string tableName, string schemaName)
			: base(nameOrConnectionString)
		{
			_tableName = tableName;
			_schemaName = schemaName;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(GetConfiguration());
		}

		protected virtual EntityTypeConfiguration<ElmahError> GetConfiguration()
		{
			return new ElmahErrorConfiguration(_tableName, _schemaName);
		}

		public virtual DbSet<ElmahError> ElmahErrors { get; set; }
	}
}