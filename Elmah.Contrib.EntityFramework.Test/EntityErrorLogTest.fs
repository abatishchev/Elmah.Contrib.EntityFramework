namespace Elmah.Contrib.EntityFramework.Test

open Elmah.Contrib.EntityFramework

open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type JsonBlobNameResolverTest() =
    [<TestMethod>]
    member this.ConnectionString_Should_Return_Provider_Part_From_Connection_String() =

        // Arrange
        let providerConectionString = "Data Source=localhost;Initial Catalog=Northwind"
        let entityConectionString = sprintf "metadata=res://*/;provider=System.Data.SqlClient;provider connection string=\"%s\";" providerConectionString

        let config = new System.Collections.Generic.Dictionary<string,string>()
        config.["connectionString"] <- entityConectionString
        
        // Act
        let entityErrorLog = new EntityErrorLog(config)

        // Assert
        Assert.AreEqual(entityErrorLog.ConnectionString, providerConectionString)
