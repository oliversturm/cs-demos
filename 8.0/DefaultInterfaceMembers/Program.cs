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
    }
  }
}