using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elmah.Contrib.EntityFramework.Test
{
	[TestClass]
	public class EntityErrorLogTest
	{
		[TestMethod]
		public void ConnectionString_Should_Return_Provider_Part_When_Dictionary_Passed_To_Ctor()
		{
			// Arrange
			const string providerConectionString = "Data Source=localhost;Initial Catalog=Northwind;Password=Alpine";
			string entityConectionString = String.Format("metadata=res://*/;provider=System.Data.SqlClient;provider connection string=\"{0}\";", providerConectionString);

			var config = new System.Collections.Generic.Dictionary<string, string>();
			config["connectionString"] = entityConectionString;

			// Act
			var entityErrorLog = new EntityErrorLog(config);

			// Assert
			entityErrorLog.ConnectionString.Should().Be(providerConectionString);
		}

		[TestMethod]
		public void ConnectionString_Should_Return_Provider_Part_When_String_Passed_To_Ctor()
		{
			// Arrange
			const string providerConectionString = "Data Source=localhost;Initial Catalog=Northwind;Password=Alpine";
			string entityConectionString = String.Format("metadata=res://*/;provider=System.Data.SqlClient;provider connection string=\"{0}\";", providerConectionString);

			// Act
			var entityErrorLog = new EntityErrorLog(entityConectionString);

			// Assert
			entityErrorLog.ConnectionString.Should().Be(providerConectionString);
		}
	}
}