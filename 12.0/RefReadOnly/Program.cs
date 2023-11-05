namespace RefReadOnly {
  static class Program {
    // Reminder: ref parameters
    static void AcceptRef(ref int x) {
      // Value can be read
      Console.WriteLine(x);

      // Value can also be changed
      x = 42;
    }

    // Reminder: in parameters
    static void AcceptIn(in int x) {
      // Value can be read
      Console.WriteLine(x);

      // Value cannot be changed
      // x = 42;
    }

    // Irrelevant here, but for completeness: out parameters
    static void AcceptOut(out int x) {
      // Value cannot be read
      // Console.WriteLine(x);

      // Value must be assigned
      x = 101;
    }

    // ref readonly parameters accept only variables
    // They can't change the value.
    // This closes the gap: accept only variables, not literals,
    // but don't allow changes.
    static void AcceptRefReadOnly (ref readonly int x) {
      // Value can be read
      Console.WriteLine(x);

      // Value cannot be changed
      // x = 42;
    }

    static void Main(string[] args) {
      // To call AcceptRef, an initialized variable must be passed
      int val = 10;
      AcceptRef(ref val);
      // Now the value may be changed
      Console.WriteLine(val);

      // To call AcceptIn, an initialized variable or a literal must be passed
      AcceptIn(10);
      AcceptIn(val);

      // To call AcceptOut, an variable must be passed and it /can/ be uninitialized
      AcceptOut(out val);
      AcceptOut(out int newVal); // inline declaration
      Console.WriteLine($"val={val}, newVal={newVal}");

      // To call AcceptRefReadOnly, an initialized variable must be passed
      AcceptRefReadOnly(ref val);
    }
  }
}