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
[<assembly: AssemblyConfiguration("Release")>]
#endif

[<assembly: Guid("e230d669-a728-4792-9bf4-917aae70e103")>]

[<assembly: AssemblyVersion("1.0.0.0")>]
[<assembly: AssemblyFileVersion("1.0.0.0")>]
[<assembly: AssemblyInformationalVersion("1.0.1.0")>]

do()