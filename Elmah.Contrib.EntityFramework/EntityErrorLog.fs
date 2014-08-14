namespace Elmah.Contrib.EntityFramework

open System.Data.Entity.Core.EntityClient

open Elmah

[<Sealed>]
type public EntityErrorLog(config : System.Collections.IDictionary) = 
    inherit SqlErrorLog(config)

    override this.ConnectionString
        with get() =
            let builder = new EntityConnectionStringBuilder(base.ConnectionString)
            builder.ProviderConnectionString
