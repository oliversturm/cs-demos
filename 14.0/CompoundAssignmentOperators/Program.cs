namespace CompoundAssignmentOperators;

class Program {
  static void Main(string[] args) {
    // Before C# 14, the compound assignment operator += was always
    // desugared to: x = x + y
    // This means a new object was created even when in-place mutation
    // would be more efficient. Now you can overload the compound
    // assignment operator directly as an instance method.

    var counter = new PartyCounter("Birthday Party");
    Console.WriteLine($"Initial: {counter}");

    // Compound assignment -- calls the instance operator+=,
    // modifying the counter in place without creating a new object.
    counter += 5;
    Console.WriteLine($"After += 5: {counter}");
    counter += 3;
    Console.WriteLine($"After += 3: {counter}");

    // Increment -- also an instance operator
    counter++;
    Console.WriteLine($"After ++: {counter}");

    // The regular + operator still creates a new instance
    var bigger = counter + 10;
    Console.WriteLine($"New counter from +: {bigger}");
    Console.WriteLine($"Original unchanged: {counter}");
  }
}

class PartyCounter(string name) {
  public string Name => name;
  public int Count { get; private set; }

  // Traditional static binary operator -- creates a new instance
  public static PartyCounter operator +(PartyCounter left, int right) {
    Console.WriteLine("  (operator+ called -- creating new counter)");
    var result = new PartyCounter(left.Name) { Count = left.Count + right };
    return result;
  }

  // New in C# 14: compound assignment as an instance method.
  // Key differences from traditional operators:
  //   - Not static (it's an instance method, modifying `this`)
  //   - Returns void (mutation in place, no new object)
  //   - Takes one parameter (the right-hand operand)
  public void operator += (int partySize) {
    Console.WriteLine("  (operator+= called -- modifying in place)");
    Count += partySize;
  }

  // Increment and decrement are also supported
  public void operator ++() {
    Console.WriteLine("  (operator++ called -- modifying in place)");
    Count++;
  }

  public override string ToString() => $"{Name}: {Count} guests";
}