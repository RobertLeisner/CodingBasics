# Developer productivity

## Windows batch scripts

A batch script for windows is a plain text file with the exntsion bat.

You can use a batch file to automate workflow process like Nuget deployment etc.

https://steve-jansen.github.io/guides/windows-batch-scripting/part-2-variables.html



## Code snippets for Visual Studio (VS)

Code snippets are are productivity tool for the developer allowing him to insert prefined textblocks with a hotkey.

### Snippet example

```

<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
		<Header>
			<Title>xtdd</Title>
			<Author>Robert Leisner</Author>
			<Description>Create a test method</Description>
			<Shortcut>xtdd</Shortcut>
			<SnippetTypes>
				<SnippetType>Expansion</SnippetType>
			</SnippetTypes>
		</Header>
		<Snippet>
		  <Code Language="CSharp">
				<![CDATA[[Test]
        public void Test()
        {
            // Arrange 


            // Act  


            // Assert


        }
				]]>
		  </Code>

			</Snippet>
      </CodeSnippet>
</CodeSnippets>

```


###  Import a code snippet (Version 1)

Use copy.bat in R:\10_Entwicklung\01_SMDTower-DEV\03_StSys\Tools\Snippets to copy the snippets in this folder 
to your local snippet folder. After the next restart of VS the snippets can be used.

### Import a code snippet (Version 2)


You can import a snippet to your Visual Studio installation by using the Code Snippets Manager. Open it by choosing Tools > Code Snippets Manager.

-	Click the Import button.

-	Go to the location where you saved the code snippet in the previous procedure, select it, and click Open.

-	The Import Code Snippet dialog opens, asking you to choose where to add the snippet from the choices in the right pane. One of the choices should be My Code Snippets. Select it and click Finish, then OK.

-	The snippet is copied to one of the following locations, depending on the code language: %USERPROFILE%\Documents\Visual Studio 2019\Code Snippets\Visual C#\My Code Snippets

Test your snippet by opening a C# or Visual Basic project. With a code file open in the editor, choose Snippets > Insert Snippet from the right-click menu, then My Code Snippets. You should see a snippet named Square Root. Double-click it.
The snippet code is inserted in the code file.

### Run snippets

Write the name of the snippet then press TAB. The snippet code should be inserted.

For a list of all snippets pres Ctrl+K, Ctrl+X


## Windows hacks

### Restore the old, full Context Menu in Windows 11

Right-click the Start button and choose Windows Terminal.

Copy the command from below, paste it into Windows Terminal Window, and press enter.

```

reg.exe add "HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32" /f /ve

```

Restart your computer for the changes to take effect.

You would see the Legacy Right Click Context menu by default.

## C# hacks

### Solution wide AssemblyInfo.cs

Prefer to NOT use AssemblyInfo.cs in .NET 8 projects. Place the information in csproj file instead as recommend by Microsoft. This helps i.e. making Nuget package publishing easier.

https://asp-blogs.azurewebsites.net/ashishnjain/sharing-assembly-version-across-projects-in-a-solution

