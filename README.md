Elmah.Contrib.EntityFramework
===

Provides Elmah.ErrorLog implementation for Microsoft Entity Framework written in F#

Downloads
===
Avaliable on [NuGet](https://www.nuget.org/packages/Elmah.Contrib.EntityFramework)

Example
===
<configuration>
	<connectionStrings>
		<add name="ModelContainer" connectionString="metadata=res://*/;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True;&quot;" providerName="System.Data.EntityClient" />
	</connectionStrings>
	<elmah>
		<errorLog type="Elmah.Contrib.EntityFramework.EntityErrorLog, Elmah.Contrib.EntityFramework" connectionStringName="ModelContainer" />
	</elmah>
</configuration>

Legal
===

Licensed under the [MIT License](http://opensource.org/licenses/MIT)

Copyright © [Alexander Batishchev](http://abatishchev.ru) 2014 