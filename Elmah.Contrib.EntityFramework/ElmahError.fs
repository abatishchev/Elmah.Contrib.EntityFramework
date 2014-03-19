namespace Elmah.Contrib.EntityFramework

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open System.Data.Entity

[<Table("ELMAH_Error")>] 
type public ElmahError() = class
    
    [<Key>]
    member val ErrorId = Guid.Empty with get, set

    [<Required>]
    [<StringLength(60)>]
    member val Application = "" with get, set

    [<Required>]
    [<StringLength(50)>]
    member val Host = "" with get, set

    [<Required>]
    [<StringLength(100)>]
    member val Type = "" with get, set

    [<Required>]
    [<StringLength(60)>]
    member val Source = "" with get, set

    [<Required>]
    [<StringLength(500)>]
    member val Message = "" with get, set

    [<Required>]
    [<StringLength(50)>]
    member val User = "" with get, set

    [<Required>]
    member val StatusCode = 0 with get, set

    [<Required>]
    member val TimeUtc = DateTime.UtcNow with get, set

    [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    member val Sequence = 0 with get, set

    [<Column(TypeName = "ntext")>]
    [<Required>]
    member val AllXml = "" with get, set
end