namespace InitializeFromTheBack;

// Example copied from Microsoft docs. This assignment of the whole
// value to Values (although that's not really the whole value, is it)
// works only in this pretty specific case.
internal class Program {
  private static void Main() {
    CalculationMatrix x = new()
    {
      MagicValues =
      {
        [1] = 111, [^1] = 999 // Works starting in C# 13
      }
      // x.Values[1] is 111
      // x.Values[9] is 999, since it is the last element
    };

    // My note: of course we can do individual assignments, but that's not new.
    int[] numbers = new int[5];
    Index i = ^1;
    numbers[i] = 5;
    numbers[^2] = 4;
  }
}

public class CalculationMatrix {
  public int[] MagicValues { get; set; } = new int[10];
}