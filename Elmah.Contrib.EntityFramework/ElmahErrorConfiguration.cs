using System.Data.Entity.ModelConfiguration;

namespace Elmah.Contrib.EntityFramework
{
	public class ElmahErrorConfiguration : EntityTypeConfiguration<ElmahError>
	{
		public ElmahErrorConfiguration(string tableName, string schemaName)
		{
			ToTable(tableName, schemaName);
		}
	}
}