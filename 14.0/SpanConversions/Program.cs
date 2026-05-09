namespace SpanConversions;

class Program {
  static void Main(string[] args) {
    // C# 14 adds first-class implicit conversions for Span<T> and
    // ReadOnlySpan<T>.

    string s = "hello";
    //Print(s); // this still doesn't work without type hint
    Print<char>(s);

    int[] arr = [1, 2, 3];
    Print(arr); // but this works - would have failed in C# 13

    // The key improvement: overload resolution now naturally picks
    // Span-based overloads, and generic type inference works with spans.
    // But NOTE: this is dangerous stuff. Three out of the calls below
    // now pick the ReadOnlySpan<T> overload, but one does not.
    PrintItems([1, 2, 3]);
    PrintItems(arr); // <- this one prefers the T[] overload
    PrintItems(span);
    PrintItems(readOnlySpan);
  }

  static void Print<T>(ReadOnlySpan<T> items) {
    // doing nothing
  }

  static void PrintItems<T>(T[] ts) {
    Console.WriteLine("In PrintItems<T>(T[]) - didn't expect to be here.");
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
}