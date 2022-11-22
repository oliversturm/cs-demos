namespace Ranges {
  class Program {
    static void Output<T>(IEnumerable<T> vals) {
      var sb = new System.Text.StringBuilder();
      sb.Append("[ ");
      foreach (var x in vals)
        sb.Append($"{x} ");
      sb.Append("]");
      Console.WriteLine(sb);
    }

    static void Main(string[] args) {
      var words = "There's a lady who's sure all that glitters is gold and she's buying a stairway to heaven".Split(' ');

      Output(words[1..3]); // Items 1 to 3, excluding 3
      Output(words[..3]); // Start (0) to 3, excluding
      Output(words[10..]); // Items 1 to end
      Output(words[8..^3]); // Items 8 to 3 before the end
      Output(words[^8..^5]); // Items 8 before end to 5 before end

      // Type for the Index syntax
      var end = ^3;
      var start = new Index(8, true);
      // Type for the Range syntax
      var range = start..end;
      var range2 = new Range(start, end);
      Output(words[range]);
      Output(words[range2]);

      // Note that this range function has nothing to do with the Range type
      var ints = Enumerable.Range(1, 100);

      // Can't apply the range to the sequence directly -- index
      // support is required.
      // Output(ints[range2]);

      var intArray = ints.ToArray();
      // Now the range can be reused
      Output(intArray[range2]);

      var intList = ints.ToList();
      // List<T> does not support ranges
      //Output(intList[range2]);

      // It does support indexes though!
      var threeFromEnd = intList[end];
      Console.WriteLine(threeFromEnd);

      // With a couple helpers we can support indexes and ranges for any type
      Console.WriteLine(ints.ByIndex(end));
      Output(ints.ByRange(range2));

      // With a custom wrapper, indexes and ranges can be used with index
      // syntax in custom types
      var wrappedInts = new Wrapper<int>(ints);
      Console.WriteLine(wrappedInts[^15]);
      Output(wrappedInts[11..33]);
    }

  }

  public static class EnumerableIndexExtensions {
    static public T ByIndex<T>(this IEnumerable<T> sequence, Index i) {
      var offset = i.GetOffset(sequence.Count());
      return sequence.ElementAt(offset);
    }

    static public IEnumerable<T> ByRange<T>(this IEnumerable<T> sequence, Range r) {
      var (offset, length) = r.GetOffsetAndLength(sequence.Count());
      return sequence.Skip(offset).Take(length);
    }
  }

  public class Wrapper<T> {
    public Wrapper(IEnumerable<T> source) {
      this.source = source;
    }
    IEnumerable<T> source;

    public T this[Index i] {
      get => source.ByIndex(i);
    }

    public IEnumerable<T> this[Range r] {
      get => source.ByRange(r);
    }
  }
}
