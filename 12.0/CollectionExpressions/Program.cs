using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace CollectionExpressions {
  static class Program {
    static void Main(string[] args) {
      // int[] can be instantiated and filled using the new syntax
      int[] odds = [1, 3, 5, 7, 9, 11];

      // Various target types are supported, so you can't use `var`
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
      Dictionary<string, int> dict = []; // or new() ?

      // Now... some special considerations. For arrays or lists we can also do this:
      int[] moreOdds = { 17, 19, 21, 23, 25 };
      // or this:
      List<int> evenMoreOdds = new() { 27, 29, 31 };
      Console.WriteLine($"evenMoreOdds contains {evenMoreOdds.Count} elements");

      // But this does not work -- although the compiler doesn't know it
      // ImmutableArray<int> oddsOdds = new() { 35, 37, 39 };
      // Console.WriteLine($"oddsOdds contains {oddsOdds.Length} elements");

      // However, this works -- but why??
      ImmutableArray<int> immutableArray = [1, 2, 3, 4, 5];
      Console.WriteLine($"immutableArray contains {immutableArray.Length} elements");

      var olisContainer1 = new OlisContainer([1, 2, 3, 4, 5]);
      var olisContainer2 = OlisContainer.Create([1, 2, 3, 4, 5]);

      // This collection expression works if:
      //   - (obviously, the type is a list -- but it's not)
      //   - (theoretically, if there's an Add method -- but only with a default ctor)
      //   - the custom type has a valid CollectionBuilder attribute
      //   - the custom type is enumerable
      OlisContainer olisContainer3 = [1, 2, 3, 4, 5];
    }
  }

  // This type has an internal list storage, but it's not a list itself
  [CollectionBuilder(typeof(OlisContainer), methodName: "Create")]
  public class OlisContainer(ReadOnlySpan<int> items) : IEnumerable<int> {
    private readonly List<int> items = new(items.ToArray());
    public static OlisContainer Create(ReadOnlySpan<int> items) => new(items);

    // For simplicity, delegate the interface to the existing storage
    public IEnumerator<int> GetEnumerator() {
      return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return ((IEnumerable)items).GetEnumerator();
    }
  }
}