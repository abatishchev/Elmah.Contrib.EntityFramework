namespace Elmah.Contrib.EntityFramework

open System.Configuration
open System.Data.Entity.Core.EntityClient

open Elmah

type public EntityErrorLog = 
    inherit SqlErrorLog

    val private _connectionStringName : string

    new (config : System.Collections.IDictionary) = {
            inherit SqlErrorLog(config)

            // config is a non-generic dictionary thus casting to string is required
            _connectionStringName = config.Item("connectionStringName") :?> string
        }

    override this.ConnectionString
        with get() = this.GetProviderPart(this._connectionStringName)

    member private this.GetProviderPart(connectionStringName : string) =
        let entityConnectionString = ConfigurationManager.ConnectionStrings.Item(connectionStringName).ConnectionString;
        let builder = new EntityConnectionStringBuilder(entityConnectionString)
        builder.ProviderConnectionString