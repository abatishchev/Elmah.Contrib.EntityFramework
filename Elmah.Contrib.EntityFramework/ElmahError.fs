namespace Elmah.Contrib.EntityFramework

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open System.Data.Entity

open Elmah

[<Table("ELMAH_Error")>] 
type public ElmahError() =

    let mutable _errorId = Guid.Empty
    let mutable _application = ""
    let mutable _host = ""
    let mutable _type= ""
    let mutable _source= ""
    let mutable _message= ""
    let mutable _user= ""
    let mutable _statusCode = 0
    let mutable _timeUtc = DateTime.UtcNow
    let mutable _sequence = 0
    let mutable _allXml = ""

    new (ex : Exception ) = ElmahError(new Error(ex))

    new (error : Error) as this = ElmahError() then
        this.ErrorId <- Guid.NewGuid();
        this.Application <- error.ApplicationName
        this.Host <- error.HostName
        this.Type <- error.Type
        this.Source <- error.Source
        this.Message <- error.Message
        this.User <- error.User
        this.TimeUtc <- error.Time
        
        this.AllXml <- ErrorXml.EncodeString(error)

    [<Key>]
    member this.ErrorId
        with get() = _errorId
        and set(value) = _errorId <- value

    [<Required>]
    [<StringLength(60)>]
    member this.Application
        with get() = _application
        and set(value) = _application <- value

    [<Required>]
    [<StringLength(50)>]
    member this.Host
        with get() = _host
        and set(value) = _host <- value

    [<Required>]
    [<StringLength(100)>]
    member this.Type
        with get() = _type
        and set(value) = _type <- value

    [<Required>]
    [<StringLength(60)>]
    member this.Source
        with get() = _source
        and set(value) = _source <- value

    [<Required>]
    [<StringLength(500)>]
    member this.Message
        with get() = _message
        and set(value) = _message <- value

    [<Required>]
    [<StringLength(50)>]
    member this.User
        with get() = _user
        and set(value) = _user <- value

    [<Required>]
    member this.StatusCode
        with get() = _statusCode
        and set(value) = _statusCode <- value

    [<Required>]
    member this.TimeUtc
        with get() = _timeUtc
        and set(value) = _timeUtc <- value

    [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    member this.Sequence
        with get() = _sequence
        and set(value) = _sequence <- value

    [<Required>]
    [<Column(TypeName = "ntext")>]
    member this.AllXml
        with get() = _allXml
        and set(value) = _allXml <- value
