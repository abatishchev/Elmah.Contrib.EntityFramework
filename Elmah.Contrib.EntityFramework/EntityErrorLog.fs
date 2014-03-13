namespace Elmah.Contrib.EntityFramework

open System.Data.Entity.Core.EntityClient

open Elmah

[<Sealed>]
type public EntityErrorLog(config : System.Collections.IDictionary) = 
    inherit SqlErrorLog(config)

    override this.ConnectionString
        with get() = this.GetProviderPart(base.ConnectionString)

    member private this.GetProviderPart(connectionString : string) =
        let builder = new EntityConnectionStringBuilder(connectionString)
        builder.ProviderConnectionString