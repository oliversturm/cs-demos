namespace PerformanceFeatures {
  class Program {
    // This attribute is a performance feature -- it prevents initialization
    // of local variables to their default values. The case illustrated here
    // is a potentially relevant one, where the stackalloc array is not 
    // initialized and thereby saves 300 operations. The loop should
    // output various random values, whereas it just shows zeros if the
    // attribute is removed.
    [System.Runtime.CompilerServices.SkipLocalsInit]
    static void WorkWithSpan() {
      Span<int> span = stackalloc int[300];
      span[88] = 103; // just a quick test

      // Okay, normal stuff works -- now let's randomly check a few values
      for (int i = 17; i <= 34; i++)
        Console.WriteLine(span[i]);
    }

    static void Main(string[] args) {
      // nuint = native unsigned int
      // nint = native int
      // Work much like other ints, but faster if we do it loads of times
      // because it uses types native to the target machine.
      nuint x = 10;
      nuint y = 30;
      Console.WriteLine($"x + y = {x + y}");

      // Size is the same that can be retrieved by sizeof(nuint), but can be
      // evaluated without an `unsafe` context.
      Console.WriteLine($"On this system, nuint min={nuint.MinValue}, max={nuint.MaxValue}. Size is {nuint.Size}.");

      // Since nuint uses UIntPtr as its type, there are many utility methods --
      // they are not usually needed to interact with the type.
      // nuint.

      WorkWithSpan();
    }
  }
}
