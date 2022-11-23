// See https://aka.ms/new-console-template for more information

// Top-level statements -- new C# 9 feature used in the default templates.
// Useful for app startup sequences without boilerplate code.

Console.WriteLine("Hello, World!");

// However, the docs suggest that top-level statements are useful for teaching
// materials. In reality I don't usually use them because of limitations.
// For instance, you can't do the following without running into trouble -- check
// much further down where this type ends up.

// class MyType {}

var x = new MyType();
Console.WriteLine(x == null);

// There's access to any command line arguments that may have been passed:
Console.WriteLine($"Number of args: {args.Count()}");

// If we await something, `async` is automatically applied to the generated 
// "main" method, and Task returned (or in this case Task<int>, see below).
await Task.Delay(2000);

// We can even return stuff from "main", manually do "dotnet run" to see 
// the return code (assuming your shell displays it).
return 42;

Console.WriteLine("This is unreachable.");

// Compiler wants me to have the type declared *behind* the place where 
// I use it (and behind any other statements, for that matter). That's 
// seriously weird for teaching materials in particular.
class MyType { }

