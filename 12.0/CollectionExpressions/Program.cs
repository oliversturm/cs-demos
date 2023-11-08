namespace CollectionExpressions {
  static class Program {
    static void Main(string[] args) {
      // int[] can be instantiated and filled this way, but
      // type inference doesn't work
      int[] odds = [1, 3, 5, 7, 9, 11];

      // One reason is that multiple target types are supported
      Span<int> evens = [2, 4, 6, 8, 10, 12];
      List<int> primes = [2, 3, 5, 7, 11, 13];

      // Multiple dimensions are supported
      int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

      // The spread operator can be used
      int[] allNumbers = [..evens, ..odds];

      IEnumerable<int> OnlyByFives(IEnumerable<int> source) {
        foreach (var item in source) {
          if (item % 5 == 0) yield return item;
        }
      }

      // A collection expression can also be passed to a method that
      // expects one.
      int[] primesAndByFives = [..primes, ..OnlyByFives([..evens, ..odds])];

      foreach (int i in primesAndByFives) Console.WriteLine(i);

      // Create a new dictionary using assignment -- technically
      // the [] could contain instances of KeyValuePair<string,int>
      // I don't like this syntax, but it's there.
      Dictionary<string,int> dict = []; // or new() ?
    }
  }
}