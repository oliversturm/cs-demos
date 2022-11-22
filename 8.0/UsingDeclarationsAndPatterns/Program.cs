namespace UsingDeclarationsAndPatterns {
  public class Rubbish : IDisposable {
    public Rubbish(int number) {
      Console.WriteLine($"Rubbish {number} being constructed");
      this.number = number;
    }
    readonly int number;
    public void Dispose() {
      Console.WriteLine($"Rubbish {number} being thrown away");
    }
  }

  // ref structs can adhere to the Disposable pattern without 
  // implementing IDisposable
  public ref struct RubbishStruct {
    public RubbishStruct(int number) {
      Console.WriteLine($"RubbishStruct {number} being constructed");
      this.number = number;
    }
    readonly int number;
    public void Dispose() {
      Console.WriteLine($"RubbishStruct {number} being thrown away");
    }
  }

  class Program {
    static void Main(string[] args) {
      using (var r1 = new Rubbish(1)) {
        Console.WriteLine("Working with rubbish 1");
      }

      using var r2 = new Rubbish(2);
      Console.WriteLine("Working with rubbish 2");
      Console.WriteLine("Still working with rubbish 2");

      {
        using var r3 = new Rubbish(3);
        Console.WriteLine("Working with rubbish 3");
      }

      {
        using var rs4 = new RubbishStruct(4);
        Console.WriteLine("Working with rubbish (struct) 4");
      }

      Console.WriteLine("Still working with rubbish 2");
    }
  }
}

