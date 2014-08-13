namespace Elmah.Contrib.EntityFramework

open System.Data.Entity

type public ElmahContext (nameOrConnectionString : string) =
    inherit DbContext (nameOrConnectionString)
   
    override this.OnModelCreating(modelBuilder : DbModelBuilder) =
        modelBuilder.Entity<ElmahError>().ToTable("ELMAH_Error") |> ignore
        
        base.OnModelCreating(modelBuilder)

    [<DefaultValue>]
    val mutable _errors : DbSet<ElmahError>
    
    member public this.Errors
        with get() = this._errors 
        and set(v) = this._errors <- v
