Elmah.Contrib.EntityFramework
===

Provides Elmah.ErrorLog implementation for Microsoft Entity Framework written in F#

Description
===

You may want not to keep in Web.config both connection strings for Entity Framework (used by your project) and for SQL Server (used by Elmah) duplicating each other.
So the goal of this small library is to extract the underlying SQL Server connection string for the EF connection string only specified in Web.config.

Downloads
===
Avaliable on [NuGet](https://www.nuget.org/packages/Elmah.Contrib.EntityFramework)

Example
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