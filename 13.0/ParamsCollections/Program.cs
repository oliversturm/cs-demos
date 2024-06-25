namespace ParamsCollections;

class Program {
  static void Main(string[] args) {
    AcceptSeveralIntsOldStyle(1, 2, 3, 4, 5);
    AcceptSeveralIntsNewStyle(6, 7, 8, 9, 10);
    AcceptSeveralIntsAlternativeNewStyle(11, 12, 13, 14, 15);
  }

  // These features work with .NET 9 preview 5.

  static void AcceptSeveralIntsOldStyle(params int[] values) {
    foreach (var value in values) {
      Console.WriteLine(value);
    }
  }

  // As of 24 June 2024, Rider EAP is a bit confused by the following two methods,
  // but they work correctly.
  static void AcceptSeveralIntsNewStyle(params IEnumerable<int> values) {
    foreach (var value in values) {
      Console.WriteLine(value);
    }
  }

  static void AcceptSeveralIntsAlternativeNewStyle(params ReadOnlySpan<int> values) {
    foreach (var value in values) {
      Console.WriteLine(value);
    }
  }
}