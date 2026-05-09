namespace UnboundGenericNameof;

class Program {
  static void Main(string[] args) {
    // Before C# 14, nameof() required a closed generic type:
    Console.WriteLine(nameof(List<int>)); // "List"
    Console.WriteLine(nameof(Dictionary<int, string>)); // "Dictionary"

    // Now you can use unbound generic types -- no need to pick
    // an arbitrary type argument just to get the name.
    Console.WriteLine(nameof(List<>)); // "List"
    Console.WriteLine(nameof(Dictionary<,>)); // "Dictionary"

    // This is particularly useful for logging and diagnostics where
    // you want to refer to a generic type without committing to a
    // specific type argument.
    LogTypeUsage<int>();
    LogTypeUsage<string>();

    // Also works with custom generic types
    Console.WriteLine(nameof(MyGenericType<>)); // "MyGenericType"
    Console.WriteLine(nameof(MyGenericType<,>)); // "MyGenericType"
  }

  // A realistic scenario: logging infrastructure that references
  // the generic type by name without needing a type parameter.
  static void LogTypeUsage<T>() {
    // Before C# 14, you'd have to use typeof(List<>).Name or
    // pick a dummy type argument like nameof(List<object>).
    Console.WriteLine($"Processing {nameof(List<>)}<{typeof(T).Name}>");
  }
}

class MyGenericType<T> { }
class MyGenericType<T1, T2> { }