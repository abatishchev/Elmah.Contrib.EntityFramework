Elmah.Contrib.EntityFramework
===

Provides the way to integrate [Elmah](http://code.google.com/p/elmah/) with [Microsoft ADO.NET Entity Framework](http://entityframework.codeplex.com/). Written in F#.

Description
===

You may want not to keep in Web.config both connection strings for Entity Framework (used by your project) and for SQL Server (used by Elmah.SqlServer) duplicating each other.
The goal of this library is to extract the underlying provider connection string from the EF connection string so only one will be kept in Web.config.

Also you can query Elmah errors table using LINQ to Entities having strongly-typed POCO entities.

Comments and contributions are very welcomed!

Remarks
===

You can use either `EntityErrorLog` (requires `providerName="System.Data.EntityClient"`) or `EntityContext` (requires `providerName="System.Data.SqlClient"`) but not both simultaneously.

Downloads
===
Available on [NuGet](https://www.nuget.org/packages/Elmah.Contrib.EntityFramework)

Release notes
===

1.1.0
[~] Rewritten in C# to do not require the F# runtime, unfortunately

1.0.3:
[+] Adding to ElmahError constructors accepting Elmah.Error or System.Exception

1.0.2:
[+] Added EF Code First DB context to query database using LINQ to Entities

1.0.1:
[+] Added EntityErrorLog to re-use EF connection string

Examples
===
```
<configuration>
	<connectionStrings>
		<add name="ModelContainer" connectionString="metadata=res://*/;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True;&quot;" providerName="System.Data.EntityClient" />
	</connectionStrings>
	<elmah>
		<errorLog type="Elmah.Contrib.EntityFramework.EntityErrorLog, Elmah.Contrib.EntityFramework" connectionStringName="ModelContainer" />
	</elmah>
</configuration>
```

Legal
===

Licensed under the [MIT License](http://opensource.org/licenses/MIT)

Copyright © [Alexander Batishchev](http://abatishchev.ru) 2014

