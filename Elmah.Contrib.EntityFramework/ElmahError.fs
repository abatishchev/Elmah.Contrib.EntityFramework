namespace Elmah.Contrib.EntityFramework

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open System.Data.Entity

open Elmah

[<Table("ELMAH_Error")>] 
type public ElmahError() = class

    new (ex : Exception ) = ElmahError(new Error(ex))

    new (error : Error) as this = ElmahError() then
        this.ErrorId <- Guid.NewGuid();

        this.Application <- match error.ApplicationName with
            | null -> ""
            | _ -> error.ApplicationName

        this.Host <- match error.HostName with
            | null -> ""
            | _ -> error.HostName
        
        this.Type <- match error.Type with
            | null -> ""
            | _ -> error.Type
        
        this.Source <- match error.Source with
            | null -> ""
            | _ -> error.Source
        
        this.Message <- match error.Message with
            | null -> ""
            | _ -> error.Message
        
        this.User <- match error.User with
            | null -> ""
            | _ -> error.User
        
        this.TimeUtc <- error.Time;
        
        let xml = ErrorXml.EncodeString(error);
        this.AllXml <- xml;

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