namespace LambdaNews {
  class Program {
    delegate int Adder(int x, int y);

    static void Main(string[] args) {
      // lambdas can now be static, to prevent extra (or 
      // unintentional) closures
      Func<int, int, int> mult = static (x, y) => x * y;
      Console.WriteLine(mult(10, 3));

      // btw, it also works for anonymous methods
      Func<int, int, int> add = static delegate (int x, int y) { return x + y; };

      // Now for something completely different: discards.

      Adder realAdd = (x, y) => x + y;

      // This adder discards the two input parameters because we're
      // so cool we really don't care.
      Adder coolAdd = (_, _) => {
        // Since _ is a discard, it does *not* exist as a variable!
        //Console.WriteLine($"_ is {_}");
        return 42;
      };

      Console.WriteLine($"coolAdd(7,4) returns {coolAdd(7, 4)}");

      Adder partiallyCoolAdd = (_, y) => {
        // For historical reasons, _ *does* exist in this case.
        // Some people thought for a long time that _ was a discard, but it was 
        // just a weird variable name before C# 9. As long as there's just one
        // _ in the parameter list, it still works that way to prevent breakage.
        Console.WriteLine($"_ is {_}");
        return y;
      };

      Console.WriteLine($"partiallyCoolAdd(7,4) returns {partiallyCoolAdd(7, 4)}");
    }
  }
}
