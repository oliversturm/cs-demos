using System.Numerics;

namespace GenericMaths {
  class Program {
    // The ability to perform some maths with generic types is not 
    // a C# language feature. The implementation goes back to language
    // extensions in C# 11 though, which enable static abstract and
    // static virtual interface members, as well as checked operators.

    // Navigate to INumber<T> to see the interfaces provided by .NET 7.

    static T Add<T>(T x, T y) where T : INumber<T> {
      return x + y;
    }

    static void Main(string[] args) {
      Console.WriteLine($"Add(10,30) = {Add(10, 30)}");
      Console.WriteLine($"Add(10.7,30.8) = {Add(10.7, 30.8)}");
      Console.WriteLine($"Add(10.7m,30.8m) = {Add(10.7m, 30.8m)}");
    }
  }
}
