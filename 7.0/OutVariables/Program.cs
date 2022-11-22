using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutVariables {
  class Program {
    static void Main(string[] args) {
      // Starting with VS 15 preview 5, the out variable is scoped to the 
      // current method and can be used in following statements.
      ReturnValue(out int val1);
      Console.WriteLine($"Value is {val1}");

      // Note that even in this case, the variable is scoped to the method,
      // not just to the inner block.
      if (int.TryParse("42", out int val2)) {
        Console.WriteLine($"Parsed value {val2}");
      }
      Console.WriteLine($"Value is {val2}");

      // Wildcards are possible to ignore values. Earlier design documents
      // hinted at a more complicated syntax like "out string *", but 
      // this syntax works in VS 17 RC build 26127:
      GetValues(out string important, out _);

      Console.WriteLine($"Important is {important}");
    }

    static void ReturnValue(out int x) {
      x = 42;
    }

    static void GetValues(out string one, out string two) {
      one = "one";
      two = "two";
    }
  }
}
