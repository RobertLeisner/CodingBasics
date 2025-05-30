# Nuget package management

## Consuming nuget packages



## Publishing nuget packages

### Refreshing Nuget API key

Tu publish a Nuget package you need an API key to access Nuget web host.

Login to your Nuget account

Then call an command prompt and run (or create a batch file with that content):

```

donet nuget setapikey your-api-key

```

### Setting up a local nuget package store

With the following command you can add a local (network) path (\\Server\Share\Folder) as your private Nuget package store

```

dotnet nuget add source \\Server\Share\Folder --Name "Name_of_your_source"

```

To publish a package into this store call:

```

dotnet nuget push "your_package.nupkg" --source \\Server\Share\Folder

```

### Prepapring project file for packaging

To prepare your csproj project file for Nuget packaging you have to add certain tags to this file. See an example csproj file for a working setup:

```

<Project Sdk="Microsoft.NET.Sdk">

	<PropertyGroup>
		<TargetFramework>net8</TargetFramework>

		<!--General Nuget packaging-->
		<GenerateAssemblyInfo>true</GenerateAssemblyInfo>
		<Deterministic>False</Deterministic>
		<PackageLicenseExpression>MIT</PackageLicenseExpression>
		<PackageOutputPath>..\..\Nuget\</PackageOutputPath>
		<Copyright>Bodoconsult EDV-Dienstleistungen GmbH</Copyright>
		<Authors>Robert Leisner</Authors>
		<Company>Bodoconsult EDV-Dienstleistungen GmbH</Company>
		<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
		<RepositoryType>git</RepositoryType>
		<NeutralLanguage>en</NeutralLanguage>
		<PackageReadmeFile>README.md</PackageReadmeFile>

		<!--Package specific-->
		<VersionPrefix>1.0.0</VersionPrefix>
		<Version />
		<RepositoryUrl>https://github.com/RobertLeisner/Bodoconsult.Database</RepositoryUrl>
		<PackageId>Bodoconsult.Database.Sqlite</PackageId>
		<PackageTags>System.Data Datatable SQL exec Sqlite DataReader</PackageTags>
		<Description>Simple .NET database layer for Sqlite based on System.Data intended for mainly read-only data access i.e. for reporting purposes or similar read-only data access</Description>
		<PackageReleaseNotes>Migration to .Net 8 and new namespace</PackageReleaseNotes>
		<PackageProjectUrl>https://github.com/RobertLeisner/Bodoconsult.Database</PackageProjectUrl>

		<IncludeSymbols>true</IncludeSymbols>
		<SymbolPackageFormat>snupkg</SymbolPackageFormat>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Microsoft.Data.Sqlite" Version="9.0.0" />
	</ItemGroup>

	<ItemGroup>
		<None Include="..\LICENSE.md" Link="LICENSE.md" />
		<None Include="..\README.md" Link="README.md" Pack="true" PackagePath="\" />
	</ItemGroup>

	<ItemGroup>
		<ProjectReference Include="..\Bodoconsult.Database\Bodoconsult.Database.csproj" />
	</ItemGroup>

</Project>

```



### Publishing to Nuget website

Create a batch file in the solution folder to publish a package to Nuget website.

```

REM Adjust version as needed

set version=1.0.0

REM Add a path if needed

dotnet nuget push Bodoconsult.Typography.%version%.nupkg --source https://api.nuget.org/v3/index.json

```

### Assembly and package versioning

https://andrewlock.net/version-vs-versionsuffix-vs-packageversion-what-do-they-all-mean/
