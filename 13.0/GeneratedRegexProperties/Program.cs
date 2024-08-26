using System.Text.RegularExpressions;

public static partial class Program {
  [GeneratedRegex(@"[abc]+")]
  private static partial Regex MyRegex();

  // Since C# 13, partial properties are supported, and
  // they can be used for generated regexes.
  [GeneratedRegex(@"[abc]+")]
  private static partial Regex MyRegexProperty { get; }

  public static void Main(string[] args) {
    Console.WriteLine("Hello World!");
  }
}