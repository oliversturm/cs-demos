// Copyright 2010 Oliver Sturm <oliver@sturmnet.org> All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousMethods {
  class Program {
    static void Main(string[] args) {
      TakeIntReturnIntDelegate method1 =
        delegate (int v) {
          return v + 100;
        };

      DoSomethingWithDelegate(method1);

      DoSomethingWithDelegate(delegate (int x) { return x / 2; });
    }

    public delegate int TakeIntReturnIntDelegate(int p);
    public delegate int ReturnIntDelegate();

    static int Square(int x) {
      return x * x;
    }

    static void DoSomethingWithDelegate(TakeIntReturnIntDelegate del) {
      Console.WriteLine(del(5) + del(8));
    }
  }
}
