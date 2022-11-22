using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching {
  class Program {
    static void Main(string[] args) {
    }

    static void DoMagic(object val) {
      // Using 'is' with the pattern 'null'
      if (val is null)
        return;

      if (!(val is Wand w))
        return;

      // The variable w is now scoped to the current method,
      // so it can still be used here (starting VS 15 preview 5)
      w.Simsalabim();
    }

    static void DoMagic_(object val) {
      // note that none of the type matching patterns accept null as a value
      // so the null case can be reached
      // Important: the first matching case is used, so the order matters!
      // 'default' is always evaluated last.
      switch (val) {
        case Wand w:
          w.Simsalabim();
          break;
        case MagicBall b:
          b.Look();
          break;
        case Potion ep when (ep.IsEmpty):
          // Not implemented - order new potion!
          break;
        case Potion p:
          p.Drink();
          break;
        case null:
          throw new ArgumentNullException(nameof(val));
        default:
          Console.WriteLine("Not sure how to do magic with this object");
          break;
      }
    }

    public class Wand {
      public void Simsalabim() { }
    }

    public class MagicBall {
      public void Look() { }
    }

    public class Potion {
      public bool IsEmpty { get; }
      public void Drink() { }
    }
  }
}
