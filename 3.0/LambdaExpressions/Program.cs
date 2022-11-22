// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpressions {
  class Program {
    static void Main(string[] args) {
      // This approach uses a specific delegate type as well as 
      // specially prepared methods to pass in.
      DoSomething(Return42);
      DoSomething(Add10);

      // This uses an anonymous method, like C# 2 allows.
      DoSomething(delegate (int input) {
        return input * input;
      });

      // Finally, a lambda expression in C# 3
      DoSomething(x => x * x * x);

      // Lambdas can have complex statement bodies:
      Func<int, int, bool> calculation =
        (int val1, int val2) => {
          if (val1 + val2 == 42)
            return true;
          else
            return false;
        };

      // Or simple expression bodies, potentially with the same result:
      Func<int, int, bool> sameCalculation = (v1, v2) => v1 + v2 == 42;
    }

    delegate int TakeIntReturnIntDelegate(int input);

    static void DoSomething(TakeIntReturnIntDelegate function) {
      Console.WriteLine(function(10));
    }

    static int Return42(int input) {
      return 42;
    }

    static int Add10(int input) {
      return input + 10;
    }
  }
}
