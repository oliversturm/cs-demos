// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates {
  class Program {
    static void Main(string[] args) {
      // Doesn't work
      //TakeIntReturnIntDelegate del = Foo;

      // Hm... shouldn't work, but does :) - 
      // Impossible to configure the C# compiler these days to NOT understand this.
      TakeIntReturnIntDelegate del = Square;

      // How it should have been in C# 1.0:
      del = new TakeIntReturnIntDelegate(Square);

      Console.WriteLine(del(13));

      // Delegates are types - do with them what you can do with other types.
      DoSomethingWithDelegate(del);
    }

    public delegate int TakeIntReturnIntDelegate(int p);

    static void Foo() {

    }

    static int Square(int x) {
      return x * x;
    }

    static void DoSomethingWithDelegate(TakeIntReturnIntDelegate del) {
      Console.WriteLine(del(5) + del(8));
    }
  }
}
