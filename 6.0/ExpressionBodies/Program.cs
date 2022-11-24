using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodies {
  class Program {
    static void Main(string[] args) {
      var counter = new Counter();
      Console.WriteLine(counter.CurrentValue);
      Console.WriteLine("Incrementing: {0}", counter.Increment());
      Console.WriteLine(counter.CurrentValue);
      Console.WriteLine("Incrementing: {0}", counter.Increment_());
      Console.WriteLine(counter.CurrentValue);
    }
  }

  public class Counter {
    public Counter() : this(0) { }
    public Counter(int init) {
      CurrentValue = init;
    }
    public int CurrentValue { get; private set; }

    // functions can have an expression body now
    public int Increment() => ++CurrentValue;

    // properties can have an expression body as well
    public int CurrentValue_ => CurrentValue;

    // the property expression can be a function in its own right
    public Func<int> Increment_ => () => ++CurrentValue;

    // the expression have to be real expressions though - NO
    // statement bodies
    //public Func<int> IncrementAndLog() => {
    //  Console.WriteLine("Returning " + CurrentValue);
    //  return CurrentValue;
    //};

    // Indexers that take a parameter can also have expression bodies
    public int this[int id] => id;
  }
}
