namespace UnboundGenericNameof;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
class CategoryAttribute : Attribute {
  public CategoryAttribute(string name) { }
  public CategoryAttribute(Type type) { }
}

class Program {
  [Category(typeof(List<>))] // OK - typeof() is allowed in attributes
  [Category(nameof(List<>))] // OK - "List" (lossy)
  [Category(nameof(List<int>))] // OK - "List" (lossy, and the int is a lie)
  // This would be the syntax that actually shows the correct name, but
  // in the place where it's most realistically useful, it's not allowed.
  //[Category(typeof(List<>).Name)] // ERROR - .Name isn't a constant expression
  static void Main(string[] args) {
    // NOTE that in spite of the news here, nameof is really the wrong
    // tool for handling of generic types, because the output doesn't
    // mention the generic parameters so that the type might look
    // just like a non-generic one with the same name.

    // Before C# 14, nameof() required a closed generic type:
    Console.WriteLine(nameof(List<int>)); // "List"
    Console.WriteLine(nameof(Dictionary<int, string>)); // "Dictionary"

    // Now you can use unbound generic types -- no need to pick
    // an arbitrary type argument just to get the name.
    Console.WriteLine(nameof(List<>)); // "List"
    Console.WriteLine(nameof(Dictionary<,>)); // "Dictionary"

    // For comparison - ugly, but at least you can tell that it's a generic type.
    Console.WriteLine(typeof(List<>).Name); // "List`1"

    // Also works with custom generic types
    Console.WriteLine(nameof(MyGenericType<>)); // "MyGenericType"
    Console.WriteLine(nameof(MyGenericType<,>)); // "MyGenericType"
  }
}

class MyGenericType<T> { }
class MyGenericType<T1, T2> { }