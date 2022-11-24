namespace DefaultInterfaceMembers {
  interface IMoveable {
    // Default implementation provided. Many other member types supported.
    void Move() {
      Console.WriteLine("Moving... somehow? Or perhaps we forgot the method.");
    }
  }

  interface IGuru {
    int TheAnswer { get => 42; }

    // Almost strange stuff -- this method implementation
    // will refer to `TheAnswer` as overridden in any 
    // actual implementation.
    void PrintTheAnswer() {
      Console.WriteLine($"Answer fallback: {TheAnswer}");
    }
  }

  class Bird : IMoveable {
    void IMoveable.Move() {
      Console.WriteLine("Flying elegantly");
    }
  }

  class Jogger : IMoveable {
    void IMoveable.Move() {
      Console.WriteLine("Running for no reason");
    }
  }

  class Sun : IMoveable, IGuru {
  }

  class ElonMusk : IGuru {
    public int TheAnswer { get => 1000000000; } // at least!
  }

  // One of the more common cases for standard/fallback implementations.
  // This reminds of (a feature of) Type Classes in Haskell.
  interface ICustomEquality<T> {
    bool EqualTo(T other) => !NotEqualTo(other);
    bool NotEqualTo(T other) => !EqualTo(other);
  }

  class Num : ICustomEquality<Num> {
    public int Val { get; set; }
    // We only need the one implementation and we get the other one for free --
    // could choose the other one if it were easier for some reason.
    bool ICustomEquality<Num>.EqualTo(Num other) => this.Val == other.Val;
  }

  class Program {
    static void Main(string[] args) {
      var things = new List<IMoveable>{
        new Bird(), new Jogger(), new Sun()
      };
      foreach (var t in things) {
        t.Move();
      }

      var guru = (IGuru)new Sun();
      Console.WriteLine($"The answer: {guru.TheAnswer}");
      guru.PrintTheAnswer();

      var elon = (IGuru)new ElonMusk();
      elon.PrintTheAnswer(); // this gives 1 billion

      var num1 = new Num { Val = 42 };
      var num2 = new Num { Val = 42 };
      var num3 = new Num { Val = 101 };

      Console.WriteLine($"num1 custom equal to num2: {((ICustomEquality<Num>)num1).EqualTo(num2)}");
      Console.WriteLine($"num1 custom equal to num3: {((ICustomEquality<Num>)num1).EqualTo(num3)}");
      Console.WriteLine($"num1 NOT custom equal to num2: {((ICustomEquality<Num>)num1).NotEqualTo(num2)}");
      Console.WriteLine($"num1 NOT custom equal to num3: {((ICustomEquality<Num>)num1).NotEqualTo(num3)}");
    }
  }
}