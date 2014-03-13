namespace Elmah.Contrib.EntityFramework

open Elmah

type public EntityErrorLog(config : System.Collections.IDictionary) = 
    inherit SqlErrorLog(config)

    override this.ConnectionString
        with get() = "F#"
