namespace NullConditionalAssignment;

class Program {
  static void Main(string[] args) {
    // Before C# 14, you needed a null check before assigning to a
    // member of a potentially null object:
    //
    //   if (customer is not null) {
    //     customer.Order = GetCurrentOrder();
    //   }

    // Now you can use ?. on the left side of an assignment.
    Customer? customer = new Customer { Name = "Oli" };
    customer?.Order = GetCurrentOrder();
    Console.WriteLine($"Customer order: {customer?.Order}");

    // When the left side is null, the right side is NOT evaluated.
    Customer? nobody = null;
    nobody?.Order = GetCurrentOrderWithSideEffect();
    Console.WriteLine($"Nobody's order: {nobody?.Order}");
    // Note: "Getting current order..." was NOT printed for `nobody`,
    // proving the right side was skipped.

    // Works with compound assignment operators too
    var counter = new Counter { Value = 10 };
    Counter? maybeCounter = counter;
    maybeCounter?.Value += 5;
    Console.WriteLine($"Counter after +=: {counter.Value}");

    Counter? nullCounter = null;
    nullCounter?.Value += 5;
    Console.WriteLine($"Null counter: {nullCounter?.Value}");

    // Works with the ?[] indexer too
    List<int>? numbers = [1, 2, 3];
    numbers?[1] = 42;
    Console.WriteLine($"numbers[1]: {numbers?[1]}");

    List<int>? noNumbers = null;
    noNumbers?[0] = 42; // No exception

    // Increment and decrement (++ and --) are NOT supported
    // with null-conditional assignment.
    // maybeCounter?.Value++;  // This would be a compiler error
  }

  static string GetCurrentOrder() => "Order #1234";

  static string GetCurrentOrderWithSideEffect() {
    Console.WriteLine("  (Getting current order...)");
    return "Order #5678";
  }
}

class Customer {
  public string Name { get; set; } = "";
  public string? Order { get; set; }
}

class Counter {
  public int Value { get; set; }
}
