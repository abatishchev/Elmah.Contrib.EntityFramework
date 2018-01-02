[![NuGet](https://img.shields.io/nuget/v/Elmah.Contrib.EntityFramework.svg)](https://www.nuget.org/packages/Elmah.Contrib.EntityFramework)

Elmah.Contrib.EntityFramework
===

Provides the way to integrate [Elmah](http://code.google.com/p/elmah/) with [Microsoft ADO.NET Entity Framework](http://entityframework.codeplex.com/). Initially written in F# but then rewritten in C#.

Description
===

You may want not to keep in Web.config both connection strings for Entity Framework (used by your project) and for SQL Server (used by Elmah.SqlServer) duplicating each other.
The goal of this library is to extract the underlying provider connection string from the EF connection string so only one will be kept in Web.config.

Also you can query Elmah errors table using LINQ to Entities having strongly-typed POCO entities.

Comments and contributions are very welcome!

Examples
===
With Model/Database First approach:
```xml
<configuration>
	<connectionStrings>
		<add name="ModelContainer" connectionString="metadata=res://*/;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True;&quot;" providerName="System.Data.EntityClient" />
	</connectionStrings>
	<elmah>
		<errorLog type="Elmah.Contrib.EntityFramework.EntityErrorLog, Elmah.Contrib.EntityFramework" connectionStringName="ModelContainer" />
	</elmah>
</configuration>
```

With Code First approach. To query for existing errors:
```csharp
var elmahContext = new ElmahContext(nameOrConnectionString);
var errors = await elmahContext.Errors.ToArrayAsync();
```

You can also optionally specify the table name to map:
```csharp
var elmahContext = new ElmahContext(nameOrConnectionString, tableName: "MyElmahErrorsTable");
```

Or the schema name, or both:
```csharp
var elmahContext = new ElmahContext(nameOrConnectionString, schemaName: "audit");
```

To add new error:
```csharp
elmahContext.Errors.Add(
	new ElmahError
	{
	});
await elmahContext.SaveChangesAsync();
```

Remarks
===

With the same connection string, you can use either `EntityErrorLog` (requires `providerName="System.Data.EntityClient"`) or `EntityContext` (requires `providerName="System.Data.SqlClient"`) but not both.

Release notes
===

1.4.0:

[~] Fixed table mapping, now it's `public DbSet<ElmahError> ElmahErrors { get; set; }`

[~] Moved mapping to the separate class inheriting `EntityTypeConfiguration<T>`

[~] Set database initializer to null

[+] Added to ElmahContext ctor accepting schema name

1.3.0:

[+] Added to ElmahContext ctor accepting table name

1.2.2:

[+] Added the support for MySQL

1.1.1:

[+] Added to EntityErrorLog ctor accepting String

1.1.0:

[~] Rewritten in C# to do not require the F# runtime, unfortunately

1.0.3:

[+] Added to ElmahError ctors accepting Elmah.Error or System.Exception respectively

1.0.2:

[+] Added EF Code First DB context to query database using LINQ to Entities

1.0.1:

[+] Added EntityErrorLog to re-use EF connection string

Legal
===

Licensed under the [MIT License](http://opensource.org/licenses/MIT)

Copyright © [Alexander Batishchev](http://abatishchev.ru) 2014-2018
