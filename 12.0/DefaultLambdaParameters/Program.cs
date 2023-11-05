namespace DefaultLambdaParameters {
  static class Program {
    static void Main(string[] args) {
      // Before C# 12, lambda expressions could not have default parameters.
      var power = (int val, int exp = 2) => Math.Pow(val, exp);

      Console.WriteLine(power(2));
      Console.WriteLine(power(2, 3));
      Console.WriteLine(power(2, 8));
      Console.WriteLine(power(2, 16));
    }
  }
}