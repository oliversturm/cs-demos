namespace ParamsCollections;

internal class Program {
  private static void Main(string[] args) {
    AcceptSeveralIntsOldStyle(1, 2, 3, 4, 5);
    AcceptSeveralIntsNewStyle(6, 7, 8, 9, 10);
    AcceptSeveralIntsAlternativeNewStyle(11, 12, 13, 14, 15);

    // Old error message says: "The type arguments cannot be inferred from the usage."
    // Not true in this case, since the non-interface type is chosen.
    // In this demo program, that's the span.
    TakeThis(16, 17, 18, 19, 20);

    List<int> list =
    [
      21,
      22,
      23,
      24,
      25
    ];
    // Still a span!
    TakeThis(list);

    // This should read: TakeThis((IEnumerable<int>)list);
    // Rider optimization likes to remove the cast, but it's needed.
    // Now we end up in the IEnumerable<T> overload!
    // ReSharper disable once RedundantCast
    TakeThis((IEnumerable<int>)list);
  }

  // These features work with .NET 9 preview 5.

  private static void AcceptSeveralIntsOldStyle(params int[] values) {
    foreach (int value in values) {
      Console.WriteLine(value);
    }
  }

  // As of 24 June 2024, Rider EAP is a bit confused by the following two methods,
  // but they work correctly. Update: August 26th preview 7, Rider is still confused.
  private static void AcceptSeveralIntsNewStyle(params IEnumerable<int> values) {
    foreach (int value in values) {
      Console.WriteLine(value);
    }
  }

  private static void AcceptSeveralIntsAlternativeNewStyle(params ReadOnlySpan<int> values) {
    foreach (int value in values) {
      Console.WriteLine(value);
    }
  }

  private static void TakeThis<T>(params IEnumerable<T> values) {
    Console.WriteLine("Got an IEnumerable of stuff");
  }

  private static void TakeThis<T>(params ReadOnlySpan<T> values) {
    Console.WriteLine("Got a span of stuff");
  }
}