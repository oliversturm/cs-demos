namespace EscapeChar;

internal class Program {
  private static void Main(string[] args) {
    // This always worked
    Console.WriteLine("This is \u001b[1mbold\u001b[0m text");

    // With C# 13 \e is also supported for Escape
    Console.WriteLine("This is \e[31m\e[1mbold red\e[0m text");
  }
}