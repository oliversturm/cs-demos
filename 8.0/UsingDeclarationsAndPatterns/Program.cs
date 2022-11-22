namespace UsingDeclarationsAndPatterns {
  public class Rubbish { // }: IDisposable {
    public Rubbish(int number) {
      Console.WriteLine($"Rubbish {number} being constructed");
      this.number = number;
    }
    readonly int number;
    public void Dispose() {
      Console.WriteLine($"Rubbish {number} being thrown away");
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

      Console.WriteLine("Still working with rubbish 2");
    }
  }
}

