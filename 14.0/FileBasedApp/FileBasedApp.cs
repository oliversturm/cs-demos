// File-based apps are new in C# 14 / .NET 10. This file can be run
// directly without a .csproj:
//
//   dotnet run FileBasedApp.cs
//
// The #: directives below are preprocessor directives specific to
// file-based apps. They replace the role of the .csproj file.

// Add a NuGet package reference:
#:package Humanizer@2.*

using Humanizer;

// File-based apps use top-level statements (no Main method needed,
// no namespace, no class).

Console.WriteLine("File-based C# app running!");

// Using the Humanizer package referenced above
Console.WriteLine($"3501 in words: {3501.ToWords()}");
Console.WriteLine($"DateTime.Now humanized: {DateTime.Now.AddHours(-3).Humanize()}");

var items = new[] { "apple", "banana", "cherry" };
Console.WriteLine($"Fruit list: {items.Humanize()}");

// This file has no .csproj -- it IS the entire application.
// The .NET 10 SDK compiles and runs it directly, putting C# on
// par with Python and JavaScript for quick scripting tasks.
