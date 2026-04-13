namespace SpanConversions;

class Program {
  static void Main(string[] args) {
    // C# 14 adds first-class implicit conversions for Span<T> and
    // ReadOnlySpan<T>. These types have been central to high-performance
    // .NET code, and the new conversions make them easier to use.

    // Array to Span -- this worked before, but now participates
    // in more conversion contexts.
    int[] array = [1, 2, 3, 4, 5];
    Span<int> span = array;
    ReadOnlySpan<int> readOnlySpan = span;

    // String to ReadOnlySpan<char> -- now an implicit conversion in
    // all contexts, enabling natural use in method calls.
    string text = "Hello, Spans!";
    ReadOnlySpan<char> chars = text;
    Console.WriteLine($"First char from span: {chars[0]}");

    // The key improvement: overload resolution now naturally picks
    // Span-based overloads, and generic type inference works with spans.
    PrintItems(array);
    PrintItems(span);
    PrintItems(readOnlySpan);

    // Span conversions compose with other conversions, so a method
    // accepting ReadOnlySpan<char> can be called with a string directly.
    CountVowels("Hello, World!");
  }

  // A method accepting ReadOnlySpan<T> can now be called with an array
  // or a Span<T> without explicit conversion.
  static void PrintItems<T>(ReadOnlySpan<T> items) {
    Console.Write("Span items: ");
    for (int i = 0; i < items.Length; i++) {
      if (i > 0) Console.Write(", ");
      Console.Write(items[i]);
    }
    Console.WriteLine();
  }

  // A practical example: accepting ReadOnlySpan<char> lets this method
  // work with both strings and char spans without overloads.
  static void CountVowels(ReadOnlySpan<char> text) {
    int count = 0;
    foreach (char c in text) {
      if ("aeiouAEIOU".Contains(c)) count++;
    }
    Console.WriteLine($"Vowels in \"{text}\": {count}");
  }
}
