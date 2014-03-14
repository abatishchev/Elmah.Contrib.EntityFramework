param
(
	[string]$version = "1.0.1.0",
	[string]$configuration = "Release",
	[string]$target = "Pack"
)

$project = "Elmah.Contrib.EntityFramework\Elmah.Contrib.EntityFramework.fsproj"

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe $project /m /t:$target /p:Configuration=$configuration /p:Version=$version