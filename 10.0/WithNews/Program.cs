namespace WithNews {
  public record SizeRecord(int Width, int Height);

  public struct SizeStruct {
    public int Width { get; init; }
    public int Height { get; init; }

    public override string ToString() => $"SizeStruct {{ Width = {Width}, Height = {Height} }}";
  }

  class Program {
    static void Main(string[] args) {
      // Since C# 9 we can use `with` with records
      var sr1 = new SizeRecord(10, 10);
      var sr2 = sr1 with { Width = 20 };
      Console.WriteLine(sr1);
      Console.WriteLine(sr2);

      // In C# 10, structs also support `with`
      var ss1 = new SizeStruct { Width = 10, Height = 10 };
      var ss2 = ss1 with { Width = 20 };
      Console.WriteLine(ss1);
      Console.WriteLine(ss2);

      // Additionally, `with` works with anonymous types
      var a1 = new { Width = 10, Height = 10 };
      var a2 = a1 with { Width = 20 };
      Console.WriteLine(a1);
      Console.WriteLine(a2);
    }
  }
}
