using System.Text.RegularExpressions;

public static partial class Program {
  [GeneratedRegex(@"[abc]+")]
  private static partial Regex MyRegex();

  public static void Main(string[] args) {
    Console.WriteLine("Hello World!");
  }
}