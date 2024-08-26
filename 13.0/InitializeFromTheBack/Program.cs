namespace InitializeFromTheBack;

// Example copied from Microsoft docs. This assignment of the whole
// value to Values (although that's not really the whole value, is it)
// works only in this pretty specific case.
internal class Program {
  private static void Main() {
    Numbers x = new()
    {
      Values =
      {
        [1] = 111, [^1] = 999 // Works starting in C# 13
      }
      // x.Values[1] is 111
      // x.Values[9] is 999, since it is the last element
    };

    // My note: of course we can do individual assignments, but that's not new.
    int[] moreNums = new int[5];
    moreNums[^1] = 5;
    moreNums[^2] = 4;
  }
}

internal class Numbers {
  public int[] Values { get; set; } = new int[10];
}