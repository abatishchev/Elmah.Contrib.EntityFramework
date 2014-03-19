namespace Elmah.Contrib.EntityFramework

open System.Data.Entity

type public ElmahContext(nameOrConnectionString : string) =
    inherit DbContext(nameOrConnectionString)
