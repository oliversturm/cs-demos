using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExpressions {
  class Program {
    static int Divide(int x, int y) {
      // throw "statements" can be used as expressions
      return y == 0 ? throw new ArgumentException("y can't be zero") : x / y;
    }

    // That doesn't mean you can do everything with throw expressions.
    // After all, they don't represent a value. The point of the expressions
    // is to include them in short syntax, like ternary expressions,
    // which specifically enables them to be used in expression bodies.
    static object Foo(object o) {
      // can't assign them
      //var x = throw new ArgumentException();

      // can't return them by themselves
      //return throw new ArgumentException();

      // can't use them as part of logical expressions
      //if (o != null || throw new ArgumentNullException) { }

      // even though this works, and it's the same logical expression:
      return o ?? throw new ArgumentNullException();
    }

    static void Main(string[] args) {
    }
  }
}
