using System.Globalization;
using System.Numerics;

namespace GenericMaths {
  public partial class OlisNumber {
    public OlisNumber(int intVal) {
      this.intVal = intVal;
    }
    private readonly int intVal;
    // Add what you like, OlisNumber result is always 42
    public static OlisNumber operator +(OlisNumber x, OlisNumber y) => new OlisNumber(42);
  }

  static class Program {
    // The ability to perform some maths with generic types is not 
    // a C# language feature. The implementation goes back to language
    // extensions in C# 11 though, which enable static abstract and
    // static virtual interface members, as well as checked operators.

    // Navigate to (or hover on) INumber<T> to see the interfaces provided by .NET 7.

    static T Add<T>(T x, T y) where T : INumber<T> {
      return x + y;
    }

    static void Main(string[] args) {
      Console.WriteLine($"Add(10,30) = {Add(10, 30)}");
      Console.WriteLine($"Add(10.7,30.8) = {Add(10.7, 30.8)}");
      Console.WriteLine($"Add(10.7m,30.8m) = {Add(10.7m, 30.8m)}");

      var oli1 = new OlisNumber(10);
      var oli2 = new OlisNumber(783);
      Console.WriteLine($"Add directly oli1 + oli2 = {oli1 + oli2}");

      // However, use of the generic Add method does not work automatically
      // Uncomment the partial class in OlisNumberINumber.cs to make it work.
      //Console.WriteLine($"Add(oli1, oli2) = {Add(oli1, oli2)}");
    }
  }
}