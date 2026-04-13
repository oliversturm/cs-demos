using System.Text;

namespace ExtensionMembers;

class Program {
  static void Main(string[] args) {
    // Instance extension property
    var numbers = new List<int> { 1, 2, 3, 4, 5 };
    Console.WriteLine($"Is the list empty? {numbers.IsEmpty}");
    Console.WriteLine($"Is an empty list empty? {new List<int>().IsEmpty}");

    // Instance extension method
    string greeting = "Hello, World!";
    Console.WriteLine($"Word count: {greeting.WordCount}");
    Console.WriteLine($"Reversed: {greeting.Reverse()}");

    // Static extension member -- accessed via the type, not an instance
    Console.WriteLine($"Default greeting: {string.DefaultGreeting}");

    // Extension operator
    var a = new List<int> { 1, 2, 3 };
    var b = new List<int> { 4, 5, 6 };
    var combined = a + b;
    Console.WriteLine($"Combined: {string.Join(", ", combined)}");
  }
}

// The new extension member syntax in C# 14 replaces both classic
// extension methods and the earlier preview `implicit extension for`
// syntax. Extensions are defined in blocks inside a static class.

static class StringExtensions {
  // Instance extensions: the parameter name provides access to the
  // receiver, similar to `this` in the old extension method syntax.
  extension(string source) {
    public int WordCount =>
      source.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

    public string Reverse() {
      var chars = source.ToCharArray();
      Array.Reverse(chars);
      return new string(chars);
    }
  }

  // Static extensions: omitting the parameter name makes the members
  // appear as static members on the extended type.
  extension(string) {
    public static string DefaultGreeting => "Hello from a static extension!";
  }
}

static class ListExtensions {
  extension<T>(IEnumerable<T> source) {
    public bool IsEmpty => !source.Any();
  }

  // Static extension members can include operators. These are called
  // as if they are part of the extended type.
  extension<T>(IEnumerable<T>) {
    public static IEnumerable<T> operator +(IEnumerable<T> left, IEnumerable<T> right) =>
      left.Concat(right).ToList();
  }
}
