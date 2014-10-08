using System.Data.Entity.Core.EntityClient;

namespace Elmah.Contrib.EntityFramework
{
	public class EntityErrorLog : SqlErrorLog
	{
		public EntityErrorLog(string connectionString)
			: base(connectionString)
		{
		}

		public EntityErrorLog(System.Collections.IDictionary config)
			: base(config)
		{
		}

		public override string ConnectionString
		{
			get
			{
				var builder = new EntityConnectionStringBuilder(base.ConnectionString);
				return builder.ProviderConnectionString;
			}
		}
	}
}