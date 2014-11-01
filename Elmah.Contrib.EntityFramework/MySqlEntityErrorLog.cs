using System.Data.Entity.Core.EntityClient;

namespace Elmah.Contrib.EntityFramework
{
	public class MySqlEntityErrorLog : MySqlErrorLog
	{
		public MySqlEntityErrorLog(string connectionString)
			: base(connectionString)
		{
		}

		public MySqlEntityErrorLog(System.Collections.IDictionary config)
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