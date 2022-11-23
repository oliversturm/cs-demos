namespace NullCoalescingAssignment {
  class Program {
    static void Main(string[] args) {
      string one = "something";

      // Null coalescing operator ?? means the same as the ternary expression below
      // (since C# 2.0)
      string two = one ?? "something else";
      string two_ = one != null ? one : "something else";
      Console.WriteLine($"Two: {two}");

      // Null coalescing assignment checks the value on the left
      // This line does not make sense:
      //string three ??= one;
      string? three = default;
      // three is equal to one after this, because it was previously null.
      three ??= one;
      Console.WriteLine($"Three: {three}");

      // Btw, the whole thing is really only meant for nullable types. These produce warnings.
      string four = default;
      four ??= one;
      Console.WriteLine($"Four: {four}");

      // Use with non-nullable value types is impossible
      // int num = default;
      // num ??= 10;

      // Does work with nullable value types though
      int? num = default;
      num ??= 10;
      Console.WriteLine($"Num: {num}");

      // Now for real purposes. Let's say we have a list variable:
      List<string>? list = default;

      // Later, we may not know whether the list has already been initialized.
      // We typically used a pattern like this in the past:
      // if (list == null)
      //   list = new();
      // list.Add("some text");

      // Now we can use one line to do the same thing:
      (list ??= new()).Add("some text");
    }
  }
}
