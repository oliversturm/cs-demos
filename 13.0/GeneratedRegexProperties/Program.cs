using System.Text.RegularExpressions;

public static partial class Program {
  [GeneratedRegex(@"[abc]+")]
  private static partial Regex MyRegex();

  // Since C# 13, partial properties are supported, and
  // they can be used for generated regexes.
  [GeneratedRegex(@"[abc]+")]
  private static partial Regex MyRegexProperty { get; }

  public static void Main(string[] args) {
    string testString = "Wer weiss, dass er nichts weiss...";

    int count1 = MyRegex().Count(testString);
    // Much nicer, no confusion about the method call
    int count2 = MyRegexProperty.Count(testString);
  }
}