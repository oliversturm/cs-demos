namespace NewPartialMembers;

public partial class Program {
  private static void Main(string[] args) {
    Console.WriteLine($"Hello, {Greeting}!");
    SayHello();
  }

  // This is a partial method, since C# 3.0 -- it is not implemented
  // in this sample and will be removed by the compiler.
  static partial void SayHello();

  // This is a partial property, since C# 13.0
  public static partial string Greeting { get; }

  // C# 13.0 also has partial indexers
  public partial int this[int index] { get; }
}

public partial class Program {
  public static partial string Greeting => "Everybody";

  public partial int this[int index] => 42;
}