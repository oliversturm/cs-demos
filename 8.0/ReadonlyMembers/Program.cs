namespace ReadonlyMembers {
  // Complete structs can be readonly. 
  public readonly struct ReadonlyRect {
    public ReadonlyRect(int width, int height) {
      Width = width;
      Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    public override string ToString() => $"ReadonlyRect ({Width},{Height})";
  }

  // Structs can also be partially readonly. What's the point?
  //   * Convey intent
  //   * Allow compiler optimizations -- this is the important thing, lots of 
  //     copying can be saved in the right circumstances.
  // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/readonly-instance-members
  public struct WeirdRect {
    public WeirdRect(int width, int height) {
      Width = width;
      Height = height;
    }

    public int Width { get; }
    public readonly int Height { get; }

    private int variable;
    public int Variable {
      readonly get => variable; // Hm...
      set => variable = value;
    }

    public readonly override string ToString() => $"WeirdRect ({Width},{Height}, Variable={Variable})";
  }

  class Program {
    static void Main(string[] args) {

      Console.WriteLine(new ReadonlyRect(5, 2));
      Console.WriteLine(new WeirdRect(5, 2));

      var wr = new WeirdRect(10, 3);
      wr.Variable = 17;
      Console.WriteLine(wr);
    }
  }
}

