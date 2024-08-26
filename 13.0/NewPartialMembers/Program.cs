namespace NewPartialMembers;

public partial class Program {
  private static void Main(string[] args) {
    Console.WriteLine("Hello, World!");
  }

  // This is a partial method, since C# 3.0
  partial void SayHello();

  // This is a partial property, since C# 13.0
  public partial string Greeting { get; }

  // C# 13.0 also has partial indexers
  public partial string this[int index] { get; }
}

public partial class Program {
  public partial string Greeting => "Hello, World!";

  public partial string this[int index] => "thing";
}