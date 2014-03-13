namespace Elmah.Contrib.EntityFramework

open System
open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

[<assembly: AssemblyTitle("Elmah.Contrib.EntityFramework")>]
[<assembly: AssemblyProduct("Elmah.Contrib.EntityFramework")>]

[<assembly: AssemblyCopyright("Copyright © Alexander Batishchev 2014")>]

[<assembly: ComVisible(false)>]
[<assembly: CLSCompliant(true)>]

#if DEBUG
[<assembly: AssemblyConfiguration("Debug")>]
#else
[<ssembly: AssemblyConfiguration("Release")>]
#endif

[<assembly: Guid("E230D669-A728-4792-9BF4-917AAE70E103")>]

[<assembly: AssemblyVersion("1.0.0.0")>]
[<assembly: AssemblyFileVersion("1.0.0.0")>]

do()