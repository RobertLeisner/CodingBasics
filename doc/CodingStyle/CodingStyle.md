
Coding style
==============

# Industry standards for C#

Microsoft recommendations for C# coding style conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

Microsoft CoreFX recommendations for C# coding style conventions: https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md

## Basics

-   Use managed wrapper for native code implementations: reduce the usage of native code by wrapping it

-   Use Pascal case for naming a class, struct, method, property, or constant field: MyProperty

-   Use Camel case for naming method arguments, private fields, and local variables: _myField

-   Use && instead of & and || instead of | for comparisons

-   Use enums for discrete values but not in libraries used in multiple projects. In this case use class based implementations with defined static instances.

-	Only one class or enum per file: makes searching in project explorer easier and the code more easy to read.

-	Every class have to have only one purpose: makes code more clear, easier to test and easier to read for others

-	Every method have have only one purpose: makes code more clear, easier to test and easier to read for others

-	10 lines per method: makes code more clear, easier to test and easier to read for others

-	Before using input parameters check if they are null and handle this case in a senseful manner: espacially in multithreaded environments null exceptions are hard to debug and good coding should avoid them as much as possible

-   Do not write multiple commands in one line

Bad

```
	if (isNotAllowed) return;

```

Good

```
	if (isNotAllowed) 
	{
		return;
	}
```

-	Use indentation to make code more readable (let you help by Resharper with command CTRL+K+D)

-	Use blank lines to create code blocks to make code better understandable

-	Add a comment to a block of code lines to make code better understandable



## Documentation

-	Use the \\\ shortcut in Visual Studio to document methods and properties: before the first line of a method write \\\ and Visual Studio creates a comment block for you. Fill all requested information

-	If injecting dependencies leads to circle references in DI container use for each dependency causing a circle reference method injection with a separate method for each of these dependencies.

-	All public methods and properties have to be documented

-	Document interfaces first then use Resharper "Copy comment from base" to copy the comment to derived classes

-	Private methods have to be documented if they are important and not simple


## Class design

-	Inject all dependencies of a class via ctor

-	Do NOT create dependencies in the ctor or allocate them with service allocator style calls

-	Basically make dependencies inject via ctor public as readonly field (not as get-only property)

-	If you need such a dependency included in an interface use a get-only property instead of readonly field


## Unit tests

-	Use test driven design (TDD): develop a test first, let it fail and then the code to make it work


## Rules for special implementations

### Factories

The main method of a XXX factory should be named CreateInstance, return a XXX instance and have only specific parameters needed to build the concrete instance of XXX. 

General dependencies should be injected via ctor of XXX factory class. The XXX instance create by the factory can get them injected via its ctor in the CreateInstance method.


## Naming conventions

XXXDto  For DTO (data transfer objects)

XXXManager	Business logic layer for XXX. Other postfixes like Provider, Logger etc may be helpful for subordinated business logic classes

XXXService Database and database technology specific services for XXX, i.e. SqlServer specific implementation

XXXFactory	Factory for XXX instances

XXXFactoryFactory Factory for XXX factories

